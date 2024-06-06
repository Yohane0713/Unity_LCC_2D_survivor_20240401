using System;
using UnityEngine;

namespace MTaka
{
    /// <summary>
    /// 血量：敵人BOSS
    /// </summary>
    [DefaultExecutionOrder(-100)]
    public class HpBoss : HpEnemy
    {
        public static HpBoss instance;
        public event EventHandler onSecondState;

        [SerializeField, Header("血量剩餘多少進入狀態二"), Range(0, 1)]
        private float secondState = 0.5f;

        private float hpMax;
        private float secondHp => hpMax * secondState;

        // 是否已經入狀態二
        private bool inSecondState;

        protected override void Awake()
        {
            instance = this;
            base.Awake();
            hpMax = hp;
        }

        public override void Damage(float damage)
        {
            base.Damage(damage);
            SecondState();
        }

        protected void SecondState()
        {
            if (inSecondState) return;
            if (hp <= secondHp)
            {
                inSecondState = true;
                onSecondState?.Invoke(this, null);
                print("<color=#df3>進入狀態二</color>");
            }
        }
    }
}