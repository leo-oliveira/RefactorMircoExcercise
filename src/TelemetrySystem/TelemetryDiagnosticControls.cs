
using System;
using TDDMicroExercises.TelemetrySystem.Interfaces;

namespace TDDMicroExercises.TelemetrySystem
{
    public class TelemetryDiagnosticControls
    {
        public string DiagnosticChannelConnectionString { get; set; }

        private readonly ITelemetryClient _telemetryClient;
        private string _diagnosticInfo = string.Empty;

        public TelemetryDiagnosticControls(ITelemetryClient telemetryClient)
        {
            _telemetryClient = telemetryClient;
        }

        public string DiagnosticInfo
        {
            get { return _diagnosticInfo; }
            set { _diagnosticInfo = value; }
        }

        public void CheckTransmission()
        {
            _diagnosticInfo = string.Empty;

            _telemetryClient.Disconnect();

            int retryLeft = 3;
            while (_telemetryClient.OnlineStatus == false && retryLeft > 0)
            {
                _telemetryClient.Connect(DiagnosticChannelConnectionString);
                retryLeft -= 1;
            }
             
            if(_telemetryClient.OnlineStatus == false)
            {
                throw new Exception("Unable to connect.");
            }

            _telemetryClient.Send(_telemetryClient.DiagnosticMessage);
            _diagnosticInfo = _telemetryClient.Receive();
        }
    }
}
