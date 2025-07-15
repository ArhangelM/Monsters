using Assets.Monsters.Scripts.Common.Signals;
using Assets.Monsters.Scripts.Common.Signals.InputManagerSignals;
using Assets.Monsters.Scripts.Runtime.UI.Interface;
using Tools.Extensions;
using Tools.SignalBus;
using UnityEngine;
using UnityEngine.UI;
using Core = Assets.Monsters.Scripts.Core;

namespace Assets.Monsters.Scripts.Runtime.Generators.UI
{
    internal class InventoryGenerator : MonoBehaviour
    {
        [SerializeField] private ItemView _itemPrefab;
        [SerializeField] private Button _closeButton;
        
        private int _maxItemsCount = 100;
        private ItemView[] _items;

        private void OnEnable()
        {
            SubscribeEvents();
            GenerateItems();
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        private void OnShowItems(OpenInventorySignal signal)
        {
            ResetItems();
            
            for (int i = 0; i < Core.Player.Instance.Items.Count; i++)
                _items[i].Init(Core.Player.Instance.Items[i]);
        }

        private void GenerateItems()
        {
            if (!_items.HasValue())
            {
                _items = new ItemView[_maxItemsCount];

                for (int i = 0; i < _maxItemsCount; i++)
                    _items[i] = Instantiate(_itemPrefab, transform);
            }
        }

        private void ResetItems()
        {
            foreach (var item in _items)
                item.Init();
        }

        private void OnCloseButtonClick()
        {
            SignalBus.Instance.Invoke(new CloseInventorySignal());
        }

        private void SubscribeEvents()
        {
            SignalBus.Instance.Subscribe<OpenInventorySignal>(OnShowItems);
            _closeButton.onClick.AddListener(OnCloseButtonClick);
        }

        private void UnsubscribeEvents()
        {
            SignalBus.Instance.Unsubscribe<OpenInventorySignal>(OnShowItems);
            _closeButton.onClick.RemoveListener(OnCloseButtonClick);
        }
    }
}
