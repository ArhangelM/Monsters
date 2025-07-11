using Assets.Monsters.Scripts.Core.Items;

namespace Assets.Monsters.Scripts.Common.Signals
{
    internal class ShowChestItemsSignal
    {
        public ItemData[] Items { get; private set; }
        public ShowChestItemsSignal(ItemData[] items)
        {
            Items = items;
        }
    }
}
