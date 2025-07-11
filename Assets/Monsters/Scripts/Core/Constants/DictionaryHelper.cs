using Assets.Monsters.Scripts.Core.Enums;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Monsters.Scripts.Core.Constants
{
    internal static class DictionaryHelper
    {
        public static Dictionary<Rarity, Color> ColorByRarity { get; private set; } = new Dictionary<Rarity, Color>
        {
            { Rarity.Common, Color.gray },  //Gray
            { Rarity.Uncommon, new Color(0.117f, 1f, 0.549f) }, // Green
            { Rarity.Rare, new Color(0.235f, 0.470f, 1f) }, // Blue
            { Rarity.Epic, new Color(0.686f, 0.313f, 1f) }, // Purple
            { Rarity.Legendary, new Color(1f, 0.549f, 0f) }, // Orange
            { Rarity.Mythical, new Color(1f, 0.196f, 0.196f) } // Red
        };
    }
}
