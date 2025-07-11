using Assets.Monsters.Scripts.Common.Signals;
using Assets.Monsters.Scripts.Runtime.UI.Interface;
using Tools.Extensions;
using Tools.SignalBus;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Monsters.Scripts.Runtime.Generators.UI
{
    public class GiftContentGenerator : MonoBehaviour
    {
        [SerializeField] private ItemView _itemPrefab;
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _takeAllButton;
        [SerializeField] private int _maxItemsCount = 4;

        private ItemView[] _items;

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
            GenerateItems();
            ResetItems();

            for (int i = 0; i < signal.Items.Length; i++)
                _items[i].Init(signal.Items[i]);
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
        }

        private void SubscribeEvents()
        {
            SignalBus.Instance.Subscribe<ShowChestItemsSignal>(OnShowChestItemsSignal);
            _closeButton.onClick.AddListener(OnCloseButtonClick);
        }

        private void UnsubscribeEvents()
        {
            SignalBus.Instance.Unsubscribe<ShowChestItemsSignal>(OnShowChestItemsSignal);
            _closeButton.onClick.RemoveListener(OnCloseButtonClick);
        }
    }
}