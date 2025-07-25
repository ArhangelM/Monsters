using Assets.Monsters.Scripts.Core.Items;
using System.Collections.Generic;
using System.Linq;
using ArhTools.Extensions;
using Assets.Monsters.Scripts.Core.Monsters;

namespace Assets.Monsters.Scripts.Core
{
    public class Player
    {
        private static Player _instance;

        public static Player Instance
        {
            get
            {
                if (!_instance.HasValue())
                    _instance = new Player();

                return _instance;
            }
        }

        public List<ItemData> Items { get; set; } = new();
        public List<MonsterData> Monsters { get; set; } = new();


        private Player()
        {

        }

        public void AddItem(ItemData item)
        {
            var updateItem = Items.FirstOrDefault(s => s.NameKey == item.NameKey);
            if (updateItem.HasValue())
            {
                updateItem.Count += item.Count;
            }
            else
            {
                Items.Add(item);
            }
        }

        public void AddItems(IEnumerable<ItemData> item)
        {
            foreach (ItemData itemItem in item) 
                AddItem(itemItem);
        }

        public List<MonsterData> GetTeamMonsters() => Monsters.Where(s => s.IsTeam).ToList();
    }
}
