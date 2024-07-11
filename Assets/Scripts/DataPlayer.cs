using UnityEngine;

namespace MTaka
{
    /// <summary>
    /// 玩家資料
    /// </summary>
    [CreateAssetMenu(menuName = "MTaka/Player")]
    public class DataPlayer : ScriptableObject
    {
        [Header("移動速度"), Range(0, 20)]
        public float moveSpeed = 3.5f;
        [Header("跳躍力道"), Range(0, 1500)]
        public float jump = 450;
        [Header("血量"), Range(0, 5000000)]
        public float hp = 200;
        [Header("獲得經驗值範圍"), Range(0, 20)]
        public float getExpRaduis = 3;
        [Header("暴擊率"), Range(0, 1)]
        public float criticalRate = 0.3f;
    }
}