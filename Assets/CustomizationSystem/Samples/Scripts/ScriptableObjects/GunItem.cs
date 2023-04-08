using CustomizationSystem.Scripts.Base;
using UnityEngine;

namespace CustomizationSystem.Samples.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "GunItem", menuName = "Customization System/GunItem", order = 0)]
    public class GunItem : CS_SelectableObjectBase
    {
        public GameObject _object;
        public string ItemName;
    }
}