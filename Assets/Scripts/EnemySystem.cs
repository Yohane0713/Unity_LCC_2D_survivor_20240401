using UnityEngine;
using System.Collections;

namespace MTaka
{
    /// <summary>
    /// 敵人系統
    /// </summary>
    public class EnemySystem : MonoBehaviour
    {
        #region 資料區域
        [SerializeField, Header("敵人資料")]
        private DataEnemy data;
        [SerializeField, Header("玩家圖層")]
        private LayerMask playerLayer;

        private Rigidbody2D rig;
        private Animator ani;
        private Transform playerPosition;
        // 是否在攻擊中
        protected bool isAttacking;
        #endregion

        protected virtual void OnDrawGizmos()
        {
            Gizmos.color = new Color(0.8f, 0.8f, 0.5f, 0.6f);
            Gizmos.DrawSphere(transform.position, data.attackRange);

            Gizmos.color = new Color(1, 0.3f, 0.3f, 0.6f);
            Gizmos.DrawCube(
                transform.position +
                transform.TransformDirection(data.attackAreaOffset),
                data.attackAreaSize);
        }

        protected IEnumerator attackMode;

        protected virtual void Awake()
        {
            rig = GetComponent<Rigidbody2D>();
            ani = GetComponent<Animator>();

            // 透過名稱尋找遊戲物件 GameObject.Find(物件名稱)
            // 玩家位置 = 尋找場景上名稱為"玩家_盜賊"的物件 的變形元件
            playerPosition =  GameObject.Find(GameManager.playerName).transform;

            attackMode = StartAttack();
        }

        private void Update()
        {
            Flip();
            Attack();
        }

        // Upadate 更新事件：一秒執行約 60 次
        // FixedUpdate 固定更新事件：一秒執行 50 次 (每幀 0.02秒)，建議執行物理
        private void FixedUpdate()
        {
            Move();
        }

        /// <summary>
        /// 移動方法
        /// </summary>
        private void Move()
        {
            // 如果和玩家距離小於攻擊範圍 就跳出
            if (CheckDistance() < data.attackRange) return;
            // 如果正在攻擊中 就跳出(不會邊移動邊攻擊)
            if (isAttacking) return;
            rig.velocity = transform.right * data.moveSpeed + transform.up * rig.velocity.y;
            ani.SetFloat(GameManager.parMove, 1);
        }

        /// <summary>
        /// 移動方法，透過剛體 MovePosition
        /// </summary>
        private void MovePosition()
        {
            // 獲得目前座標 = 敵人剛體座標
            Vector2 currentPoint = rig.position;
            // 玩家座標
            Vector2 playerPoint = playerPosition.position;
            // 玩家座標的 y(高度) = 目前座標的 y
            playerPoint.y = currentPoint.y;
            // 向量 = 玩家座標 - 目前座標
            Vector2 direction = playerPoint - currentPoint;
            // 要前往的座標 = 目前座標 + 向量X移動速度X每固定幀的時間(0.02)←這個數值在Project Stetting裡面
            Vector2 movePosition = currentPoint + direction * data.moveSpeed * Time.fixedDeltaTime;

            // 剛體 的 移動座標(要前往的座標)
            rig.MovePosition(movePosition);
        }

        /// <summary>
        /// 翻面，如果敵人的X大於玩家的X，角度設為180，否則為0
        /// </summary>
        private void Flip()
        {
            float angle = transform.position.x > playerPosition.position.x ? 180 : 0;
            transform.eulerAngles = new Vector3(0, angle, 0);
        }

        /// <summary>
        /// 檢測敵人和玩家距離
        /// </summary>
        private float CheckDistance()
        {
            float dis = Vector2.Distance(transform.position, playerPosition.position);
            // print($"<color=#f96>距離：{dis}</color>");
            return dis;
        }

        protected virtual void Attack() 
        {
            // 如果距離大於等於攻擊範圍 就跳出
            if (CheckDistance() >= data.attackRange) return;
            // 如果正在攻擊中 就跳出
            if (isAttacking) return;

            StartCoroutine(attackMode);
        }

        /// <summary>
        /// 開始攻擊，敵人攻擊協同程序
        /// </summary>
        protected IEnumerator StartAttack()
        {
            // 正在攻擊中
            isAttacking = true;
            // print("<color=#f33>開始攻擊</color>");
            ani.SetFloat(GameManager.parMove, 0);
            ani.SetTrigger(GameManager.parAttack);
            yield return new WaitForSeconds(data.attackBefore);
            // print("<color=#f99>前搖結束，造成玩家傷害</color>");
            AttackPlayer();
            yield return new WaitForSeconds(data.attackAfter);
            // print("<color=#f99>後搖結束，恢復原本狀態</color>");
            // 恢復沒有在攻擊中
            isAttacking = false;

            attackMode = StartAttack();
        }

        /// <summary>
        /// 攻擊玩家
        /// </summary>
        private void AttackPlayer()
        {
            Collider2D hit = Physics2D.OverlapBox(
                transform.position +
                transform.TransformDirection(data.attackAreaOffset),
                data.attackAreaSize, 0, playerLayer);

            // hit?.name 如果打到的不是空值 才取得name
            // print($"<color=#f99>攻擊到的物件：{hit?.name}</color>");
            // 擊中物件 的 玩家血量 的 受傷 (敵人資料的攻擊力)
            float attack = Mathf.Floor(data.attack = Random.Range(0, data.attack * 0.2f));
            hit?.GetComponent<HpPlayer>().Damage(attack);
        }
    }
}