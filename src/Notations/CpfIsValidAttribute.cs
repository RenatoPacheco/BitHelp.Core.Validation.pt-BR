using System;
using BitHelp.Core.Type.pt_BR;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.pt_BR.Notations
{
    [AttributeUsage(AttributeTargets.Property |
          AttributeTargets.Field, AllowMultiple = false)]
    public class CpfIsValidAttribute : ListIsValidAttribute
    {
        public CpfIsValidAttribute() : base()
        {
            ErrorMessageResourceName = nameof(Resource.XNotValid);
        }

        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            return CpfType.TryParse(input, out _);
        }
    }
}