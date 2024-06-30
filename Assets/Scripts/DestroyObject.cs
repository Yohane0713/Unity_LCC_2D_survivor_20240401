using UnityEngine;

namespace MTaka
{
    /// <summary>
    /// 刪除物件
    /// </summary>
    public class DestroyObject : MonoBehaviour
    {
        [SerializeField, Header("刪除物件時間"), Range(0, 10)]
        private float destroyTime = 3;
        [SerializeField, Header("是否碰撞後刪除")]
        private bool destroyAfterHit;
        [SerializeField, Header("碰撞幾次後刪除"), Range(0, 10)]
        private int destroyAfterHitTime = 4;

        private int hitTime;

        private void Awake()
        {
            Destroy(gameObject, destroyTime);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            DestroyAfterHit();
            DestroyAfterHitTime();
        }

        /// <summary>
        /// 碰撞後刪除
        /// </summary>
        private void DestroyAfterHit()
        {
            if (destroyAfterHit) Destroy(gameObject);
        }

        /// <summary>
        /// 達到碰撞次數後刪除
        /// </summary>
        private void DestroyAfterHitTime()
        {
            hitTime++;
            if (hitTime >= destroyAfterHitTime) Destroy(gameObject);
        }
    }

}