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
        [SerializeField, Header("爆炸特效")]
        private GameObject prefabExplosion;

        private string weaponName = "武器";

        protected virtual void Awake()
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
                // 造成武器攻擊力的傷害
                Damage(collision.gameObject.GetComponent<Weapon>().attack);
            }
        }

        public override void Damage(float damage)
        {
            base.Damage(damage);
            if (dataEnemy.name.Contains("獨眼怪") || dataEnemy.name.Contains("哥布林") || dataEnemy.name.Contains("蘑菇人"))
                SoundManager.instance.PlaySound(SoundManager.SoundType.EnemyHitCreature, 0.6f, 1);
            else if (dataEnemy.name.Contains("骷髏怪"))
                SoundManager.instance.PlaySound(SoundManager.SoundType.EnemyHitBone);
        }

        // 使用關鍵字 override 可以覆寫父類別有 virtual 的成員
        protected override void Dead()
        {
            // base 父類別原有的內容，可選擇刪除
            base.Dead();

            // print($"<color=#f66>生成爆炸特效</color>");
            GameObject tempExplosion = Instantiate(prefabExplosion, transform.position, Quaternion.identity);
            // 刪除此物件
            Destroy(gameObject);
            Destroy(tempExplosion, 1.5f);

            DropExpObject();
            if (dataEnemy.name.Contains("獨眼怪"))
                SoundManager.instance.PlaySound(SoundManager.SoundType.EnemyDeadSingleEye);
            else if (dataEnemy.name.Contains("哥布林"))
                SoundManager.instance.PlaySound(SoundManager.SoundType.EnemyDeadGoblin);
            else if (dataEnemy.name.Contains("骷髏怪"))
                SoundManager.instance.PlaySound(SoundManager.SoundType.EnemyDeadSkull);
        }

        /// <summary>
        /// 掉落經驗值物件
        /// </summary>
        private void DropExpObject()
        {
            // 如果隨機值 < 掉落機率
            if (Random.value < dataEnemy.expProbability)
            {
                // 生成 經驗值物件 在敵人身上
                Instantiate(dataEnemy.prefabExp, transform.position, Quaternion.identity);
            }
        }
    }
}