using System;

namespace Assets.Monsters.Scripts.Core.Monsters
{
    public class MonsterParameters : ICloneable
    {
        #region CurrentStats
        public int Health { get; set; }
        public int Speed { get; set; }
        public int Defence { get; set; }
        public int Attack { get; set; }
        #endregion

        #region MaxStats
        public int MaxHealth { get; set; }
        public int MaxSpeed { get; set; }
        public int MaxDefence { get; set; }
        public int MaxAttack { get; set; }
        #endregion

        #region Gens
        public int HpGen { get; set; }
        public int SpeedGen { get; set; }
        public int DefenceGen { get; set; }
        public int AttackGen { get; set; }
        #endregion

        #region EV
        public int HpEV { get; set; }
        public int SpeedEV { get; set; }
        public int DefenceEV { get; set; }
        public int AttackEV { get; set; }
        #endregion

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
