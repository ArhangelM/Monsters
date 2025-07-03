using Assets.Monsters.Scripts.Runtime.Interaction.Common;
using UnityEngine;

namespace Assets.Monsters.Scripts.Runtime.Interaction.Environment
{
    internal class Table : InteractionObject
    {
        private GameObject _prefabLabel;
        private GameObject _generatedLabel;

        protected override void Awake()
        {
            base.Awake();
            InitComponent();
        }

        public override void Interact()
        {
            if (_isInteractable)
                EnableLabel(true);
        }

        public override void Undo()
        {
            if (_isInteractable)
            {
                EnableLabel(false);
            }
        }

        private void InitComponent()
        {
            _prefabLabel = Resources.Load<GameObject>("Prefabs/UI/TableLabel");
            _generatedLabel = Instantiate(_prefabLabel, new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity, transform);
            EnableLabel(false);
        }

        private void EnableLabel(bool isActive = true) => _generatedLabel.SetActive(isActive);
    }
}
