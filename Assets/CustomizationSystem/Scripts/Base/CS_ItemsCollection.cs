using System;
using System.Collections.Generic;
using CustomizationSystem.Scripts.UiComponents;
using UnityEngine;

namespace CustomizationSystem.Scripts.Base
{
    public class CS_ItemsCollection : MonoBehaviour
    {
        [SerializeField] private CS_SelectableObjectBase[] _objects;
        [SerializeField] private CS_SelectableItem _itemPrefab;
        [SerializeField] private CS_SelectableItemConfig _config;
        [SerializeField] private Transform _target;
        
        private List<CS_SelectableItem> _selectedItems;
        
        public event Action<CS_SelectableItem> OnItemSelected;
        public event Action OnCollectionInited;
        
        public CS_SelectableItem SelectedItem => _selectedItems[0];
        public CS_SelectableItem[] SelectedItems => _selectedItems.ToArray();

        private List<CS_SelectableItem> _items;
        public List<CS_SelectableItem> Items => _items;
        
        private void Awake()
        {
            _selectedItems = new List<CS_SelectableItem>(){ null };
            _items = new List<CS_SelectableItem>();
            
            foreach (var obj in _objects)
            {
                var item = Instantiate(_itemPrefab, _target);
                item.InitObject(obj);
                item.Initialize(_config);
                item.OnItemSelected += ItemSelected;
                _items.Add(item);
            }
            
            OnCollectionInited?.Invoke();
        }

        private void ItemSelected(CS_SelectableItem obj)
        {
            if (_config.UseMultiselect)
                _selectedItems.Add(obj);
            else
            {
                _selectedItems[0] = obj;
                DeselectExcept(obj);
            }
            
            OnItemSelected?.Invoke(obj);
        }

        private void DeselectExcept(CS_SelectableItem obj)
        {
            _items.ForEach(item =>
            {
                if(item != obj)
                    item.Deselect();
            });
        }
    }
}