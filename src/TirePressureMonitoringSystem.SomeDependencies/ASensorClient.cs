using System;
using TDDMicroExercises.TirePressureMonitoringSystem.Interfaces;

namespace TDDMicroExercises.TirePressureMonitoringSystem.SomeDependencies
{
    public class ASensorClient      
    {
        // A class with the only goal of simulating a dependency on Sensor
        // that has impact on the refactoring.

        public ASensorClient(ISensor sensor)
        {
			double value = sensor.PopNextPressurePsiValue();
			value = sensor.PopNextPressurePsiValue();
			value = sensor.PopNextPressurePsiValue();
			value = sensor.PopNextPressurePsiValue();
		}
    }
}
