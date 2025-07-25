using Assets.Monsters.Scripts.Core;
using Assets.Monsters.Scripts.Core.Items;
using Assets.Monsters.Scripts.Core.Monsters;
using Assets.Monsters.Scripts.Runtime.Managers;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Monsters.Scripts.Common.Helpers
{
    internal static class FileHelper
    {
        public static async UniTask SaveGameData()
        {
            await UniTask.RunOnThreadPool(SaveItemsData);

        }

        public static async UniTask LoadGameData()
        {
            await UniTask.RunOnThreadPool(LoadItemsData);
        }

        private static async void SaveItemsData()
        {
            await UniTask.SwitchToMainThread();
            //var itemsDataForSave = Player.Instance.Items
            //  .Select(s => new ItemData(s.Data.ItemName, s.Count))
            //  .ToList();

            //foreach(var monster in Player.Instance.Monsters)
            //  monster.RemoveConfiguration();

            PlayerPrefs.SetString("Items", JsonConvert.SerializeObject(Player.Instance.Items));
            PlayerPrefs.SetString("Monsters", JsonConvert.SerializeObject(Player.Instance.Monsters));
            PlayerPrefs.Save();
        }

        private static async void LoadItemsData()
        {
            await UniTask.SwitchToMainThread();
            var itemsJson = PlayerPrefs.GetString("Items");
            var monstersJson = PlayerPrefs.GetString("Monsters");

            if (!string.IsNullOrEmpty(itemsJson))
                Player.Instance.Items = JsonConvert.DeserializeObject<List<ItemData>>(itemsJson);

            Player.Instance.Items = StorageManager.Instance.SetupConfigurationAllItems(Player.Instance.Items);

            if (!string.IsNullOrEmpty(monstersJson))
                Player.Instance.Monsters = JsonConvert.DeserializeObject<List<MonsterData>>(monstersJson);
            
            Player.Instance.Monsters = StorageManager.Instance.SetupConfigurationAllMonsters(Player.Instance.Monsters);
        }
    }
}
