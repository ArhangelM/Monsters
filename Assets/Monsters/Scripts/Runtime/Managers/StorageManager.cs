using Assets.Monsters.Scripts.Core.Enums;
using Assets.Monsters.Scripts.Core.Items;
using Assets.Monsters.Scripts.ScriptableObjects.Storage.Items;
using Assets.Monsters.Scripts.ScriptableObjects.Storage.Items.Boxes;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Monsters.Scripts.Runtime.Managers
{
    internal class StorageManager : MonoBehaviour
    {
        [SerializeField] StorageItemsConfiguration _allItemsStorage;

        [SerializeField] StorageItemsConfiguration _commonChestStorage;

        private static StorageManager _instance;
        public static StorageManager Instance => _instance;

        private void Awake()
        {
            if (_instance == null)
                _instance = this;
        }

        public ItemData[] GetItemsInChest(ChestType type)
        {
            ItemData[] items = new ItemData[Random.Range(1, 5)];
            StorageItemsConfiguration currentStorage = type switch
            {
                ChestType.CommonChest => _commonChestStorage,
                ChestType.TopChest => null, // Placeholder for TopChest storage
                _ => null
            };

            for (int i = 0; i < items.Length; i++)
            {
                var item = currentStorage.Items.ElementAt(Random.Range(0, currentStorage.Items.Count));
                var itemData = new ItemData
                (
                    Random.Range(item.Value.Min, item.Value.Max + 1),
                    item.Key.Clone() as ItemConfiguration
                );

                items[i] = itemData;
            }

            return items;
        }

        public List<ItemData> GetAllItems(List<ItemData> items)
        {
            for (int i = 0; i < items.Count; i++)
                items[i].SetData(_allItemsStorage.Items.FirstOrDefault(s => s.Key.ItemName == items[i].NameKey).Key);

            return items;
        }
    }
}
