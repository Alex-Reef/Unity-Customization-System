using CustomizationSystem.Samples.Scripts.ScriptableObjects;
using CustomizationSystem.Scripts.Base;
using CustomizationSystem.Scripts.UiComponents;
using UnityEngine;

namespace CustomizationSystem.Samples.Scripts.Controllers
{
    public class CustomGunColor : MonoBehaviour
    {
        [SerializeField] private CS_ItemsCollection _collection;
        [SerializeField] private Renderer _targetMesh;
        
        private void Awake()
        {
            if (_collection != null)
                _collection.OnCollectionInited += OnInited;
        }

        private void OnInited()
        {
            _collection.OnItemSelected += OnSelected;
        }

        private void OnSelected(CS_SelectableItem obj)
        {
            GunColor gunColor = (GunColor) obj.Object;
            _targetMesh.material.color = gunColor._color;
        }
    }
}