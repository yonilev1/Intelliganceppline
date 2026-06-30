using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Validation;
using System.ComponentModel.DataAnnotations;

class DroneValidator: IValidator
{
    public ValidationResult Validate(Report report)
    {
        return report.GetSourceType() == "Drone" && report.Altitude >= 100 && report.Altitude <= 10000 && report.ImageQuality >= 1 && report.ImageQuality <= 100;
    }
}