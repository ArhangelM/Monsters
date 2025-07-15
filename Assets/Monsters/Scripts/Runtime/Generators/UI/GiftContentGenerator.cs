using Assets.Monsters.Scripts.Common.Signals;
using Assets.Monsters.Scripts.Runtime.Interaction.Environment;
using Assets.Monsters.Scripts.Runtime.UI.Interface;
using System.Linq;
using Tools.Extensions;
using Tools.SignalBus;
using UnityEngine;
using UnityEngine.UI;
using Core = Assets.Monsters.Scripts.Core;

namespace Assets.Monsters.Scripts.Runtime.Generators.UI
{
    public class GiftContentGenerator : MonoBehaviour
    {
        [SerializeField] private ItemView _itemPrefab;
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _takeAllButton;
        [SerializeField] private int _maxItemsCount = 4;

        private ItemView[] _items;
        private Chest _currentChest;

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        private void OnShowChestItemsSignal(ShowChestItemsSignal signal)
        {
            _currentChest = signal.Chest;
            GenerateItems();
            ResetItems();

            for (int i = 0; i < signal.Items.Length; i++)
            {
                _items[i].Init(signal.Items[i]);
                _items[i].OnTakeItem += TakeItem;
            }
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
            SignalBus.Instance.Invoke(new CloseChestItemsSignal());
            for (int i = 0; i < _items.Length; i++)
            {
                _items[i].OnTakeItem -= TakeItem;
            }
        }

        private void OnTakeAllItems()
        {
            var takedItems = _items
                .Where(s => s.ItemData.HasValue())
                .Select(s => s.ItemData);

            Core.Player.Instance.AddItems(takedItems);

            _currentChest.TakeAllItems(takedItems);
            ResetItems();
            SignalBus.Instance.Invoke(new SaveGameDataSignal());
        }

        private void TakeItem(ItemView item)
        {
            Core.Player.Instance.AddItem(item.ItemData);
            _currentChest.TakeItem(item.ItemData);
            item.Init();
            SignalBus.Instance.Invoke(new SaveGameDataSignal());
        }

        private void SubscribeEvents()
        {
            SignalBus.Instance.Subscribe<ShowChestItemsSignal>(OnShowChestItemsSignal);
            _closeButton.onClick.AddListener(OnCloseButtonClick);
            _takeAllButton.onClick.AddListener(OnTakeAllItems);
        }

        private void UnsubscribeEvents()
        {
            SignalBus.Instance.Unsubscribe<ShowChestItemsSignal>(OnShowChestItemsSignal);
            _closeButton.onClick.RemoveListener(OnCloseButtonClick);
            _takeAllButton.onClick.RemoveListener(OnTakeAllItems);
        }
    }
}