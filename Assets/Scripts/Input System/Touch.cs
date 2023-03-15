using UnityEngine.EventSystems;
using UnityEngine;
using System;

namespace KNH23.InputSystem
{
    public class Touch : MonoBehaviour, IPointerDownHandler

    {
        public bool IsTouched { get; private set; }
        public Vector2 TouchCoordinate { get; private set; }
        public static event Action OnTouched;

        
        public void OnPointerDown(PointerEventData eventData)
        {
            if (OnTouched != null) 
                OnTouched.Invoke();
            ReturnTouchCoordinate(eventData);
            Debug.Log("Touch down");

        }

        public Vector2 ReturnTouchCoordinate(PointerEventData eventData)
        {
           Debug.Log("ReturnTouchPosition2D is true " + eventData.position.x + " : " + eventData.position.y);
           return new Vector2(eventData.position.x, eventData.position.y);
           
        }
    }
}
