using UnityEngine;

namespace MTaka
{
    /// <summary>
    /// 玩家資料
    /// </summary>
    [CreateAssetMenu(menuName = "MTaka/Player")]
    public class DataPlayer : ScriptableObject
    {
        [Header("血量"), Range(0, 5000000)]
        public float hp;
    }
}