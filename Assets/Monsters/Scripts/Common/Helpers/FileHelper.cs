using Assets.Monsters.Scripts.Core;
using Assets.Monsters.Scripts.Core.Items;
using Assets.Monsters.Scripts.Runtime.Managers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Monsters.Scripts.Common.Helpers
{
    internal static class FileHelper
    {
        public static void SaveGameData()
        {
            var itemssDataForSave = Player.Instance.Items
                .Select(s => new ItemData(s.Data.ItemName, s.Count))
                .ToList();

            PlayerPrefs.SetString("Items", JsonConvert.SerializeObject(itemssDataForSave));
            PlayerPrefs.Save();
        }

        public static void LoadGameData()
        {
            var itemsJson = PlayerPrefs.GetString("Items");

            if (!string.IsNullOrEmpty(itemsJson))
                Player.Instance.Items = JsonConvert.DeserializeObject<List<ItemData>>(itemsJson);

            Player.Instance.Items = StorageManager.Instance.GetAllItems(Player.Instance.Items);
        }
    }
}
