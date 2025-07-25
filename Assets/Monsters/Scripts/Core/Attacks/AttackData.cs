using Assets.Monsters.Scripts.Core.Enums;
using Assets.Monsters.Scripts.ScriptableObjects.Storage.Attacks;
using Assets.Monsters.Scripts.ScriptableObjects.Storage.Items;
using Newtonsoft.Json;

namespace Assets.Monsters.Scripts.Core.Attacks
{
    public class AttackData
    {
        public string NameKey { get; set; }
        public int CurrentPowerPoints { get; set; }
        public ElementType ElementType { get; set; }

        [JsonIgnore]
        public AttackConfiguration Data { get; private set; }

        public AttackData()
        {

        }

        public AttackData(string nameKey, int currentPowerPoints, AttackConfiguration data)
        {
            NameKey = nameKey;
            CurrentPowerPoints = currentPowerPoints;
            ElementType = data.AttackElement;
            Data = data;
        }

        public void SetData(AttackConfiguration data)
        {
            Data = data;
        }
    }
}
