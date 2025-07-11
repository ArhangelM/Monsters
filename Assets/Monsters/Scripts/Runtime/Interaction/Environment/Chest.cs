using Assets.Monsters.Scripts.Common.Signals;
using Assets.Monsters.Scripts.Core.Enums;
using Assets.Monsters.Scripts.Core.Items;
using Assets.Monsters.Scripts.Runtime.Interaction.Common;
using Assets.Monsters.Scripts.Runtime.Managers;
using Tools.SignalBus;
using UnityEngine;

namespace Assets.Monsters.Scripts.Runtime.Interaction.Environment
{
    [RequireComponent(typeof(Animator))]
    internal class Chest : InteractionObject
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private ChestType _chestType;

        private ItemData[] _items;
        private bool _isOpened = false;

        public void Init(ChestType chestType)
        {
            _chestType = chestType;
        }

        public override void Interact()
        {
            if (_isInteractable)
            {
                if (!_isOpened)
                {
                    _items = StorageManager.Instance.GetItemsInChest(_chestType);
                    _animator.SetBool("Open", true);
                    _isOpened = true;
                }
                else
                    Debug.Log("Chest is already opened.");

                SignalBus.Instance.Invoke(new ShowChestItemsSignal(_items));
            }
        }
    }
}
