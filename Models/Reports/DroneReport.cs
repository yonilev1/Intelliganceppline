using System;
using IntelligencePipeline.Models.Enums;
namespace IntelligencePipeline.Models.Reports;


class DroneReport: Report
{
    private int _altitude;
    private int _imageQuality;

    int Altitude
    {
        get => _altitude;
        set
        {
            if (value >= 100 && value <= 10000)
                _altitude = value;
            else
                throw new ArgumentException("Invalid DroneReport Altitude");
        }
    }

    int ImageQuality
    {
        get => _imageQuality;
        set
        {
            if (value >= 100 && value <= 10000)
                _imageQuality = value;
            else
                throw new ArgumentException("Invalid DroneReport ImageQuality");
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