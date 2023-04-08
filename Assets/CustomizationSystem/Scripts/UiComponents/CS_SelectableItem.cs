using System;
using CustomizationSystem.Scripts.Base;
using UnityEngine;
using UnityEngine.UI;

namespace CustomizationSystem.Scripts.UiComponents
{
    public abstract class CS_SelectableItem : MonoBehaviour
    {
        [SerializeField] private Button _button;
        private bool _isSelected;
        private CS_SelectableObjectBase _object;

        public CS_SelectableObjectBase Object => _object;
        public bool IsSelected => _isSelected;
        public Action<CS_SelectableItem> OnItemSelected;

        public virtual void Select()
        {
            _isSelected = true;
            OnItemSelected?.Invoke(this);
        }

        public virtual void Deselect()
        {
            _isSelected = false;
        }

        public void Initialize(CS_SelectableItemConfig config)
        {
            InitButton();
        }

        public virtual void InitObject(CS_SelectableObjectBase obj)
        {
            _object = obj;
        }

        protected virtual void InitButton()
        {
            if(_button != null)
                _button.onClick.AddListener(Select);
        }
    }
}
