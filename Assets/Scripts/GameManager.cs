using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace MTaka
{
    /// <summary>
    /// 遊戲管理器
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        #region 常數資料
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
        #endregion

        [SerializeField, Header("玩家血量系統")]
        private HpPlayer hpPlayer;
        [SerializeField, Header("畫布結束畫面")]
        private CanvasGroup groupFinal;

        private Button btnReplay, btnQuit;

        private void Awake()
        {
            btnReplay = GameObject.Find("按鈕重新遊戲").GetComponent<Button>();
            btnQuit = GameObject.Find("按鈕結束遊戲 ").GetComponent<Button>();
            hpPlayer.onDead += ShowFinalCanvas;
        }

        /// <summary>
        /// 顯示結束畫面
        /// </summary>
        private void ShowFinalCanvas(object sender, System.EventArgs e)
        {
            StartCoroutine(FadeCanvas());
        }

        /// <summary>
        /// 淡入畫布
        /// </summary>
        private IEnumerator FadeCanvas() 
        {
            yield return new WaitForSeconds(1f);

            for (int i = 0; i < 10 ; i++)
            {
                // 透明度遞增 0.1
                groupFinal.alpha += 0.1f;
                yield return new WaitForSeconds(0.05f);
            }

            // 畫布群組勾選互動 與 滑鼠射線遮擋
            groupFinal.interactable = true;
            groupFinal.blocksRaycasts = true;
        }

        private void Replay()
        {
            //場景管理器，載入場景(當前啟動的場景名稱)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void Quit()
        {
            // 僅在執行檔有副作用 (exe APK)
            Application.Quit();
        }
    }
}