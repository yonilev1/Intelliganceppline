using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Validation;
using System.ComponentModel.DataAnnotations;

class SignalValidator : BaseValidator
{
    //validate common, validate specific and return success or error message
    public override ValidationResult ValidateSpecificFields(Report report)
    {
        ValidationResult commonValid = Validate(report);
        if (commonValid.IsValid)
        {
            if (report.GetSourceType() == "Signal")
            {
                SignalReport sr = (SignalReport)report;
                if (sr.Frequency >= 1.0 && sr.Frequency <= 3000.0)
                {
                    if (sr.Content.Length >= 5 && sr.Content.Length <= 1000)
                    {
                        //language is allready validated after users input (ENUM)
                        if (sr.SignalStrength >= -120 && sr.SignalStrength <= 0)
                        {
                            return ValidationResult.Success();
                        }
                        else
                            return ValidationResult.Failure("Invalid SignalStrength: must be between -120 - 0");
                    }
                    else
                        return ValidationResult.Failure("Invalid Content: Length must be between 5 - 1000");
                }
                else
                    return ValidationResult.Failure("Invalid Frequency: must be between 1.0 - 3000.0");
            }
            else
                return ValidationResult.Failure("Invalid Report Type: must be Signal Report");

        }
        return ValidationResult.Failure(commonValid.ErrorMessage);
    }
}