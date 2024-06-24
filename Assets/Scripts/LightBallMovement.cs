using DG.Tweening;
using UnityEngine;

namespace MTaka
{
    /// <summary>
    /// 光球移動
    /// </summary>
    public class LightBallMovement : MonoBehaviour
    {
        [SerializeField, Header("要移動的目的地")]
        private Vector3 pointTarget;
        [SerializeField, Header("移動時間"), Range(1, 10)]
        private float moveDuration = 2.5f;

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0.4f, 1, 0.5f, 0.3f);
            Gizmos.DrawSphere(
                transform.position +
                transform.TransformDirection(pointTarget), 0.1f);
        }

        private void Awake()
        {
            transform.DOMove(
                transform.position +
                transform.TransformDirection(pointTarget),
                moveDuration).SetEase(Ease.InCirc);
        }
    }
}