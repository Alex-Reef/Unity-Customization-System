using CustomizationSystem.Scripts.Base;
using UnityEngine;

namespace CustomizationSystem.Samples.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "GunColor", menuName = "Customization System/GunColor", order = 0)]
    public class GunColor : CS_SelectableObjectBase
    {
        public Color Color;
        public string ItemName;
    }
}