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
        [SerializeField, Header("武器系統")]
        private WeaponSystem weaponSystem;

        private void Awake()
        {
            dataWeapon.weaponLv = 1;
        }

        public void Upgrade(float increase)
        {
            print($"<color=#f63>升級武器：{dataWeapon.name}</color>");
            dataWeapon.weaponLv++;
            weaponSystem.RestartSpawnWeapon();
        }
    }
}