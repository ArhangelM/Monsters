using Assets.Monsters.Scripts.Core.Enums;
using Assets.Monsters.Scripts.Core.Items;
using Assets.Monsters.Scripts.Core.Monsters;
using Assets.Monsters.Scripts.ScriptableObjects.Storage.Attacks;
using Assets.Monsters.Scripts.ScriptableObjects.Storage.Attacks.Boxes;
using Assets.Monsters.Scripts.ScriptableObjects.Storage.Items;
using Assets.Monsters.Scripts.ScriptableObjects.Storage.Items.Boxes;
using Assets.Monsters.Scripts.ScriptableObjects.Storage.Monsters;
using Assets.Monsters.Scripts.ScriptableObjects.Storage.Monsters.Boxes;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Monsters.Scripts.Runtime.Managers
{
    internal class StorageManager : MonoBehaviour
    {
        [SerializeField] StorageItemsConfiguration _allItemsStorage;

        [SerializeField] StorageItemsConfiguration _commonChestStorage;

        [Header("Attacks Storages")]
        [SerializeField] StorageAttackConfiguration _normalAttackStorage;
        [SerializeField] StorageAttackConfiguration _waterAttackStorage;
        [SerializeField] StorageAttackConfiguration _fireAttackStorage;
        [SerializeField] StorageAttackConfiguration _flyingAttackStorage;
        [SerializeField] StorageAttackConfiguration _groundAttackStorage;

        [Header("Monsters Storage")]
        [SerializeField] StorageMonsterConfiguration _allMonstersStorage;

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

        public List<ItemData> SetupConfigurationAllItems(List<ItemData> items)
        {
            for (int i = 0; i < items.Count; i++)
                items[i].SetData(_allItemsStorage.Items.FirstOrDefault(s => s.Key.ItemName == items[i].NameKey).Key);

            return items;
        }

        public List<MonsterData> SetupConfigurationAllMonsters(List<MonsterData> monsters)
        {
            for (int i = 0; i < monsters.Count; i++)
            {
                monsters[i].SetData(_allMonstersStorage.Monsters.FirstOrDefault(s => s.MonsterName == monsters[i].Name));

                for(int j = 0; j < monsters[i].CurrentAttackList.Count(); j++)
                {
                    var attack = monsters[i].CurrentAttackList.ElementAt(j);
                    attack.SetData(GetAttackConfigurations(attack.NameKey, attack.ElementType));                   
                }
            }

            return monsters;
        }

        public List<AttackConfiguration> GetAttackConfigurations(ElementType type)
        {
            return type switch
            {
                ElementType.Normal => _normalAttackStorage.Attacks,
                ElementType.Water => _waterAttackStorage.Attacks,
                ElementType.Fire => _fireAttackStorage.Attacks,
                ElementType.Flying => _flyingAttackStorage.Attacks,
                ElementType.Ground => _groundAttackStorage.Attacks,
                _ => new List<AttackConfiguration>()
            };
        }

        public AttackConfiguration GetAttackConfigurations(string name, ElementType type)
        {
            return GetAttackConfigurations(type).FirstOrDefault(s => s.AttackName == name);
        }

        public MonsterConfiguration GetMonsterConfiguration(string name)
        {
            return _allMonstersStorage.Monsters.FirstOrDefault(s => s.MonsterName == name);
        }
    }
}
