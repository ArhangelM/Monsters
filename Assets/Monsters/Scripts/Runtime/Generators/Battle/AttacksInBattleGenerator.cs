using ArhTools.Extensions;
using Assets.Monsters.Scripts.Core.Attacks;
using Assets.Monsters.Scripts.Runtime.UI.Battle;
using UnityEngine;

namespace Assets.Monsters.Scripts.Runtime.Generators.Battle
{
    internal class AttacksInBattleGenerator : MonoBehaviour
    {
        [SerializeField] private AttackInBattle _attackPrefab;

        public void Generate(AttackData attackData)
        {
            if (!_attackPrefab.HasValue())
            {
                Debug.LogError("AttackInBattle prefab is not assigned.");
                return;
            }

            var attack = Instantiate(_attackPrefab, transform);
            attack.Initialize(attackData);
        }
    }
}
