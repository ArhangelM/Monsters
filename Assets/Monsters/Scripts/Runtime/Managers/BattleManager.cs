using Assets.Monsters.Scripts.Core.Battlefield;
using CoreBuildData = Assets.Monsters.Scripts.Core;
using UnityEngine;
using Assets.Monsters.Scripts.Runtime.Generators.Battle;
using Assets.Monsters.Scripts.Core.Monsters;
using System.Linq;
using System.Collections.Generic;

namespace Assets.Monsters.Scripts.Runtime.Managers
{
    internal class BattleManager : MonoBehaviour
    {
        [SerializeField] private MonsterInBattleGenerator _playerMonsterGenerator;
        [SerializeField] private MonsterInBattleGenerator _enemyMonsterGenerator;
        [SerializeField] private AttacksInBattleGenerator _attackInBattleGenerator;
        [SerializeField] private MonstersInBattleTeamGenerator _monstersInBattleTeamGenerator;

        private Battlefield _battlefield;
        private List<MonsterData> _playerMonsters;
        private MonsterData _enemyMonster;


        private void Awake()
        {
            InitFields();
            GenerateMonsterInBattles();
            GenerateAttacks();
            GenerateTeam();
        }

        private void InitFields()
        {
            _playerMonsters = Core.Player.Instance.GetTeamMonsters();
            _enemyMonster = MonsterInBattleCrossScene.Monster;

            _battlefield = new Battlefield(_enemyMonster, _playerMonsters);
        }

        private void GenerateMonsterInBattles()
        {
            RemoveChildren(_playerMonsterGenerator.transform);
            RemoveChildren(_enemyMonsterGenerator.transform);

            _playerMonsterGenerator.Generate(_playerMonsters.FirstOrDefault(s => s.FirstInTeam));
            _enemyMonsterGenerator.Generate(_enemyMonster);
        }

        private void GenerateAttacks()
        {
            RemoveChildren(_attackInBattleGenerator.transform);

            foreach (var attack in _playerMonsters.FirstOrDefault(s => s.FirstInTeam).CurrentAttackList)
            {
                _attackInBattleGenerator.Generate(attack);
            }
        }

        private void GenerateTeam()
        {
            RemoveChildren(_monstersInBattleTeamGenerator.transform);
            foreach (var monster in _playerMonsters)
            {
                _monstersInBattleTeamGenerator.Generate(monster);
            }
        }

        private void RemoveChildren(Transform transform)
        {
            if (transform.childCount > 0)
            {
                foreach (Transform child in transform)
                    Destroy(child.gameObject);
            }
        }
    }
}
