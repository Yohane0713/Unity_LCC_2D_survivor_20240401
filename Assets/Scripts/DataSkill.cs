﻿using UnityEngine;

namespace MTaka
{
    /// <summary>
    /// 技能資料
    /// </summary>
    [CreateAssetMenu(menuName = "MTaka/Skill")]
    public class DataSkill : ScriptableObject
    {
        [Header("技能名稱")]
        public string skillName;
        [Header("技能等級"), Range(1, 10)]
        public int skillLv;
        [Header("技能圖片")]
        public Sprite skillSprite;
        [Header("技能提升說明")]
        public string skillUpgrade;
        [Header("技能描述"), TextArea(2 , 5)]
        public string skillDescription;
    }
}
