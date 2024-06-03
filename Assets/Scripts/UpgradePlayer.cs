using UnityEngine;

namespace MTaka
{
    /// <summary>
    /// 升級玩家
    /// </summary>
    public class UpgradePlayer : MonoBehaviour, IUpgrade
    {
        [SerializeField, Header("玩家資料")]
        protected DataPlayer dataPlayer;

        public virtual void InitializePlayerData(float value)
        {

        }

        public virtual void Upgrade(float increase)
        {
            
        }
    }
}