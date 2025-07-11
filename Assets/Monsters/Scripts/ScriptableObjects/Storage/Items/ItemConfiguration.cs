using Assets.Monsters.Scripts.Core.Enums;
using System;
using UnityEngine;

namespace Assets.Monsters.Scripts.ScriptableObjects.Storage.Items
{
    [CreateAssetMenu(fileName = "ItemConfiguration", menuName = "Scriptable Objects/ItemConfiguration")]
    public class ItemConfiguration : ScriptableObject, ICloneable
    {
        [field: SerializeField] public string ItemName { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public Sprite Image { get; private set; }
        [field: SerializeField] public Rarity Rarity { get; private set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}