using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDMicroExercises.TelemetrySystem.Interfaces
{
    public interface ITelemetryDiagnosticControls
    {
        string DiagnosticChannelConnectionString { get; set; }
        string DiagnosticInfo { get; set; }
        void CheckTransmission();
    }
}
