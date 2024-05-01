using UnityEngine;

namespace MTaka
{
    /// <summary>
    /// 敵人系統
    /// </summary>
    public class EnemySystem : MonoBehaviour
    {
        [SerializeField, Header("敵人資料")]
        private DataEnemy data;

        private Rigidbody2D rig;
        private Animator ani;
        private Transform playerPosition;

        private void Awake()
        {
            rig = GetComponent<Rigidbody2D>();
            ani = GetComponent<Animator>();

            // 透過名稱尋找遊戲物件 GameObject.Find(物件名稱)
            // 玩家位置 = 尋找場景上名稱為"玩家_盜賊"的物件 的變形元件
            playerPosition =  GameObject.Find(GameManager.playerName).transform;
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
    }
}