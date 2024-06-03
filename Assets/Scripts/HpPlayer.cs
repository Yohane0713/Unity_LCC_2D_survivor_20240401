using System;
using UnityEngine;
using UnityEngine.UI;

namespace MTaka
{
    /// <summary>
    /// 血量系統：玩家
    /// </summary>
    public class HpPlayer : HpSystem
    {
        [SerializeField, Header("玩家資料")]
        private DataPlayer dataPlayer;

        /// <summary>
        /// 死亡事件
        /// </summary>
        public event EventHandler onDead;

        private Animator ani;
        private string parDead = "觸發死亡";
        /// <summary>
        /// 圖片血條
        /// </summary>
        private Image imgHp;
        private float hpMax;

        private void Awake()
        {
            hp = dataPlayer.hp;
            hpMax = hp;
            ani = GetComponent<Animator>();
            // 用 GameObject.Find 搜尋場景物件時，場景上的物件名稱不能重複
            imgHp = GameObject.Find("圖片血條").GetComponent<Image>();
        }

        public override void Damage(float damage)
        {
            base.Damage(damage);
            imgHp.fillAmount = hp / hpMax;
        }

        protected override void Dead()
        {
            base.Dead();
            ani.SetTrigger(parDead);
            // 事件如果不為空值 就呼叫(發事件的此物件, 空值)
            onDead?.Invoke(this, null);
        }

        /// <summary>
        /// 重設血量並更新介面
        /// </summary>
        /// <param name="_hp">要重設的血量</param>
        public void ResetHp(float _hp)
        {
            hp = _hp;
            hpMax = _hp;
            imgHp.fillAmount = 1;
        }
    }
}