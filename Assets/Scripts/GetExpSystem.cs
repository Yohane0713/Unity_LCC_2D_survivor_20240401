using UnityEngine;

namespace MTaka
{
    /// <summary>
    /// 獲得經驗值系統
    /// </summary>
    public class GetExpSystem : MonoBehaviour
    {
        private string expName = "經驗值";

        private void OnTriggerEnter2D(Collider2D collision)
        {
            // print($"<color=#36f>碰到的物件：{collision.name}</color>");
            // 如果碰到物件名稱包含 經驗值 就開啟 經驗值物件 元件
            if (collision.name.Contains(expName))
                collision.GetComponent<ExpObject>().enabled = true;
        }
    }
}