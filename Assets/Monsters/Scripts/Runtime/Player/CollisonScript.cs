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
        }
    }
}
