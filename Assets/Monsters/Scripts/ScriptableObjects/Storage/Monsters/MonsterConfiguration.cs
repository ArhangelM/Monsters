using Assets.Monsters.Scripts.Core.Enums;
using System;
using UnityEngine;

namespace Assets.Monsters.Scripts.ScriptableObjects.Storage.Monsters
{
    [CreateAssetMenu(fileName = "MonsterConfiguration", menuName = "Scriptable Objects/MonsterConfiguration")]
    public class MonsterConfiguration : ScriptableObject, ICloneable
    {
        [Header("Monster Configuration")]
        [field: SerializeField] public string MonsterName { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public int Hp { get; private set; }
        [field: SerializeField] public int Attack { get; private set; }
        [field: SerializeField] public int Defence { get; private set; }
        [field: SerializeField] public int Speed { get; private set; }
        [field: SerializeField] public Sprite Image { get; private set; }
        [field: SerializeField] public ElementType BaseElement { get; private set; }

        [Header("Gender chance")]
        [field: SerializeField] public int GenderMaleChance { get; private set; }
        [field: SerializeField] public int GenderFemaleChance { get; private set; }
        [field: SerializeField] public int GenderGenderlessChance { get; private set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
