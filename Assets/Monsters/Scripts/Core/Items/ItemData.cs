using Assets.Monsters.Scripts.ScriptableObjects.Storage.Items;

namespace Assets.Monsters.Scripts.Core.Items
{
    public class ItemData
    {
       // public string NameKey { get; set; }
        public int Count { get; set; }

        public ItemConfiguration Data { get; set; }

        public ItemData()
        {
            
        }

        public ItemData(int count, ItemConfiguration data)
        {
            Count = count;
            Data = data;
        }
    }
}
