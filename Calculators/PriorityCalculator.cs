namespace IntelligencePipeline.Calculators;

using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;

class PriorityCalculator
{
    public Priority Calculate(Report report)
    {
        if (report.Description.Contains("weapon") || report.Description.Contains("explosion") || report.Description.Contains("attack") || report.Description.Contains("fire") ||
            (report.GetSourceType() == "Radar" && ((RadarReport)report).Speed > 800) ||
            (report.GetSourceType() == "Signal" && (((SignalReport)report).Content.Contains("target") || ((SignalReport)report).Content.Contains("attack"))))
        {
            return Priority.Critical;
        }

        if (report.Description.Contains("weapon") || report.Description.Contains("suspicious") || report.Description.Contains("border") ||
            (report.GetSourceType() == "Radar" && ((RadarReport)report).Speed >= 400) ||
            (report.GetSourceType() == "Drone" && ((DroneReport)report).Altitude < 500) ||
            (report.GetSourceType() == "Soldier" && (((SoldierReport)report).ConfidenceLevel >= 4)))
        {
            return Priority.High;
        }

        if (report.Description.Contains("movement") || report.Description.Contains("vehicle") || report.Description.Contains("activity")||
            (report.GetSourceType() == "Radar" && ((RadarReport)report).Speed >= 120) ||
            report.ReliabilityScore >= 7)
        {
            return Priority.Medium;
        }

        return Priority.Low;
    }
}