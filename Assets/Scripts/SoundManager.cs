using UnityEngine;

namespace MTaka
{
    /// <summary>
    /// 音效管理器
    /// </summary>
    // 要求元件 (類型(音效來源)) - 在首次添加此元件時會執行
    [RequireComponent(typeof(AudioSource))]
    public class SoundManager : MonoBehaviour
    {
        // 單例模式 (屬性)
        public static SoundManager instance
        {
            get
            {
                // 如果單例模式為空值 就尋找場景上的SoundManager
                if (_instance == null) return FindObjectOfType<SoundManager>();
                return _instance;
            }
        }
        // 單例模式欄位
        private static SoundManager _instance;

        [Header("音效")]
        [SerializeField] private AudioClip soundKnife;
        [SerializeField] private AudioClip soundBounce;
        [SerializeField] private AudioClip soundEnemyHitCreature;
        [SerializeField] private AudioClip soundEnemyHitBone;
        [SerializeField] private AudioClip soundEnemyDeadSingleEye;
        [SerializeField] private AudioClip soundEnemyDeadGoblin;
        [SerializeField] private AudioClip soundEnemyDeadSkull;
        [SerializeField] private AudioClip soundEnemyDeadBoss;
        [SerializeField] private AudioClip soundPlayerHit;
        [SerializeField] private AudioClip soundPlayerDead;
        [SerializeField] private AudioClip soundWinIntro;
        [SerializeField] private AudioClip soundWin;
        [SerializeField] private AudioClip soundLose;

        private AudioSource aud;
        private GameObject soundBattle;

        private void Awake()
        {
            aud = GetComponent<AudioSource>();
            soundBattle = GameObject.Find("BGM_戰鬥");
        }

        /// <summary>
        /// 播放音效(隨機音量)
        /// </summary>
        /// <param name="soundType">音效類型</param>
        /// <param name="min">最小音量</param>
        /// <param name="max">最大音量</param>
        public void PlaySound(SoundType soundType, float min = 0.6f, float max = 1.2f)
        {
            float volume = Random.Range(min, max);
            aud.PlayOneShot(GetSound(soundType), volume);
        }

        /// <summary>
        /// 獲得音效
        /// </summary>
        /// <param name="soundType">音效類型</param>
        private AudioClip GetSound(SoundType soundType)
        {
            return soundType switch
            {
                SoundType.Knife => soundKnife,
                SoundType.Bounce => soundBounce,
                SoundType.EnemyHitCreature => soundEnemyHitCreature,
                SoundType.EnemyHitBone => soundEnemyHitBone,
                SoundType.EnemyDeadSingleEye => soundEnemyDeadSingleEye,
                SoundType.EnemyDeadGoblin => soundEnemyDeadGoblin,
                SoundType.EnemyDeadSkull => soundEnemyDeadSkull,
                SoundType.EnemyDeadBoss => soundEnemyDeadBoss,
                SoundType.PlayerHit => soundPlayerHit,
                SoundType.PlayerDead => soundPlayerDead,
                SoundType.WinIntro => soundWinIntro,
                SoundType.Win => soundWin,
                SoundType.Lose => soundLose,
                _ => null
            };
        }

        /// <summary>
        /// 播放音效(固定音量時) 多載
        /// </summary>
        /// <param name="soundType">音效類型</param>
        public void PlaySound(SoundType soundType)
        {
            aud.PlayOneShot(GetSound(soundType));
        }

        public void StopSoundBattle()
        {
            soundBattle.GetComponent<AudioSource>().Stop();
        }

        /// <summary>
        /// 音效類型
        /// </summary>
        public enum SoundType
        {
            None, Knife, Bounce, EnemyHitCreature, EnemyHitBone, EnemyDeadSingleEye, EnemyDeadGoblin,
            EnemyDeadSkull, EnemyDeadBoss, PlayerHit, PlayerDead, WinIntro, Win, Lose
        }
    }
}