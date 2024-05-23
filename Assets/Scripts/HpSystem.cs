using TMPro;
using UnityEngine;

namespace MTaka
{
    /// <summary>
    /// 血量系統
    /// </summary>
    public class HpSystem : MonoBehaviour
    {
        [SerializeField, Header("畫布傷害預置物")]
        private GameObject prefabDamageCanvas;

        protected float hp;

        /// <summary>
        /// 受傷
        /// </summary>
        public virtual void Damage(float damage)
        {
            // 如果血量 <= 0 就跳出
            if (hp <= 0) return;

            // 暫存傷害值物件 = 生成
            GameObject tempDamage = Instantiate(prefabDamageCanvas, transform.position, Quaternion.identity);
            // 暫存傷害值物件 的 變形 的 透過名稱尋找子物件("子物件名稱") 取得文字並更新
            tempDamage.transform.Find("文字傷害值").GetComponent<TMP_Text>().text = damage.ToString();
            hp -= damage;
            print($"<color=#f33>{gameObject.name}受傷，血量剩下：{hp}</color>");
            if ( hp <= 0 ) Dead();
        }

        // virtual 虛擬關鍵字：允許子類別使用關鍵字 override 覆寫
        /// <summary>
        /// 死亡
        /// </summary>
        protected virtual void Dead()
        {
            print($"<color=#f33>{gameObject.name}死亡</color>");
        }
    }
}