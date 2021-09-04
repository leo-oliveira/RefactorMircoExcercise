using TDDMicroExercises.TirePressureMonitoringSystem.Interfaces;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class Alarm : IAlarm
    {
        private double _lowPressureThreshold = -1;
        private double _highPressureThreshold = -1;

        public double LowPressureThreshold
        {
            get
            {
                if (_lowPressureThreshold < 0) return 17;
                return _lowPressureThreshold;
            }
            set { _lowPressureThreshold = value; }
        }

        public double HighPressureThreshold
        {
            get
            {
                if (_highPressureThreshold < 0) return 21;
                return _highPressureThreshold;
            }
            set { _highPressureThreshold = value; }
        }

        readonly ISensor _sensor;

        bool _alarmOn = false;

        public Alarm(ISensor sensor)
        {
            _sensor = sensor;
        }

        public void Check()
        {
            double psiPressureValue = _sensor.PopNextPressurePsiValue();

            if (psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue)
            {
                _alarmOn = true;
            }
        }

        public bool AlarmOn
        {
            get { return _alarmOn; }
        }

    }
}
