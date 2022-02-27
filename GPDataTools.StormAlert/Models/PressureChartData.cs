namespace GPDataTools.StormAlert.ViewModels;

public class PressureChartData
{
    // 3 Hour scale bucket
    public int Bucket { get; }

    // hPA atmospheric pressure
    public double Pressure { get; }

    public PressureChartData(int bucket, double pressure)
    {
        this.Bucket = bucket;
        this.Pressure = pressure;
    }
}