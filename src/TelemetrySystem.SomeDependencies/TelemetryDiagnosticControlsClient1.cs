using System;
using TDDMicroExercises.TelemetrySystem.Interfaces;

namespace TDDMicroExercises.TelemetrySystem.SomeDependencies
{
    public class TelemetryDiagnosticControlsClient1
    {
		// A class with the only goal of simulating a dependency on TelemetryDiagnosticControls
		// that has impact on the refactoring.

		public TelemetryDiagnosticControlsClient1(ITelemetryDiagnosticControls teleDiagnostic)
        {
            teleDiagnostic.CheckTransmission();

            var result = teleDiagnostic.DiagnosticInfo;
        }
    }
}
