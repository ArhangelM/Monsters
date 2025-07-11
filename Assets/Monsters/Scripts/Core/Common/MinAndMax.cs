using System;
using UnityEngine;

namespace Assets.Monsters.Scripts.Core.Common
{
    [Serializable]
    public class MinAndMax
    {
        [field: SerializeField] public int Min { get; private set; }
        [field: SerializeField] public int Max { get; private set; }
    }
}
