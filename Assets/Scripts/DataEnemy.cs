using UnityEngine;

namespace MTaka
{
    /// <summary>
    /// 敵人資料
    /// </summary>
    [CreateAssetMenu(menuName = "MTaka/Enemy")]
    public class DataEnemy : ScriptableObject
    {
        [Header("移動速度"), Range(0, 20)]
        public float moveSpeed;
        [Header("血量"), Range(0, 100000)]
        public float hp;
        [Header("攻擊力"), Range(0, 10000)]
        public float attack;
        [Header("經驗值預製物")]
        public GameObject prefabExp;
        [Header("經驗值掉落機率"), Range(0, 1)]
        public float expProbability;
    }
}