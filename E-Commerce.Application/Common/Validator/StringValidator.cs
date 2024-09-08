namespace E_Commerce.Application.Common.Validator
{
    public class StringValidator : AbstractValidator<string>
    {
        /// <summary>
        /// This vaild any string Not empty with maxLength you pass as parm 
        /// </summary>
        /// <param name="maxLength"> Max Length of String </param>
        public StringValidator()
        {
            RuleFor(x => x)
              .NotEmpty()
              .MaximumLength(50);
        }
    }
}
