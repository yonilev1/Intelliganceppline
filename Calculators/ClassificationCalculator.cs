namespace IntelligencePipeline.Calculators;

using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;

class ClassificationCalculator
{
    public Classification Calculate(Report report)
    {
        //only signal has Content - need to check that it is siganl report
        if ((report.GetSourceType() == "Signal" && ContainsKeyword(((SignalReport)report).Content, "target", "explosion", "missile")) ||
            (report.Priority == Priority.Critical))
        {
            return Classification.TopSecret;
        }

        if (ContainsKeyword(report.Description, "weapon", "border") ||
            (report.Priority == Priority.High) ||
            report.GetSourceType() == "Signal")
        {
            return Classification.Secret;
        }

        if (report.Priority == Priority.Medium  ||
            (report.GetSourceType() == "Soldier"))
        {
            return Classification.Restricted;
        }

        return Classification.Unclassified;
    }

    //check if text contains one of a few words, returns true or false
    private bool ContainsKeyword(string text, params string[] keywords)
    {
        foreach (string word in keywords)
        {
            if (text.Contains(word))
                return true;
        }
        return false;
    }
}