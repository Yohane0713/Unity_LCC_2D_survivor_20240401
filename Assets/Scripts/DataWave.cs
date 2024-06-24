using UnityEngine;

namespace MTaka
{
    /// <summary>
    /// 波數資料
    /// </summary>
    [CreateAssetMenu(menuName = "MTaka/Wave")]
    public class DataWave : ScriptableObject
    {
        [Header("所有波數資料")]
        public Wave[] waves;
    }

    /// <summary>
    /// 波數
    /// </summary>
    [System.Serializable]
    public class Wave
    {
        [Header("持續時間"), Range(0, 300)]
        public float duration;
        [Header("生成間隔"), Range(0, 3)]
        public float interval;
        [Header("要生成的敵人")]
        public GameObject[] prefabEnemies;
        [Header("敵人生成位置")]
        public Vector3[] pointEnemies;
        [Header("是否繪製圖示")]
        public bool drawGizmos = true;
        [Header("圖示顏色")]
        public Color gizmosColor = new Color(1, 1, 1, 0.5f);
    }
}