using System.Collections;
using UnityEngine;

namespace MTaka
{
    /// <summary>
    /// 波數管理器
    /// </summary>
    public class WaveManager : MonoBehaviour
    {
        [SerializeField, Header("此關卡波數資料")]
        private DataWave dataWave;

        private void OnDrawGizmos()
        {
            if (dataWave == null) return;

            for (int i = 0; i < dataWave.waves.Length; i++)
            {
                Wave wave = dataWave.waves[i];
                if (!wave.drawGizmos) continue;
                Gizmos.color = wave.gizmosColor;

                for(int j = 0; j < wave.pointEnemies.Length; j++)
                {
                    Gizmos.DrawSphere(transform.position + wave.pointEnemies[j], 0.1f);
                }
            }
        }

        private void Awake()
        {
            StartCoroutine(StartWave());
        }

        private IEnumerator StartWave()
        {
            for (int i = 0; i < dataWave.waves.Length; i++)  // 迴圈執行每一波
            {
                Wave wave = dataWave.waves[i];  // 獲得每一波的資料
                float time = wave.duration;  // 獲得每一波的時間
                while (time > 0)  // 時間 > 0 持續生成
                {
                    for (int j = 0; j < wave.prefabEnemies.Length; j++) // 生成每波的每隻敵人
                        SpawnEnemy(wave.prefabEnemies[j], wave.pointEnemies[j]);
                    yield return new WaitForSeconds(wave.interval); // 等待生成間隔
                    time -= wave.interval;  // 生成後時間遞減
                }
                yield return new WaitForSeconds(time);  // 等待剩餘時間
            }
        }

        private void SpawnEnemy(GameObject enemy, Vector3 point)
        {
            Instantiate(enemy, point, Quaternion.identity);
        }
    }

    
}