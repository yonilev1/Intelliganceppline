using System;
using IntelligencePipeline.Models.Enums;
namespace IntelligencePipeline.Models.Reports;


class RadarReport : Report
{
    private int _speed;
    private int _direction;
    private int _distance;

    public int Speed
    {
        get => _speed;
        protected set
        {
                _speed = value;
        }
    }

    public int Direction
    {
        get => _direction;
        protected set
        {
                _direction = value;
        }
    }

    public int Distance
    {
        get => _distance;
        protected set
        {
                _distance = value;
        }
    }


    public RadarReport(int reportId, DateTime timestamp, double latitude, double longitude, string description, int speed, int direction, int distance)
        : base(reportId, timestamp, latitude, longitude, description)
    {
        Speed = speed;
        Direction = direction;
        Distance = distance;
    }

    public override string GetSourceType()
        => "Radar";

    public override int CalculateReliabilityScore()
    {
        int BaseCalculation = 6;

        if (Distance >= 500 && Distance <= 30000)
            BaseCalculation += 2;
        else if (Distance > 70000)
            BaseCalculation -= 2;

        if (Speed >= 10 && Speed <= 900)
            BaseCalculation += 1;
        else if (Speed > 1500)
            BaseCalculation -= 2;

        return BaseCalculation;
    }
}