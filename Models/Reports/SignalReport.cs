using System;
using IntelligencePipeline.Models.Enums;
namespace IntelligencePipeline.Models.Reports;


class SignalReport : Report
{
    private double _frequency;
    private string _content;
    private Language _language; 
    private int _signalStrength;

    public double Frequency
    {
        get => _frequency;
        set
        {
            if (value >= 1.0 && value <= 3000.0)
                _frequency = value;
        }
    }

    public string Content
    {
        get => _content;
        set
        {
            if (value.Length >= 5 && value.Length <= 1000)
                _content = value;
        }
    }

    public Language Language
    {
        get => _language;
        set
        {
            _language = value;
        }
    }

    public int SignalStrength
    {
        get => _signalStrength;
        set
        {
            if (value >= -120 && value <= 0)
                _signalStrength = value;
        }
    }


    public SignalReport(int reportId, DateTime timestamp, double latitude, double longitude, string description, 
        double frequency, string content, Language language, int signalStrength) 
        : base(reportId, timestamp, latitude, longitude, description)
    {
        Frequency = frequency;
        Content = content;
        Language = language;
        SignalStrength = signalStrength;
    }

    public override string GetSourceType()
        => "Signal";

    public override int CalculateReliabilityScore()
    {
        int BaseCalculation = 5;

        if (SignalStrength >= -40)
            BaseCalculation += 3;
        else if (SignalStrength >= -70)
            BaseCalculation += 2;
        else if (SignalStrength < -100)
            BaseCalculation -= 2;

        if (Description.Contains("attack") || Description.Contains("target") || Description.Contains("border") || Description.Contains("vehicle"))
            BaseCalculation += 1;

        return BaseCalculation;
    }
}