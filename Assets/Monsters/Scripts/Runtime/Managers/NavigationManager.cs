using Assets.Monsters.Scripts.Common.Signals;
using System;
using Tools.SignalBus;
using UnityEngine;

namespace Assets.Monsters.Scripts.Runtime.Managers
{
    internal class NavigationManager : MonoBehaviour
    {
        [SerializeField] private Canvas _lootCanvas;

        private void OnEnable()
        {
            _lootCanvas.enabled = false;
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

        private void SubscribeEvents()
        {
            SignalBus.Instance.Subscribe<ShowChestItemsSignal>(OnOpenLootCanvasSignal);
            SignalBus.Instance.Subscribe<CloseChestItemsSignal>(OnCloseLootCanvasSignal);
        }

        private void UnsubscribeEvents()
        {            
            SignalBus.Instance.Unsubscribe<ShowChestItemsSignal>(OnOpenLootCanvasSignal);
            SignalBus.Instance.Unsubscribe<CloseChestItemsSignal>(OnCloseLootCanvasSignal);
        }

    }
}
