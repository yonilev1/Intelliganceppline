namespace IntelligencePipeline.Calculators;

using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;

class PriorityCalculator
{
    public Priority Calculate(Report report)
    {
        if (ContainsKeyword(report.Description, "weapon", "explosion", "attack", "fire") ||
            (report.GetSourceType() == "Radar" && ((RadarReport)report).Speed > 800) ||
            (report.GetSourceType() == "Signal" && ContainsKeyword(((SignalReport)report).Content, "target", "attack")))
        {
            return Priority.Critical;
        }

        if (ContainsKeyword(report.Description, "weapon", "suspicious", "border") ||
            (report.GetSourceType() == "Radar" && ((RadarReport)report).Speed >= 400) ||
            (report.GetSourceType() == "Drone" && ((DroneReport)report).Altitude < 500) ||
            (report.GetSourceType() == "Soldier" && (((SoldierReport)report).ConfidenceLevel >= 4)))
        {
            return Priority.High;
        }

        if (ContainsKeyword(report.Description, "movement", "vehicle", "activity")||
            (report.GetSourceType() == "Radar" && ((RadarReport)report).Speed >= 120) ||
            report.ReliabilityScore >= 7)
        {
            return Priority.Medium;
        }

        return Priority.Low;
    }

    //check if text contains one of a few words, returns true or false
    private bool ContainsKeyword(string text, params string[] keywords)
    {
        foreach (string word in keywords)
        {
            if (text.Contains(word, StringComparison.OrdinalIgnoreCase))
                return true;
        }
        return false;
    }
}