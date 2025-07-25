using ArhTools.Extensions;
using Assets.Monsters.Scripts.Core.Attacks;
using Assets.Monsters.Scripts.Core.Enums;
using Assets.Monsters.Scripts.ScriptableObjects.Storage.Items;
using Assets.Monsters.Scripts.ScriptableObjects.Storage.Monsters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Assets.Monsters.Scripts.Core.Monsters
{
    public class MonsterData
    {
        public string Name { get; set; }
        public int Lvl { get; set; }
        public double CurrentExperience { get; set; }
        public double NeededExperience { get; set; }
        public int FreeEffortValues { get; set; }

        public bool IsTeam { get; set; }
        public bool FirstInTeam { get; set; }

        [JsonIgnore]
        public MonsterConfiguration Data { get; set; }
        public IEnumerable<AttackData> CurrentAttackList { get; set; }
        public IEnumerable<ElementType> ElementTypes { get; set; }

        public Character Character { get; set; }
        public Gender Gender { get; set; }

        public MonsterParameters Stats { get; set; }
        public DateTime BirthDay { get; set; }

        private void UseCharacter(ref float tempHp, ref float tempAttack, ref float tempDefence, ref float tempSpeed)
        {
            switch (Character)
            {
                case Character.Bizarre: //Причудливый
                case Character.Ordinary: //Обычный
                case Character.Serious: //Серьёзный
                case Character.Hardy: //Выносливый
                case Character.Shy: //Застенчивый
                case Character.Cheeky: //Весёлый
                case Character.Peaceful: //Мирный
                case Character.Soft: //Мягкий
                case Character.Naive: //Наивный
                case Character.Gentle: //Нежный
                case Character.Naughty: //Непослушный
                case Character.Inflexible: //Непреклонный
                case Character.Mischievous: //Озорной
                case Character.Dissolute: //Распущенный
                case Character.Modest: //Скромный
                case Character.Swift: //Стремительный
                case Character.Quiet: //Тихий
                    break;

                case Character.Impudent: //Наглый
                    tempDefence *= 1.1f;
                    tempAttack *= 0.9f;
                    break;

                case Character.Lonely: //Одинокий
                    tempAttack *= 1.1f;
                    tempDefence *= 0.9f;
                    break;

                case Character.Hasty: //Поспешный
                    tempSpeed *= 1.1f;
                    tempDefence *= 0.9f;
                    break;

                case Character.Timid: //Робкий
                    tempAttack *= 0.9f;
                    tempSpeed *= 1.1f;
                    break;

                case Character.Brave: //Смелый  
                    tempAttack *= 1.1f;
                    tempSpeed *= 0.9f;
                    break;

                case Character.Calm: //Спокойный
                    tempSpeed *= 0.9f;
                    tempDefence *= 1.1f;
                    break;
            }
        }

        public void UseMaxStats()
        {
            if (!Stats.HasValue())
                Stats = new MonsterParameters();

            float tempHp = (Data.Hp * 2 + Stats.HpGen + Stats.HpEV / 2f) * Lvl / 100f + 10 + Lvl;
            float tempAttack = ((Data.Attack * 2 + Stats.AttackGen + Stats.AttackEV / 2f) * Lvl / 100f + 5) * 1;
            float tempDefence = ((Data.Defence * 2 + Stats.DefenceGen + Stats.DefenceEV / 2f) * Lvl / 100f + 5) * 1;
            float tempSpeed = ((Data.Speed * 2 + Stats.SpeedGen + Stats.SpeedEV / 2f) * Lvl / 100f + 5) * 1;
            UseCharacter(ref tempHp, ref tempAttack, ref tempDefence, ref tempSpeed);

            Stats.MaxHealth = (int)Math.Round(tempHp, MidpointRounding.AwayFromZero);
            Stats.MaxAttack = (int)Math.Round(tempAttack, MidpointRounding.AwayFromZero);
            Stats.MaxDefence = (int)Math.Round(tempDefence, MidpointRounding.AwayFromZero);
            Stats.MaxSpeed = (int)Math.Round(tempSpeed, MidpointRounding.AwayFromZero);

            Stats.Health = Stats.MaxHealth;
            Stats.Attack = Stats.MaxAttack;
            Stats.Defence = Stats.MaxDefence;
            Stats.Speed = Stats.MaxSpeed;
        }

        public void SetData(MonsterConfiguration data)
        {
            Data = data;
        }

        public void RemoveConfiguration()
        {
            if (Data.HasValue())
                Data = null;
        }
    }
}