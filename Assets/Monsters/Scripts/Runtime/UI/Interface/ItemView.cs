using Assets.Monsters.Scripts.Core.Constants;
using Assets.Monsters.Scripts.Core.Items;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Monsters.Scripts.Runtime.UI.Interface
{
    internal class ItemView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Image _rarityImage;
        [SerializeField] private Button _takeButton;
        [SerializeField] private TextMeshProUGUI _count;
        [SerializeField] private GameObject _contentCell;
        //[SerializeField] private GameObject _emptyCell;

        public ItemData ItemData { get; private set; }

        public event Action<ItemView> OnTakeItem;

        private void OnEnable()
        {
            _takeButton.onClick.AddListener(Take);
        }

        private void OnDisable()
        {
            _takeButton?.onClick.RemoveListener(Take);
        }

        public void Init()
        {
            ItemData = null;
            _contentCell.SetActive(false);
            //_emptyCell.SetActive(true);
        }

        public void Init(ItemData itemData)
        {
            _contentCell.SetActive(true);
            //_emptyCell.SetActive(false);

            ItemData = itemData;

            if (ItemData.Data != null)
            {
                _count.text = ItemData.Count.ToString();
                _image.sprite = ItemData.Data.Image;
                _rarityImage.color = DictionaryHelper.ColorByRarity[ItemData.Data.Rarity];
            }
            else
            {
                Debug.LogWarning($"Item data is null.");
            }
        }

        private void Take()
        {
            OnTakeItem?.Invoke(this);
        }
    }
}
