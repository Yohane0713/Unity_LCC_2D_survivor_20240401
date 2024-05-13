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
    }
}