using System.Collections.Generic;
using UnityEngine;

namespace Assets.Monsters.Scripts.ScriptableObjects.Storage.Monsters.Boxes
{
    [CreateAssetMenu(fileName = "StorageMonsterConfiguration", menuName = "Scriptable Objects/StorageMonsterConfiguration")]
    internal class StorageMonsterConfiguration : ScriptableObject
    {
        [field: SerializeField] public List<MonsterConfiguration> Monsters { get; private set; }
    }
}
