using System;
using IntelligencePipeline.Models.Enums;
namespace IntelligencePipeline.Models.Reports;


class SoldierReport : Report
{
    private string _soldierName;
    private string _soldierID;
    private string _unit;
    private int _confidenceLevel;

    public string SoldierName
    {
        get => _soldierName;
        set
        {
            if (value.Length >= 2 && value.Length <= 50)
                _soldierName = value;
            else
                throw new ArgumentException("Invalid SoldierReport SoldierName");
        }
    }

    public string SoldierID
    {
        get => _soldierID;
        set
        {
            if (value.Length == 7 && value[0] != '0')
                _soldierID = value;
            else
                throw new ArgumentException("Invalid SoldierReport SoldierID");
        }
    }

    public string Unit
    {
        get => _unit;
        set
        {
            if (value.Length >= 2 && value.Length <= 50)
                _unit = value;
            else
                throw new ArgumentException("Invalid SoldierReport Unit");
        }
    }

    public int ConfidenceLevel
    {
        get => _confidenceLevel;
        set
        {
            if (value >= 1 && value <= 5)
                _confidenceLevel = value;
            else
                throw new ArgumentException("Invalid SoldierReport ConfidenceLevel");
        }
    }

    public SoldierReport(int reportId, DateTime timestamp, double latitude,double longitude, string description, 
        string soldierName, string soldierID, string unit, int confidenceLevel)
        : base(reportId, timestamp, latitude, longitude, description)
    {
        SoldierName = soldierName;
        SoldierID = soldierID;
        Unit = unit;
        ConfidenceLevel = confidenceLevel;
    }

    public override string GetSourceType() 
        => "Soldier";

    public override int CalculateReliabilityScore()
    {
        int BaseCalculation = 4 + ConfidenceLevel;

        if (Description.Contains("weapon") || Description.Contains("vehicle") || Description.Contains("movement") || Description.Contains("explosion"))
            BaseCalculation += 1;

        return BaseCalculation;
    }
}