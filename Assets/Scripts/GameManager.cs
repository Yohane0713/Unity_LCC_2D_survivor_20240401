using UnityEngine;

namespace MTaka
{
    /// <summary>
    /// 遊戲管理器
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        // const 常數：不變的資料，常數資料不需放在物件上就可存取
        /// <summary>
        /// 玩家的物件名稱
        /// </summary>
        public const string playerName = "玩家_盜賊";
        /// <summary>
        /// 動畫控制器參數：移動數值
        /// </summary>
        public const string parMove = "移動數值";
        /// <summary>
        /// 動畫控制器參數：攻擊
        /// </summary>
        public const string parAttack = "觸發攻擊";
    }
}