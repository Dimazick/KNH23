using System;

namespace KNH23.CoreGamePlay
{
    public class LevelMotionData 
    {
        private TargetMotionData[] _motionData;

        public void StartLevel(int level)
        {
            var rand = new Random();
            int dataLength = level * 2;
            for (int i = 0; i < dataLength; i++)
            {
                _motionData[i].SetDuration(rand.Next(1, 3));
                _motionData[i].SetRotationSpeed(rand.Next(150, 450));
            }

        }

    }
}
