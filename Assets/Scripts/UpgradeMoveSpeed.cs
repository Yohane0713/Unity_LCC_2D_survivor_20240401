using UnityEngine;

namespace MTaka
{
    /// <summary>
    /// 升級移動速度
    /// </summary>
    public class UpgradeMoveSpeed : UpgradePlayer
    {
        public override void InitializePlayerData(float value)
        {
            base.InitializePlayerData(value);
            dataPlayer.moveSpeed = value;
        }

        public override void Upgrade(float increase)
        {
            base.Upgrade(increase);
            dataPlayer.moveSpeed += increase;
        }
    }
}