using UnityEngine;

namespace MTaka
{
    /// <summary>
    /// 升級暴擊率
    /// </summary>
    public class UpgradeCriticalRate : UpgradePlayer
    {
        public override void InitializePlayerData(float value)
        {
            base.InitializePlayerData(value);
            dataPlayer.criticalRate = value;
        }

        public override void Upgrade(float increase)
        {
            base.Upgrade(increase);
            dataPlayer.criticalRate += increase;
        }
    }
}