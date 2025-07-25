using Assets.Monsters.Scripts.Runtime.Interaction.Common;
using ArhTools.Extensions;
using UnityEngine;

namespace Assets.Monsters.Scripts.Runtime.Player
{
    internal class CharacterInteraction : MonoBehaviour
    {
        private Collider2D _checker;
        private IInteraction _interactionComponent;

        private bool _isInteractable = false;

        private void Awake()
        {
            InitComponent();
        }

        private void Update()
        {
            if (_isInteractable && Input.GetKeyDown(KeyCode.E) && _interactionComponent.HasValue())
            {
                _interactionComponent.Interact();
            }

            if (_isInteractable && Input.GetKeyUp(KeyCode.E) && _interactionComponent.HasValue())
            {
                _interactionComponent.Undo();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Undo();  // Reset interaction component to null before checking

            if (collision.TryGetComponent(out _interactionComponent))
            {
                Debug.Log($"Interaction with: {collision.name}");
                _isInteractable = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            Undo();
        }

        private void InitComponent()
        {
            _checker = gameObject.AddComponent<CircleCollider2D>();
            _checker.isTrigger = true;
        }

        private void Undo()
        {
            if (_interactionComponent.HasValue())
                _interactionComponent.Undo();
        }
    }
}
