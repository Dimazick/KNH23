using System;
using UnityEngine;

namespace KNH23.CoreGamePlay
{
    public class TargetCollisionDetector : MonoBehaviour, IDetector
    {
        public static event Action OnCollisionWithTarget;

        private Throwing _newTarget;

        public void BehaviourDetector()
        {
            Debug.Log(" Collision with TARGET");
            
           

            OnCollisionWithTarget.Invoke();
        }
                
    }
}
