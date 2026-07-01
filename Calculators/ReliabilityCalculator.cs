namespace IntelligencePipeline.Calculators;

using IntelligencePipeline.Models.Reports;
class ReliabilityCalculator
{
    public int Calculate(Report report)
    {
        int ReliabilityScore = report.CalculateReliabilityScore();
        if (ReliabilityScore > 10)
            return 10;
        else if (ReliabilityScore < 1)
            return 1;
        return ReliabilityScore;
    }
}