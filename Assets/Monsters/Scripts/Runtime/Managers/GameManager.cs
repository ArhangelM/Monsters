using Assets.Monsters.Scripts.Common.Helpers;
using Assets.Monsters.Scripts.Common.Signals;
using ArhTools.SignalBus;
using UnityEngine;

namespace Assets.Monsters.Scripts.Runtime.Managers
{
    internal class GameManager : MonoBehaviour
    {
        private async void Awake()
        {
            await FileHelper.LoadGameData();
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        private void OnApplicationPause(bool pause)
        {
            //FileHelper.SaveGameData();
        }

        private async void OnApplicationQuit()
        {
            //await FileHelper.SaveGameData();
        }

        private async void OnSaveGame(SaveGameDataSignal signal)
        {
            //await FileHelper.SaveGameData();
        }

        private void SubscribeEvents()
        {
            SignalBus.Instance.Subscribe<SaveGameDataSignal>(OnSaveGame);
        }

        private void UnsubscribeEvents()
        {
            SignalBus.Instance.Unsubscribe<SaveGameDataSignal>(OnSaveGame);
        }
    }
}
