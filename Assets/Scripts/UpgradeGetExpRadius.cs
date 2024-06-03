using UnityEngine;

namespace MTaka
{
    /// <summary>
    /// 升級獲得經驗值範圍
    /// </summary>
    public class UpgradeGetExpRadius : UpgradePlayer
    {
        [SerializeField, Header("獲得經驗值系統：圖形碰撞器")]
        private CircleCollider2D getExpCollider;

        public override void InitializePlayerData(float value)
        {
            base.InitializePlayerData(value);
            dataPlayer.getExpRaduis = value;
        }

        public override void Upgrade(float increase)
        {
            base.Upgrade(increase);
            dataPlayer.getExpRaduis += increase;
            getExpCollider.radius = dataPlayer.getExpRaduis;
        }
    }
}