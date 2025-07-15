using Assets.Monsters.Scripts.Common.Signals.InputManagerSignals;
using Tools.SignalBus;
using UnityEngine;

namespace Assets.Monsters.Scripts.Runtime.Managers
{
    internal class InputManager : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
               SignalBus.Instance.Invoke(new OpenInventorySignal());
        }
    }
}
