using System.Collections.Generic;
using UnityEngine;

namespace Assets.Monsters.Scripts.ScriptableObjects.Storage.Attacks.Boxes
{
    [CreateAssetMenu(fileName = "StorageAttackConfiguration", menuName = "Scriptable Objects/StorageAttackConfiguration")]
    internal class StorageAttackConfiguration : ScriptableObject
    {
        [field: SerializeField] public List<AttackConfiguration> Attacks { get; private set; }
    }
}
