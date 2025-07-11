using Assets.Monsters.Scripts.Common;
using UnityEngine;

namespace Assets.Monsters.Scripts.Runtime.Player
{
    [RequireComponent(typeof(Collider2D))]
    internal class CollisonScript : MonoBehaviour
    {
        [SerializeField] private LayerMask _collisionLayerMask;
        [SerializeField] private bool _useMask;
        public bool IsCollission { get; private set; } = false;
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(_useMask)
            {
                if (Misc.IsInLayerMask(collision.gameObject.layer, _collisionLayerMask))
                {
                    IsCollission = true;
                }
            }
            else
                IsCollission = true;

            Debug.Log($"Collision Entered: {collision.gameObject.name} with mask {_useMask}");
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (_useMask)
            {
                if (Misc.IsInLayerMask(collision.gameObject.layer, _collisionLayerMask))
                {
                    IsCollission = false;
                }
            }
            else
                IsCollission = false;

            Debug.Log($"Collision Exit: {collision.gameObject.name} with mask {_useMask}");
        }
    }
}
