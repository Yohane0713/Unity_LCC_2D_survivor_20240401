using System;
using UnityEngine;

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

        private void Awake()
        {
            hp = dataPlayer.hp;
            ani = GetComponent<Animator>();
        }

        protected override void Dead()
        {
            base.Dead();
            ani.SetTrigger(parDead);
            // 事件如果不為空值 就呼叫(發事件的此物件, 空值)
            onDead?.Invoke(this, null);
        }
    }
}