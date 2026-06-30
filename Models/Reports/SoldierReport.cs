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
        protected set
        {
                _soldierName = value;
        }
    }

    public string SoldierID
    {
        get => _soldierID;
        protected set
        {
                _soldierID = value;
        }
    }

    public string Unit
    {
        get => _unit;
        protected set
        {
                _unit = value;
        }
    }

    public int ConfidenceLevel
    {
        get => _confidenceLevel;
        protected set
        {
                _confidenceLevel = value;
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