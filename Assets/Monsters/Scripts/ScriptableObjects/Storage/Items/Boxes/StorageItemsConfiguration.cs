using Assets.Monsters.Scripts.Core.Common;
using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace Assets.Monsters.Scripts.ScriptableObjects.Storage.Items.Boxes
{
    [CreateAssetMenu(fileName = "StorageItemsConfiguration", menuName = "Scriptable Objects/StorageItemsConfiguration")]
    public class StorageItemsConfiguration : ScriptableObject
    {
        [SerializedDictionary("Item", "Addition info")]
        public SerializedDictionary<ItemConfiguration, MinAndMax> Items;
    }
}