using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;

namespace MTaka
{
    /// <summary>
    /// 技能管理器：技能資料與技能介面管理
    /// </summary>
    // 預設執行順序：腳本預設執行順序，數字愈大愈慢執行
    [DefaultExecutionOrder(100)]
    public class SkillManager : MonoBehaviour
    {
        #region 資料區域
        [SerializeField, Header("技能資料")]
        private DataSkill[] dataSkills;
        [SerializeField, Header("畫布升級畫面")]
        private CanvasGroup groupUpgrade;
        [SerializeField, Header("按鈕技能 1 ~ 3")]
        private Button[] btnSkills;

        /// <summary>
        /// 洗牌後的技能資料
        /// </summary>
        [SerializeField]
        private List<DataSkill> dataSkillShuffle;
        [SerializeField, Header("圖片等級：顯示的顏色")]
        private Color colorSkillLvShow;
        [SerializeField, Header("圖片等級：隱藏的顏色")]
        private Color colorSkillLvHide;

        private string nameTextSkill = "文字技能名稱";
        private string nameImageSkill = "圖片技能圖片";
        private string nameTxetUpgradeDescription = "文字技能提升說明";
        private string nameTextDescription = "文字技能描述";
        private string nameGroupLv = "圖片等級";
        private string nameImageLv = "圖片等級_";
        #endregion

        /// <summary>
        /// 玩家點擊按鈕的編號
        /// </summary>
        private int btnPlayerClickIndex;

        private void Awake()
        {
            ExpManager.instance.onUpgrade += PlayerUpgrade;
            ResetSkillLv();
            ButtonClickEvent();
        }

        /// <summary>
        /// 玩家升級
        /// </summary>
        private void PlayerUpgrade(object sender, System.EventArgs e)
        {
            // 時間.時間尺寸 = 0 (時間暫停)
            Time.timeScale = 0;
            ShuffleAndGetSkillData();
            UpdateSkillUI();
            StartCoroutine(FadeGroupUpgrade());
        }

        /// <summary>
        /// 淡入淡出升級畫面
        /// </summary>
        private IEnumerator FadeGroupUpgrade(bool fadeIn = true)
        {
            float increase = fadeIn ? +0.2f : -0.2f;

            for (int i = 0; i < 5; i++)
            {
                groupUpgrade.alpha += increase;
                // WaitForSecondsRealtime 等待真實時間，不會被暫停
                yield return new WaitForSecondsRealtime(0.07f);
            }

            groupUpgrade.interactable = fadeIn;
            groupUpgrade.blocksRaycasts = fadeIn;
        }

        /// <summary>
        /// 洗牌並獲得技能資料：獲得等級10以下的資料
        /// </summary>
        private void ShuffleAndGetSkillData()
        {
            // 獲得等級10以下的資料
            var dataSkillLess10 = dataSkills.Where(skill => skill.skillLv < 10);
            // 洗牌
            dataSkillShuffle = dataSkillLess10.OrderBy(skill => Random.Range(0, 999)).ToList();
        }

        /// <summary>
        /// 更新技能介面
        /// </summary>
        private void UpdateSkillUI()
        {
            for (int i = 0; i < btnSkills.Length; i++)
            {
                DataSkill data = dataSkillShuffle[i];
                btnSkills[i].transform.Find(nameTextSkill).GetComponent<TMP_Text>().text = data.skillName;
                btnSkills[i].transform.Find(nameImageSkill).GetComponent<Image>().sprite = data.skillSprite;
                btnSkills[i].transform.Find(nameTxetUpgradeDescription).GetComponent<TMP_Text>().text = data.skillUpgrade;
                btnSkills[i].transform.Find(nameTextDescription).GetComponent<TMP_Text>().text = data.skillDescription;
                UpdateSkillLvSprite(i, data.skillLv);
            }
        }

        /// <summary>
        /// 更新技能圖片顏色
        /// </summary>
        /// <param name="btnIndex">按鈕編號</param>
        /// <param name="lv">等級</param>
        private void UpdateSkillLvSprite(int btnIndex, int lv)
        {
            for (int i = 1; i <= 10; i++)
            {
                btnSkills[btnIndex].transform.Find(nameGroupLv).Find(nameImageLv + i).GetComponent<Image>().color = colorSkillLvHide;
            }

            for (int i = 1; i <= lv; i++)
            {
                btnSkills[btnIndex].transform.Find(nameGroupLv).Find(nameImageLv + i).GetComponent<Image>().color = colorSkillLvShow;
            }
        }

        /// <summary>
        /// 按鈕點擊事件
        /// </summary>
        private void ButtonClickEvent()
        {
            for (int i = 0; i < btnSkills.Length; i++)
            {
                int index = i;

                btnSkills[i].onClick.AddListener(() =>
                {
                    btnPlayerClickIndex = index;
                    print($"<color=#96F>玩家點的按鈕編號：{btnPlayerClickIndex}</color>");
                    StartCoroutine(UpgradeSkillEffect());
                });
            }
        }

        /// <summary>
        /// 升級技能效果
        /// </summary>
        private IEnumerator UpgradeSkillEffect()
        {
            groupUpgrade.interactable = false;
            yield return new WaitForSecondsRealtime(0.5f);
            DataSkill dataPlayerClick = dataSkillShuffle[btnPlayerClickIndex];
            dataPlayerClick.skillLv++;
            UpdateSkillLvSprite(btnPlayerClickIndex, dataPlayerClick.skillLv);
            yield return new WaitForSecondsRealtime(0.5f);
            yield return StartCoroutine(FadeGroupUpgrade(false)); // 等待淡出升級畫面完後才繼續執行
            Time.timeScale = 1;                                   // 然後，時間繼續進行
        }

        /// <summary>
        /// 重設技能等級
        /// </summary>
        private void ResetSkillLv()
        {
            for (int i = 0; i < dataSkills.Length;i++)
            {
                dataSkills[i].skillLv = 1;
            }
        }
    }
}