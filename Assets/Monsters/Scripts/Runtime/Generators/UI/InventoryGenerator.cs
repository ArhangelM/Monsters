using Assets.Monsters.Scripts.Common.Signals;
using Assets.Monsters.Scripts.Common.Signals.InputManagerSignals;
using Assets.Monsters.Scripts.Runtime.UI.Interface;
using ArhTools.Extensions;
using ArhTools.SignalBus;
using UnityEngine;
using UnityEngine.UI;
using Core = Assets.Monsters.Scripts.Core;
using Assets.Monsters.Scripts.Core.Battlefield;
using Assets.Monsters.Scripts.Runtime.Managers;
using UnityEngine.SceneManagement;

namespace Assets.Monsters.Scripts.Runtime.Generators.UI
{
    internal class InventoryGenerator : MonoBehaviour
    {
        [SerializeField] private ItemView _itemPrefab;
        [SerializeField] private Button _closeButton;
        
        private int _maxItemsCount = 100;
        private ItemView[] _items;

        private void OnEnable()
        {
            SubscribeEvents();
            GenerateItems();
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        private void OnShowItems(OpenInventorySignal signal)
        {
            AddedMonster();
            ResetItems();
            
            for (int i = 0; i < Core.Player.Instance.Items.Count; i++)
                _items[i].Init(Core.Player.Instance.Items[i]);
        }

        private void GenerateItems()
        {
            if (!_items.HasValue())
            {
                _items = new ItemView[_maxItemsCount];

                for (int i = 0; i < _maxItemsCount; i++)
                    _items[i] = Instantiate(_itemPrefab, transform);
            }
        }

        private void ResetItems()
        {
            foreach (var item in _items)
                item.Init();
        }

        private void OnCloseButtonClick()
        {
            SignalBus.Instance.Invoke(new CloseInventorySignal());
        }

        private void SubscribeEvents()
        {
            SignalBus.Instance.Subscribe<OpenInventorySignal>(OnShowItems);
            SignalBus.Instance.Subscribe<StartBattleSignal>(ShowBattle);
            _closeButton.onClick.AddListener(OnCloseButtonClick);
        }

        private void UnsubscribeEvents()
        {
            SignalBus.Instance.Unsubscribe<OpenInventorySignal>(OnShowItems);
            SignalBus.Instance.Unsubscribe<StartBattleSignal>(ShowBattle);
            _closeButton.onClick.RemoveListener(OnCloseButtonClick);
        }

        //////////////////////////////////////test
        private MonsterHelper monsterHelper = new MonsterHelper();
        private void AddedMonster()
        {
            var monsterConfig = StorageManager.Instance.GetMonsterConfiguration("Миша");
            var monster = monsterHelper.GenerateMonsterData(monsterConfig, StorageManager.Instance.GetAttackConfigurations(monsterConfig.BaseElement));
            Core.Player.Instance.Monsters.Add(monster);
        }

        private void ShowBattle(StartBattleSignal signal)
        {
            var monsterConfig = StorageManager.Instance.GetMonsterConfiguration("Миша");
            MonsterInBattleCrossScene.Monster = monsterHelper.GenerateMonsterData(monsterConfig, StorageManager.Instance.GetAttackConfigurations(monsterConfig.BaseElement));
            SceneManager.LoadScene("Battle");
        }
    }
}
