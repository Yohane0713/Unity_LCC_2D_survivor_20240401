using UnityEngine;

namespace MTaka
{
    /// <summary>
    /// 升級玩家
    /// </summary>
    public class UpgradePlayer : MonoBehaviour, IUpgrade
    {
        [SerializeField, Header("玩家資料")]
        private DataPlayer dataPlayer;

        public void Upgrade(float increase)
        {
            
        }
    }
}