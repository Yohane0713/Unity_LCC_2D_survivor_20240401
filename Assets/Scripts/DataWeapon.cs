using UnityEngine;

namespace MTaka
{
    /// <summary>
    /// 武器資料
    /// </summary>
    // 腳本化物件 Scriptable Object 將腳本變成物件存放在 Project裡面 方便進行管理
    [CreateAssetMenu(menuName = "MTaka/Weapon")]
    public class DataWeapon : ScriptableObject
    {
        [Header("武器預製物")]
        public GameObject weaponPrefab;
        [Header("武器等級"), Range(1, 10)]
        public int weaponLv = 1;
        [Header("武器數值：各個等級")]
        public WeaponValue[] weaponValues;
    }
    /// <summary>
    /// 武器數值
    /// </summary>
    // 針對Class 的序列化
    [System.Serializable]
    public class WeaponValue
    {
        [Header("武器生成點")]
        public Vector3[] weaponPoint;
        [Header("武器生成間隔"), Range(0, 5)]
        public float weaponInterva;
        [Header("武器飛行速度"), Range(0 ,5000)]
        public float weaponSpeed;
        [Header("武器攻擊力"), Range(0, 50000)]
        public float weaponAttack;
    }
}