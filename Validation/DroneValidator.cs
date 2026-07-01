using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Validation;
using System.ComponentModel.DataAnnotations;

class DroneValidator: BaseValidator
{
    protected override ValidationResult ValidateSpecificFields(Report report)
    {
        ValidationResult commonValid = Validate(report);
        if (commonValid.IsValid)
        {
            if (report.GetSourceType() == "Drone")
            {
                DroneReport dr = (DroneReport)report;
                if (dr.Altitude >= 100 && dr.Altitude <= 10000)
                {
                        if (dr.ImageQuality >= 1 && dr.ImageQuality <= 100)
                        {
                                return ValidationResult.Success();
                        }
                        else
                            return ValidationResult.Failure("Invalid ImageQuality: must be between 1 - 100");
                }
                else
                    return ValidationResult.Failure("Invalid Altitude: must be between 100 - 10000");
            }
        }
    }
}