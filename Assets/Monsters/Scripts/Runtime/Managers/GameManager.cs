using Assets.Monsters.Scripts.Common.Helpers;
using Assets.Monsters.Scripts.Common.Signals;
using Tools.SignalBus;
using UnityEngine;

namespace Assets.Monsters.Scripts.Runtime.Managers
{
    internal class GameManager : MonoBehaviour
    {
        private void Awake()
        {
            FileHelper.LoadGameData();
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

        private void OnApplicationQuit()
        {
            FileHelper.SaveGameData();
        }

        private void OnSaveGame(SaveGameDataSignal signal)
        {
            FileHelper.SaveGameData();
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
