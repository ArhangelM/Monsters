using Tools.Extensions;
using UnityEngine;

namespace Assets.Monsters.Scripts.Runtime.Camera
{
    internal class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target; 
        [SerializeField] private Vector3 offset; 
        [SerializeField] private float smoothSpeed = 0.005f; 

        private void LateUpdate()
        {
            if (!target.HasValue()) 
                return;

            Vector3 desiredPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, -1);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
