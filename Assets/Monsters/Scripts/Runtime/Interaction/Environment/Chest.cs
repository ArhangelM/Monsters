using Assets.Monsters.Scripts.Runtime.Interaction.Common;
using UnityEngine;

namespace Assets.Monsters.Scripts.Runtime.Interaction.Environment
{
    [RequireComponent(typeof(Animator))]
    internal class Chest : InteractionObject
    {
        [SerializeField] private Animator _animator;

        private bool _isOpened = false;

        public override void Interact()
        {
            if (_isInteractable)
            {
                if (!_isOpened)
                {
                    _animator.SetBool("Open", true);
                    _isOpened = true;
                }
                else
                {
                    Debug.Log("Chest is already opened.");
                }
            }
        }
    }
}
