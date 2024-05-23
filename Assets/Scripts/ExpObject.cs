using UnityEngine;

namespace MTaka
{
    /// <summary>
    /// 經驗值物件：實作往玩家飛行功能
    /// </summary>
    public class ExpObject : MonoBehaviour
    {
        [SerializeField, Header("經驗值飛行速度"), Range(0, 10)]
        private float flyspeed = 3.5f;
        [SerializeField, Header("獲得經驗值的距離"), Range (0, 10)]
        private float getExpDistance = 2;
        [SerializeField, Header("經驗值"), Range(0, 20000)]
        private float exp;

        private Transform player;

        private void Awake()
        {
            player = GameObject.Find(GameManager.playerName).transform;
        }

        private void Update()
        {
            FlyToPlayer();
            GetExpAndDestroy();
        }

        /// <summary>
        /// 往玩家座標飛行 
        /// </summary>
        private void FlyToPlayer()
        {
            // 此物件的座標 = 二維向量.向前移動(此物件的座標，玩家的座標，速度)
            transform.position = Vector2.MoveTowards(
                transform.position, player.position, flyspeed * Time.deltaTime);
        }

        /// <summary>
        /// 獲得經驗值與刪除
        /// </summary>
        private void GetExpAndDestroy()
        {
            // 與玩家的距離 <= 刪除距離 就獲得經驗值並刪除
            if (Vector2.Distance(transform.position, player.position) < getExpDistance)
            {
                // 單例模式類別.實體.公開成員
                ExpManager.instance.AddExp(exp);
                Destroy(gameObject);
            }
        }
    }
}