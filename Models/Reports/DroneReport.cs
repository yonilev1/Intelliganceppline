using System;
using IntelligencePipeline.Models.Enums;
namespace IntelligencePipeline.Models.Reports;


class DroneReport: Report
{
    private int _altitude;
    private int _imageQuality;

    public int Altitude
    {
        get => _altitude;
        protected set
        {
                _altitude = value;
        }
    }

    public int ImageQuality
    {
        get => _imageQuality;
        protected set
        {
                _imageQuality = value;
        }
    }

    public DroneReport(int reportId, DateTime timestamp, double latitude, double longitude, string description, int altitude, int imageQuality)
        : base(reportId, timestamp, latitude, longitude, description)
    {
        Altitude = altitude;
        ImageQuality = imageQuality;
    }

    public override string GetSourceType() 
        => "Drone";

    //calculates and returns reliability score by parameters
    public override int CalculateReliabilityScore()
    {
        int BaseCalculation = 5;

        if (ImageQuality >= 80)
            BaseCalculation += 3;
        else if (ImageQuality >= 50)
            BaseCalculation += 2;

        if (Altitude >= 500 && Altitude <= 3000)
            BaseCalculation += 2;
        else if (Altitude > 7000)
            BaseCalculation -= 2;

        return BaseCalculation;
    }
}