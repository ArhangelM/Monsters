using ArhTools.Extensions;
using Assets.Monsters.Scripts.ScriptableObjects.Storage.Items;
using Newtonsoft.Json;

namespace Assets.Monsters.Scripts.Core.Items
{
    public class ItemData
    {
        public string NameKey { get; set; }
        public int Count { get; set; }

        [JsonIgnore]
        public ItemConfiguration Data { get; private set; }

        public ItemData()
        {
            
        }

        public ItemData(string nameKey, int count)
        {
            NameKey = nameKey;
            Count = count;
            Data = null;
        }

        public ItemData(int count, ItemConfiguration data)
        {
            Count = count;
            Data = data;
            NameKey = data.ItemName;
        }

        public void SetData(ItemConfiguration data)
        {
            Data = data;
        }
    }
}
