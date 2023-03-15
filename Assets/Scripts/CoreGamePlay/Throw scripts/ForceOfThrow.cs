using UnityEngine;
namespace KNH23.CoreGamePlay
{
    public class ForceOfThrow 
    {
        private Vector2 _Force;

        public Vector2 LowForce()
        {
            _Force = new Vector2(0, 20);
            return _Force;
        }

        public Vector2 MidForce()
        {
            _Force = new Vector2(0, 25);
            return _Force;
        }

        public Vector2 HiForce()
        {
            _Force = new Vector2(0, 35);
            return _Force;
        }
    }
}
