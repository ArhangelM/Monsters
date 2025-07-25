using Assets.Monsters.Scripts.Core.Enums;
using System;
using UnityEngine;

namespace Assets.Monsters.Scripts.ScriptableObjects.Storage.Attacks
{
    [CreateAssetMenu(fileName = "AttackConfiguration", menuName = "Scriptable Objects/AttackConfiguration")]
    public class AttackConfiguration : ScriptableObject, ICloneable
    {
        [field: SerializeField] public string AttackName { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public Sprite Image { get; private set; }
        [field: SerializeField] public ElementType AttackElement { get; private set; }
        [field: SerializeField] public AttackType AttackType { get; private set; }
        [field: SerializeField] public int MaxPowerPoints { get; private set; }
        [field: SerializeField] public int Power { get; private set; }
        [field: SerializeField] public int Accuracy { get; private set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
