using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Validation;
using System.ComponentModel.DataAnnotations;

class RadarValidator : BaseValidator
{
    //validate common, validate specific and return success or error message
    public override ValidationResult ValidateSpecificFields(Report report)
    {
        ValidationResult commonValid = Validate(report);
        if (commonValid.IsValid)
        {
            if (report.GetSourceType() == "Radar")
            {
                RadarReport rr = (RadarReport)report;
                if (rr.Speed >= 0 && rr.Speed <= 200)
                {
                        if (rr.Direction >= 0 && rr.Direction <= 359)
                        {
                            if (rr.Distance >= 100 && rr.Distance <= 100000)
                            {
                                return ValidationResult.Success();
                            }
                            else
                                return ValidationResult.Failure("Invalid Distance: must be between 100 - 100000");
                        }
                        else
                            return ValidationResult.Failure("Invalid Direction: must be between 0 - 359");
                }
                else
                    return ValidationResult.Failure("Invalid Speed: must be between 0 - 200");
            }
            else
                return ValidationResult.Failure("Invalid Report Type: must be Radar Report");

        }
        return ValidationResult.Failure(commonValid.ErrorMessage);
    }
}