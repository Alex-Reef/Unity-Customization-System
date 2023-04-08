using CustomizationSystem.Samples.Scripts.ScriptableObjects;
using CustomizationSystem.Scripts.Base;
using CustomizationSystem.Scripts.UiComponents;
using UnityEngine;

namespace CustomizationSystem.Samples.Scripts.SelectableItems
{
    public class SelectedGunItem : CS_SelectableItem
    {
        public override void InitObject(CS_SelectableObjectBase obj)
        {
            GunItem item = (GunItem) obj;
            var child = Instantiate(item._object, transform);
            child.transform.localScale = new Vector3(100, 100, 100);
            child.transform.localPosition = Vector3.zero;
            base.InitObject(obj);
        }
    }
}