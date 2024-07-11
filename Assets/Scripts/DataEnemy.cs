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
        [Header("血量"), Range(0, 1000000)]
        public float hp;
        [Header("攻擊力"), Range(0, 100000)]
        public float attack;
        [Header("經驗值預製物")]
        public GameObject prefabExp;
        [Header("經驗值掉落機率"), Range(0, 1)]
        public float expProbability;
        [Header("攻擊範圍"), Range(0, 10)]
        public float attackRange;
        [Header("攻擊前搖"), Range(0, 3)]
        public float attackBefore;
        [Header("攻擊後搖"), Range(0, 3)]
        public float attackAfter;
        [Header("攻擊區域尺寸")]
        public Vector3 attackAreaSize = Vector3.one;
        [Header("攻擊區域位移")]
        public Vector3 attackAreaOffset;
    }
}