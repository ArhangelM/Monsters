using UnityEditor.SceneManagement;
using UnityEngine;

namespace Assets.Monsters.Scripts.Runtime.Interaction.Common
{
    internal class InteractionObject : MonoBehaviour, IInteraction
    {
        protected bool _isInteractable = false;

        private GameObject _generateInfoPrefab;
        private Collider2D _collider2D;
        private GameObject _infoObject;

        protected virtual void Awake()
        {            
            InitComponent();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                _isInteractable = true;
                EnableInfo();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                _isInteractable = false;
                EnableInfo(false);
            }
        }

        public virtual void Interact()
        {
            
        }

        public virtual void Undo()
        {

        }

        private void InitComponent()
        {
            _collider2D = gameObject.AddComponent<BoxCollider2D>();
            _collider2D.isTrigger = true;

            _generateInfoPrefab = Resources.Load<GameObject>("Prefabs/UI/MightInteraction[Canvas]");
            _infoObject = Instantiate(_generateInfoPrefab, new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity, transform);
            EnableInfo(false);
        }

        private void EnableInfo(bool isActive = true) => _infoObject.SetActive(isActive);
    }
}
