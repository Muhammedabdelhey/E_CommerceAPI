namespace E_Commerce.Application.Common.Validator
{
    public static class StringValidator
    {
        /// <summary>
        /// This vaild any string Not empty with maxLength you pass as parm 
        /// </summary>
        /// <param name="maxLength"> Max Length of String </param>
        public static IRuleBuilderOptions<T, string> ValidateString<T>(this IRuleBuilder<T, string> ruleBuilder, int maxLength)
        {
            return ruleBuilder
                .NotEmpty()
                .MaximumLength(maxLength);
        }
    }
}
