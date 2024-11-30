
namespace BackgroundServicesUCM.Options
{
    public class OptionKUMA
    {
        public bool RunService { get; set; } = false;
        public int DataRequestFrequency { get; set; } = 60 * 60 * 1000;
    }
}