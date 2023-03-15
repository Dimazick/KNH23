using UnityEngine;
using UnityEngine.EventSystems;

namespace KNH23.InputSystem
{
    public  class InputSystem : MonoBehaviour
    {
        [SerializeField] private Touch _touch;
        private PointerEventData _eventData;

                        
        public Vector2 ReturnTouchCoordinate()
        {
            return _touch.ReturnTouchCoordinate(_eventData);
           
        }
    }
}
