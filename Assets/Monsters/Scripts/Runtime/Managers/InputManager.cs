using Assets.Monsters.Scripts.Common.Signals.InputManagerSignals;
using ArhTools.SignalBus;
using UnityEngine;

namespace Assets.Monsters.Scripts.Runtime.Managers
{
    internal class InputManager : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
               SignalBus.Instance.Invoke(new OpenInventorySignal());
            if (Input.GetKeyDown(KeyCode.P))
                SignalBus.Instance.Invoke(new StartBattleSignal());
        }
    }
}
