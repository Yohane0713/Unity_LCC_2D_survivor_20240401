using UnityEngine;
using static MTaka.SoundManager;

namespace MTaka
{
    /// <summary>
    /// 武器系統
    /// </summary>
    public class WeaponSystem : MonoBehaviour
    {
        [SerializeField, Header("武器資料")]
        private DataWeapon dataWeapon;
        [SerializeField, Header("玩家血量系統")]
        private HpPlayer hpPlayer;

        /// <summary>
        /// 取得當前武器數值
        /// </summary>
        private WeaponValue weaponCurrentLv => dataWeapon.weaponValues[dataWeapon.weaponLv - 1];

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1, 0.8f, 0.3f, 0.5f);

            for (int i = 0; i < weaponCurrentLv.weaponPoint.Length; i++)
            {
                // transform.TransformDirection 世界空間與區域空間的轉換
                Gizmos.DrawSphere(
                    transform.position +
                    transform.TransformDirection(weaponCurrentLv.weaponPoint[i]), 0.2f);
            }

        }

        private void Awake()
        {
            // SpawnWeapon(); //呼叫一次只能生成一個武器
            // 重複呼叫方法(方法名稱, 延遲時間, 重複頻率)
            InvokeRepeating("SpawnWeapon", 0, weaponCurrentLv.weaponInterva);

            // 訂閱事件
            hpPlayer.onDead += CloseWeaponSystem;
        }

        private void CloseWeaponSystem(object sender, System.EventArgs e)
        {
            // 取消重複呼叫方法
            CancelInvoke("SpawnWeapon");
        }

        /// <summary>
        /// 生成武器
        /// </summary>
        private void SpawnWeapon()
        {
            for (int i = 0; i < weaponCurrentLv.weaponPoint.Length; i++)
            {
                // 先設定右邊和左邊的武器角度
                int rightWeapon = 0, leftWeapon = 180;
                // 玩家面對方向 = 根物件的變形元件(相對武器的根物件就是玩家)的角度的旋轉y軸
                // 旋轉y軸若等於0 表示玩家面向右邊 若不等於0 表示玩家面向左邊 
                int direction = transform.root.eulerAngles.y == 0 ? 1 : -1;
                // 如果玩家面向右邊
                if (direction == 1)
                {
                    rightWeapon = 0;
                    leftWeapon = 180;
                }
                // 如果玩家面向右邊
                if (direction == -1)
                {
                    rightWeapon = 180;
                    leftWeapon = 0;
                }
                // 角度 = 武器生成點座標的 x 如果大於 0 就是右邊的武器 否則就是左邊的武器
                float angle = weaponCurrentLv.weaponPoint[i].x > 0 ? rightWeapon : leftWeapon;

                // 物件 = 生成(物件，座標，角度) 會傳回物件
                // 零度角 Quaternion.identity 代表角度 0, 0, 0
                GameObject tempWeapon = Instantiate(
                    dataWeapon.weaponPrefab,
                    transform.position +
                    transform.TransformDirection(weaponCurrentLv.weaponPoint[i]),
                    Quaternion.Euler(0, 0, angle));

                // 獲得生成暫存武器 剛體 往前產生推力
                tempWeapon.GetComponent<Rigidbody2D>().AddForce(
                    weaponCurrentLv.weaponSpeed * tempWeapon.transform.right);

                // 暫存武器 的 武器攻擊力 = 當前武器等級的攻擊力
                tempWeapon.GetComponent<Weapon>().attack = weaponCurrentLv.weaponAttack;

                PlaySound();
            }
        }

        private void PlaySound()
        {
            if (dataWeapon.name.Contains("飛刀")) SoundManager.instance.PlaySound(SoundType.Knife, 0.6f, 0.6f);
            else if (dataWeapon.name.Contains("彈跳武器")) SoundManager.instance.PlaySound(SoundType.Bounce, 0.6f, 0.6f);
        }

        /// <summary>
        /// 重新開始生成武器：為了重置生成間隔
        /// </summary>
        public void RestartSpawnWeapon()
        {
            CancelInvoke("SpawnWeapon");
            InvokeRepeating("SpawnWeapon", 0, weaponCurrentLv.weaponInterva);
        }
    }
}