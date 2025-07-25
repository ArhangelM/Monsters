using ArhTools.Extensions;
using Assets.Monsters.Scripts.Core.Attacks;
using Assets.Monsters.Scripts.Core.Enums;
using Assets.Monsters.Scripts.Core.Monsters;
using Assets.Monsters.Scripts.ScriptableObjects.Storage.Attacks;
using Assets.Monsters.Scripts.ScriptableObjects.Storage.Attacks.Boxes;
using Assets.Monsters.Scripts.ScriptableObjects.Storage.Monsters;
using System;
using System.Collections.Generic;

namespace Assets.Monsters.Scripts.Core.Battlefield
{
    internal class MonsterHelper
    {
        public MonsterData GenerateMonsterData(MonsterConfiguration configuration, List<AttackConfiguration> attacks)
        {
            if (!configuration.HasValue())
                throw new ArgumentNullException("MonsterData or MonsterConfiguration cannot be null.");

            Random random = new Random();

            var monsterData = new MonsterData
            {
                Name = configuration.MonsterName,
                Lvl = 1, // Default level
                CurrentExperience = 0,
                NeededExperience = 100,
                FreeEffortValues = 0,
                IsTeam = true,
                FirstInTeam = true,
                Data = configuration.Clone() as MonsterConfiguration,
                CurrentAttackList = new List<AttackData>(),
                ElementTypes = new List<ElementType>
                {
                    configuration.BaseElement
                },
                Character = (Character)random.Next(0, Enum.GetValues(typeof(Character)).Length),
                Gender = GenerateGender(configuration),

                BirthDay = DateTime.Now
            };

            monsterData.UseMaxStats();
            monsterData.CurrentAttackList = ChoiceAttacks(attacks);
            return monsterData;
        }

        private Gender GenerateGender(MonsterConfiguration configuration)
        {
            Random random = new Random();
            int totalChance = configuration.GenderMaleChance + configuration.GenderFemaleChance + configuration.GenderGenderlessChance;
            int randomValue = random.Next(0, totalChance);

            if (randomValue < configuration.GenderMaleChance)
                return Gender.Male;
            if (randomValue < configuration.GenderMaleChance + configuration.GenderFemaleChance)
                return Gender.Female;
            else
                return Gender.Male;
        }

        private IEnumerable<AttackData> ChoiceAttacks(List<AttackConfiguration> attacks)
        {
            Random random = new Random();
            List<AttackData> availableAttacks = new();
            AttackData attack;

            for (int i = 0; i < 4; i++)
            {
                var attackConfiguration = attacks[random.Next(0, attacks.Count)];
                attack = new AttackData(attackConfiguration.AttackName, attackConfiguration.MaxPowerPoints, attackConfiguration);
                availableAttacks.Add(attack);
            }

            return availableAttacks;
        }
    }  
}
