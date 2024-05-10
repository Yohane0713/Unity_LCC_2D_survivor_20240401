using UnityEngine;

namespace MTaka
{
    /// <summary>
    /// 敵人血量系統
    /// </summary>
    public class HpEnemy : HpSystem
    {
        [SerializeField, Header("敵人資料")]
        private DataEnemy dataEnemy;

        private string weaponName = "武器";

        private void Awake()
        {
            hp = dataEnemy.hp;
        }

        // OnCollisionXXX
        // 條件： 兩個物件都有碰撞器並且沒有勾選 IsTrigger

        // OnTriggerXXX
        // 條件： 兩個物件都有碰撞器並且其中一個勾選 IsTrigger

        // OnCollisionEnter 碰撞開始執行一次
        // OnCollisionStay  碰撞時持續執行
        // OnCollisionExit  碰撞結束執行一次

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // print($"<color=#6f3>碰到的物件：{collision.gameObject.name}</color>");

            // 如果碰到的物件的名稱有 "武器" 這兩個字 就受傷
            if (collision.gameObject.name.Contains(weaponName)) 
            {
                Damage(150);
            }
        }

        // 使用關鍵字 override 可以覆寫父類別有 virtual 的成員
        protected override void Dead()
        {
            // base 父類別原有的內容，可選擇刪除
            base.Dead();

            print($"<color=#f66>生成爆炸特效</color>");

            // 刪除此物件
            Destroy(gameObject);
        }
    }
}