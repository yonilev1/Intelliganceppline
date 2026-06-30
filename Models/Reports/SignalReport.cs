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
        protected set
        {
                _frequency = value;
        }
    }

    public string Content
    {
        get => _content;
        protected set
        {
                _content = value;
        }
    }

    public Language Language
    {
        get => _language;
        protected set
        {
            _language = value;
        }
    }

    public int SignalStrength
    {
        get => _signalStrength;
        protected set
        {
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