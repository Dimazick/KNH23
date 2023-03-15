namespace KNH23.CoreGamePlay
{
    public class TargetMotionData 
    {
        private int _direction = 1;

        public int LeftDirection()
        {
            _direction = 1;
            return _direction;
        }

        public int RightDirection()
        {
            _direction = -1;
            return _direction;
        }
    }
}
