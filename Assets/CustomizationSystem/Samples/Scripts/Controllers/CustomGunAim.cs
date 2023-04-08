using System.Collections.Generic;
using System.Linq;
using CustomizationSystem.Samples.Scripts.ScriptableObjects;
using CustomizationSystem.Scripts.Base;
using CustomizationSystem.Scripts.UiComponents;
using UnityEngine;

namespace CustomizationSystem.Samples.Scripts.Controllers
{
    public class CustomGunAim : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private CS_ItemsCollection _collection;

        private GameObject _currentItem;

        private Dictionary<string, GameObject> _poolObjects;

        private void Awake()
        {
            _poolObjects = new Dictionary<string, GameObject>();
            if (_collection != null)
                _collection.OnCollectionInited += OnInited;
        }

        private void OnInited()
        {
            _collection.OnItemSelected += OnSelected;
            
            _collection.Items.ForEach(item =>
            {
                var gunItem = (GunItem) item.Object;
                var obj = Instantiate(gunItem._object, _target);
                obj.transform.localPosition = Vector3.zero;
                obj.SetActive(false);
                _poolObjects.Add(gunItem.ItemName,obj);
            });
        }

        private void OnSelected(CS_SelectableItem obj)
        {
            if(_currentItem != null)
                _currentItem.SetActive(false);

            GunItem gunItem = (GunItem) obj.Object;
            var go = _poolObjects.FirstOrDefault(
                _poolObject => _poolObject.Key == gunItem.ItemName);
            if (go.Value != null)
            {
                _currentItem = go.Value;
                go.Value.SetActive(true);
            }
        }
    }
}