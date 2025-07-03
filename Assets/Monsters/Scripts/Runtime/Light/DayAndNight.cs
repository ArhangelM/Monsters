using UnityEngine;
using UnityEngine.Rendering.Universal;
using Assets.Monsters.Scripts.Common;
using System;

namespace Assets.Monsters.Scripts.Runtime.Light
{
    internal class DayAndNight : MonoBehaviour
    {
        [Header("Day and Night Cycle Settings")]
        [SerializeField] private Light2D _lightSource;
        [SerializeField] private Color _dayColor = Color.white; // Color during the day
        [SerializeField] private Color _nightColor = new Color(0, 50, 80); // Color during the night

        [Header("Day and Night Duration Settings")]
        [Tooltip("Duration of day in seconds.")]
        [SerializeField] private float _dayDuration; // Duration of day in seconds

        [Tooltip("Duration of night in seconds.")]
        [SerializeField] private float _nightDuration; // Duration of night in seconds

        private ActionTimer _timer;
        private bool _isDayTime = true;

        private void Awake()
        {
            _timer = new ActionTimer(ChangedDayTime);
        }

        private void OnEnable()
        {
            _timer.Start();
        }

        private void OnDisable()
        {
            _timer.Stop();
        }
        
        private void ChangedDayTime()
        {
            _lightSource.color = Color.LerpUnclamped(_lightSource.color, 
                _isDayTime ? _nightColor : _dayColor, 
                1f / (_isDayTime ? _dayDuration : _nightDuration));

            if (_isDayTime && EqualColors(_lightSource.color, _nightColor))
                _isDayTime = false;
            else if (!_isDayTime && EqualColors(_lightSource.color, _dayColor))     
                _isDayTime = true;
        }

        private bool EqualColors(Color firstColor, Color secondColor) => Math.Round(firstColor.r, 1) == Math.Round(secondColor.r, 1) &&
                                                                        Math.Round(firstColor.g, 1) == Math.Round(secondColor.g, 1) &&
                                                                        Math.Round(firstColor.b, 1) == Math.Round(secondColor.b, 1);
    }
}
