using Assets.Monsters.Scripts.Core.Constants;
using Assets.Monsters.Scripts.Core.Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Monsters.Scripts.Runtime.UI.Interface
{
    internal class ItemView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Image _rarityImage;
        [SerializeField] private TextMeshProUGUI _count;
        [SerializeField] private GameObject _contentCell;
        [SerializeField] private GameObject _emptyCell;

        private ItemData _itemData;

        public void Init()
        {             
            _itemData = null;
            _contentCell.SetActive(false);
            _emptyCell.SetActive(true);
        }

        public void Init(ItemData itemData)
        {
            _contentCell.SetActive(true);
            _emptyCell.SetActive(false);

            _itemData = itemData;

            if (_itemData.Data != null)
            {
                _count.text = _itemData.Count.ToString();
                _image.sprite = _itemData.Data.Image;
                _rarityImage.color = DictionaryHelper.ColorByRarity[_itemData.Data.Rarity];
            }
            else
            {
                Debug.LogWarning($"Item data is null.");
            }
        }
    }
}
