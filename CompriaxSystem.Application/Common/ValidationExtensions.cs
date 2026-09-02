using FluentValidation.Results;

namespace CompriaxSystem.Application.Common
{
    public static class ValidationExtensions
    {
        public static OperationResult ToResult(this ValidationResult result)
        {
            if (result.IsValid)
                return OperationResult.Ok();

            var errors = string.Join(", ", result.Errors.Select(e => e.ErrorMessage));
            return OperationResult.Failure(errors);
        }
    }
}
