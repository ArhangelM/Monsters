using Assets.Monsters.Scripts.Core.Attacks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Monsters.Scripts.Runtime.UI.Battle
{
    internal class AttackInBattle : MonoBehaviour
    {
        [Header("General")]
        [SerializeField] private Image _attackIcon;

        [Header("Values")]
        [SerializeField] private TextMeshProUGUI _currentPP;
        [SerializeField] private TextMeshProUGUI _maxPP;

        private AttackData _attackData;

        public void Initialize(AttackData attackData)
        {
            _attackData = attackData;
            _attackIcon.sprite = attackData.Data.Image;
            UpdateValues();
        }

        private void UpdateValues()
        {
            _currentPP.text = _attackData.CurrentPowerPoints.ToString();
            _maxPP.text = _attackData.Data.MaxPowerPoints.ToString();
            // Update the attack icon color based on the current PP
            if (_attackData.CurrentPowerPoints <= 0)
                _attackIcon.color = Color.gray; // Disable color when PP is 0
            else
                _attackIcon.color = Color.white; // Reset to normal color when PP is available
        }
    }
}
