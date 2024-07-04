using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace MTaka
{
    /// <summary>
    ///  開始遊戲管理器
    /// </summary>
    public class StartGameManager : MonoBehaviour
    {
        private Button btnStart, btnQuit;
        private string gameSceneName = "遊戲場景";

        private void Awake()
        {
            btnStart = GameObject.Find("按鈕開始遊戲").GetComponent<Button>();
            btnQuit = GameObject.Find("按鈕離開遊戲 ").GetComponent<Button>();
            btnStart.onClick.AddListener(StartGame);
            btnQuit.onClick.AddListener(QuitGame);
        }

        private void StartGame()
        {
            SceneManager.LoadScene(gameSceneName);
        }

        private void QuitGame()
        {
            Application.Quit();
        }
    }
}