using Cinemachine;
using UnityEngine;

namespace MTaka
{
    /// <summary>
    /// 敵人系統：BOSS
    /// </summary>
    public class EnemyBoss : EnemySystem
    {
        protected override void Awake()
        {
            base.Awake();
            HpBoss.instance.onSecondState += SecondState;
        }

        private void SecondState(object sender, System.EventArgs e)
        {
            ShakeCamera.instance.Shake(3, 1.5f);
        }
    }
}