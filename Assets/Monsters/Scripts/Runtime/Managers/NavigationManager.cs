using Assets.Monsters.Scripts.Common.Signals;
using Assets.Monsters.Scripts.Common.Signals.InputManagerSignals;
using Tools.SignalBus;
using UnityEngine;

namespace Assets.Monsters.Scripts.Runtime.Managers
{
    internal class NavigationManager : MonoBehaviour
    {
        [SerializeField] private Canvas _lootCanvas;
        [SerializeField] private Canvas _inventoryCanvas;

        private void OnEnable()
        {
            _lootCanvas.enabled = false;
            _inventoryCanvas.enabled = false;
            SubscribeEvents();
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        private void OnOpenLootCanvasSignal(ShowChestItemsSignal signal)
        {    
            _lootCanvas.enabled = true;
        }

        private void OnCloseLootCanvasSignal(CloseChestItemsSignal signal)
        {
            _lootCanvas.enabled = false;
        }

        private void OnOpenInventorySignal(OpenInventorySignal signal)
        {
            _inventoryCanvas.enabled = true;
        }

        private void OnCloseInventorySignal(CloseInventorySignal signal)
        {
            _inventoryCanvas.enabled = false;
        }

        private void SubscribeEvents()
        {
            SignalBus.Instance.Subscribe<ShowChestItemsSignal>(OnOpenLootCanvasSignal);
            SignalBus.Instance.Subscribe<CloseChestItemsSignal>(OnCloseLootCanvasSignal);
            SignalBus.Instance.Subscribe<OpenInventorySignal>(OnOpenInventorySignal);
            SignalBus.Instance.Subscribe<CloseInventorySignal>(OnCloseInventorySignal);
        }

        private void UnsubscribeEvents()
        {            
            SignalBus.Instance.Unsubscribe<ShowChestItemsSignal>(OnOpenLootCanvasSignal);
            SignalBus.Instance.Unsubscribe<CloseChestItemsSignal>(OnCloseLootCanvasSignal);
            SignalBus.Instance.Unsubscribe<OpenInventorySignal>(OnOpenInventorySignal);
            SignalBus.Instance.Unsubscribe<CloseInventorySignal>(OnCloseInventorySignal);
        }

    }
}
