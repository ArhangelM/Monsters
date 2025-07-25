using ArhTools.Extensions;
using Assets.Monsters.Scripts.Core.Monsters;
using Assets.Monsters.Scripts.Runtime.UI.Battle;
using UnityEngine;

namespace Assets.Monsters.Scripts.Runtime.Generators.Battle
{
    internal class MonsterInBattleGenerator : MonoBehaviour
    {
        [SerializeField] private MonsterInBattle _monsterPrefab;

        public void Generate(MonsterData monsterData)
        {
            if (!_monsterPrefab.HasValue())
            {
                Debug.LogError("MonsterInBattle prefab is not assigned.");
                return;
            }

            var monsterInBattle = Instantiate(_monsterPrefab, transform);
            monsterInBattle.Initialize(monsterData);
        }
    }
}
