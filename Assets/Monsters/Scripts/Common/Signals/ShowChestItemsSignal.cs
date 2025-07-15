using Assets.Monsters.Scripts.Core.Items;
using Assets.Monsters.Scripts.Runtime.Interaction.Environment;

namespace Assets.Monsters.Scripts.Common.Signals
{
    internal class ShowChestItemsSignal
    {
        public ItemData[] Items { get; private set; }
        public Chest Chest { get; private set; }
        public ShowChestItemsSignal(ItemData[] items, Chest chest)
        {
            Items = items;
            Chest = chest;
        }
    }
}
