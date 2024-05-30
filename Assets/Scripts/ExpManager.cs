using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace MTaka
{
    /// <summary>
    /// 經驗值管理器
    /// </summary>
    public class ExpManager : MonoBehaviour
    {
        // 單例模式需要的靜態實體資料
        public static ExpManager instance;

        /// <summary>
        /// 升級事件
        /// </summary>
        public event EventHandler onUpgrade;

        [SerializeField, Header("圖片經驗值")]
        private Image imgExp;
        [SerializeField, Header("文字經驗值")]
        private TMP_Text textExp;
        [SerializeField, Header("文字等級")]
        private TMP_Text textLv;

        /// <summary>
        /// 目前經驗值
        /// </summary>
        private float expCurrent;
        /// <summary>
        /// 還需要多少經驗值
        /// </summary>
        private float expNeed => expNeedTable[lv - 1];
        /// <summary>
        /// 等級
        /// </summary>
        private int lv = 1;

        private int lvMax = 100;


        /// <summary>
        /// 經驗值需求表格：所有等級的經驗值需求
        /// </summary>
        [SerializeField]
        private float[] expNeedTable;

        [ContextMenu("產生經驗值需求表格")]
        private void GeneratedExpNeedTable()
        {
            // 指定陣列的數量為等級最大值
            expNeedTable = new float[lvMax];

            for (int i = 0; i < lvMax; i++)
            {
                // 經驗值公式 等級需求為 等級*100
                expNeedTable[i] = (i + 1) * 100;
            }
        }

        private void Awake()
        {
            // 實體資料 = 此物件
            instance = this;
            UpdateUI();
        }

        private void Update()
        {

#if UNITY_EDITOR
            // #if UNITY_EDITOR 如果在編輯器內，此程式區塊才有作用
            TestAddExp();
#endif        
        }

            /// <summary>
            /// 添加經驗值
            /// </summary>
            /// <param name="exp">要增加的經驗值</param>
            public void AddExp(float exp)
        {
            expCurrent += exp;

            if (expCurrent >= expNeed)
            {
                expCurrent -= expNeed;
                Upgrade();
            }

            UpdateUI();
        }

        /// <summary>
        /// 更新介面
        /// </summary>
        private void UpdateUI()
        {
            imgExp.fillAmount = expCurrent / expNeed;
            textExp.text = $"{expCurrent}/{expNeed}";
        }

        /// <summary>
        /// 升級
        /// </summary>
        private void Upgrade()
        {
            lv++;
            textLv.text = $"Lv{lv}";
            onUpgrade?.Invoke(this, null);
        }

        /// <summary>
        /// 測試：添加經驗值
        /// </summary>
        private void TestAddExp()
        {
            // 如果按下左邊鍵盤數字1 就添加 100經驗值
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                AddExp(100);
            }
        }
    }
}