using UnityEngine;

namespace MTaka
{
    /// <summary>
    /// 武器物件
    /// </summary>
    public class Weapon : MonoBehaviour
    {
        // Hide In Inspector 在屬性面板隱藏，可以將不想要顯示的資料隱藏
        [HideInInspector]
        public float attack;

        private void Start()
        {
            // 如果暴擊 攻擊就變2倍
            attack = Random.value <= 0.3f ? attack * 2 : attack;
            // 用技能升級暴擊率的寫法
            // attack = Random.value <= UpgradeCriticalRate.instance.criticalRate ? attack * 2 : attack;
            // 浮動攻擊力 20%
            attack += Mathf.Floor(Random.Range(0, attack * 0.2f));
        }
    }
}