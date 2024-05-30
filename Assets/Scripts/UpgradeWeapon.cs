using UnityEngine;

namespace MTaka
{
    /// <summary>
    /// 升級武器
    /// </summary>
    public class UpgradeWeapon : MonoBehaviour, IUpgrade
    {
        [SerializeField, Header("武器資料")]
        private DataWeapon dataWeapon;

        public void Upgrade(float increase)
        {
            
        }
    }
}