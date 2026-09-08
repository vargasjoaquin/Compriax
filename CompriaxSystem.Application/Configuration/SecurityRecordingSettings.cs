namespace CompriaxSystem.Application.Configuration
{
    public class SecurityRecordingSettings
    {
        public int StoreOpenHour { get; set; }
        public int StoreCloseHour { get; set; }
        public int SegmentHours { get; set; }
        public double RecordingFps { get; set; }
        public int CameraIndex { get; set; }
        public string? RecordingsRootPath { get; set; }
    }
}
