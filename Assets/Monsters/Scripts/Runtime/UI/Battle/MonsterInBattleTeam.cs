using Assets.Monsters.Scripts.Core.Monsters;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Monsters.Scripts.Runtime.UI.Battle
{
    internal class MonsterInBattleTeam : MonoBehaviour
    {
        [Header("General")]
        [SerializeField] private Image _monsterIcon;
        [SerializeField] private Slider _healthBar;
        [SerializeField] private Slider _expBar;
        [SerializeField] private Image _monsterType;

        [Header("Values")]
        [SerializeField] private TextMeshProUGUI _levelValue;
        [SerializeField] private TextMeshProUGUI _currentHealthValue;
        [SerializeField] private TextMeshProUGUI _maxHealthValue;
        [SerializeField] private TextMeshProUGUI _currentExpValue;
        [SerializeField] private TextMeshProUGUI _maxExpValue;

        private MonsterData _monsterData;

        public void Initialize(MonsterData monsterData)
        {
            _monsterData = monsterData;
            _monsterIcon.sprite = monsterData.Data.Image;
            //_monsterType.sprite = monsterData.;
            UpdateValues();
        }

        private void UpdateValues()
        {
            _levelValue.text = _monsterData.Lvl.ToString();
            _currentHealthValue.text = _monsterData.Stats.Health.ToString();
            _maxHealthValue.text = _monsterData.Stats.MaxHealth.ToString();
            _currentExpValue.text = _monsterData.CurrentExperience.ToString("F1");
            _maxExpValue.text = _monsterData.NeededExperience.ToString("F1");

            _healthBar.maxValue = _monsterData.Stats.MaxHealth;
            _healthBar.value = _monsterData.Stats.Health;

            _expBar.value = (float)_monsterData.CurrentExperience;
            _expBar.maxValue = (float)_monsterData.NeededExperience;
        }
    }
}
