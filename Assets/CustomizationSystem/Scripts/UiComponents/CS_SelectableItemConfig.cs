using System;
using UnityEngine;

namespace CustomizationSystem.Scripts.UiComponents
{
    [Serializable]
    public class CS_SelectableItemConfig
    {
        [Tooltip("If true, multi-selection will be possible")]
        public bool UseMultiselect;
    }
}