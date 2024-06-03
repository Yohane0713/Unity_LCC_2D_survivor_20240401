using UnityEngine;

namespace MTaka
{
    /// <summary>
    /// 升級血量
    /// </summary>
    public class UpgradeHp : UpgradePlayer
    {
        [SerializeField, Header("血量系統：玩家")]
        private HpPlayer hpPlayer;

        public override void InitializePlayerData(float value)
        {
            base.InitializePlayerData(value);
            dataPlayer.hp = value;
        }

        public override void Upgrade(float increase)
        {
            base.Upgrade(increase);
            dataPlayer.hp *= increase;
            hpPlayer.ResetHp(dataPlayer.hp);
        }
    }
}