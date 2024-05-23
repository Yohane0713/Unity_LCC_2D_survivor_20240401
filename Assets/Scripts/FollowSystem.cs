using UnityEngine;

namespace MTaka
{
    /// <summary>
    /// 跟隨系統
    /// </summary>
    public class FollowSystem : MonoBehaviour
    {
        [SerializeField, Header("目標物件")]
        private Transform target;
        [SerializeField, Header("上下位移"), Range(-5, 5)]
        private float offsetY;

        private void Update()
        {
            Follow();
        }

        private void Follow()
        {
            transform.position = target.position + Vector3.up * offsetY;
        }
    }
}