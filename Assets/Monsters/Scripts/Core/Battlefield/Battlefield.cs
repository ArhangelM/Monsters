using Assets.Monsters.Scripts.Core.Monsters;
using System.Collections.Generic;

namespace Assets.Monsters.Scripts.Core.Battlefield
{
    internal class Battlefield
    {
        private MonsterData _enemyMonster;
        private List<MonsterData> _playerMonster;

        public Battlefield(MonsterData enemyMonster, List<MonsterData> playerMonsters)
        {
            _enemyMonster = enemyMonster;
            _playerMonster = playerMonsters;
        }
    }
}
