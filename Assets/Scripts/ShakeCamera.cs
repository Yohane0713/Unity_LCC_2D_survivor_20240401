using UnityEngine;
using Cinemachine;
using System.Collections;

namespace MTaka
{
    /// <summary>
    /// 晃動攝影機
    /// </summary>
    public class ShakeCamera : MonoBehaviour
    {
        public static ShakeCamera instance;

        private CinemachineVirtualCamera virtualCamera;
        private CinemachineBasicMultiChannelPerlin perlin;

        private void Awake()
        {
            instance = this;
            virtualCamera = GetComponent<CinemachineVirtualCamera>();
            perlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }

        /// <summary>
        /// 晃動攝影機
        /// </summary>
        public void Shake(float intensity, float time)
        {
            perlin.m_AmplitudeGain = intensity;
            StartCoroutine(StartShake(time));
        }

        /// <summary>
        /// 開始晃動
        /// </summary>
        /// <param name="time">晃動時間</param>
        public IEnumerator StartShake(float time)
        {
            yield return new WaitForSeconds(time);
            perlin.m_AmplitudeGain = 0;
        }
    }
}