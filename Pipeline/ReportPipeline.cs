namespace IntelligencePipeline.Pipeline;

using IntelligencePipeline;
using IntelligencePipeline.Calculators;
using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Storage;
using IntelligencePipeline.Validation;

class ReportPipeline
{
    private ReportRepository _validatedReports;
    private RejectedReportRepository _rejectedReports;
    private int _nextReportId;

    public int NextReportId { get => _nextReportId; }

    public ReportPipeline()
    {
        _validatedReports = new ReportRepository();
        _rejectedReports = new RejectedReportRepository();
        _nextReportId = 1;
    }

    //process the reports
    public void ProcessReport(Report report)
    {
        report.Status = ReportStatus.Validating;
        BaseValidator validate = GetValidator(report);
        ValidationResult validator = ValidateReport(validate, report);

        if (!validator.IsValid)
        {
            report.Status = ReportStatus.Rejected;
            report.setRejectionReason(validator.ErrorMessage);
            _rejectedReports.Add(report);
            return;
        }
        else
        {
            report.Status = ReportStatus.Validated;
            CalculateMetrics(report);
            StoreReport(report);
            _nextReportId += 1;
        }
    }

    //GetAll returns List<Report> - so i chainged the methods return type.
    public List<Report> GetValidatedReports()
    {
        return _validatedReports.GetAll();
    }


    //GetAll returns List<Report> - so i chainged the methods return type.
    public List<Report> GetRejectedReports()
    {
        return _rejectedReports.GetAll();
    }

    public void DisplayStatistics()
    {
        Console.WriteLine($"Valid reports: {_validatedReports.GetTotalCount()} | Validated: {_validatedReports.GetCountByStatus(ReportStatus.Validated)}");
    }

    //I changed return type from Ivalidate to BaseValidor cuz we 
    private BaseValidator GetValidator(Report report)
    {
        if (report.GetSourceType() == "Drone")
            return new DroneValidator();
        if (report.GetSourceType() == "Soldier")
            return new SoldierValidator();
        if (report.GetSourceType() == "Signal")
            return new SignalValidator();
        return new RadarValidator();

    }

    //validates report and puts it in currect storage. changed return type to return 
    //ValidationResult to contenue process
    private ValidationResult ValidateReport(BaseValidator validator, Report report)
    {
        ValidationResult validate = validator.ValidateSpecificFields(report);
        return validate;
    }

    private void CalculateMetrics(Report report)
    {
        report.ReliabilityScore = report.CalculateReliabilityScore();
        report.Priority = new PriorityCalculator().Calculate(report);
        report.Classification = new ClassificationCalculator().Calculate(report);
    }

    private void StoreReport(Report report)
    {
        _validatedReports.Add(report);
    }
}