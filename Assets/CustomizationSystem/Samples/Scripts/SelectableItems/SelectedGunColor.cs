using CustomizationSystem.Samples.Scripts.ScriptableObjects;
using CustomizationSystem.Scripts.Base;
using CustomizationSystem.Scripts.UiComponents;
using UnityEngine;
using UnityEngine.UI;

namespace CustomizationSystem.Samples.Scripts.SelectableItems
{
    public class SelectedGunColor : CS_SelectableItem
    {
        [SerializeField] private Image _colorImage;
        public override void InitObject(CS_SelectableObjectBase obj)
        {
            GunColor gunColor = (GunColor) obj;
            _colorImage.color = gunColor._color;
            base.InitObject(obj);
        }
    }
}