using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Cl.Intertrade.ActivPay.OAuth.Validators
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false,
     AllowMultiple = false)]
    public sealed class RutAttribute : ValidationAttribute
    {
        public RutAttribute() :
            base("\"{0}\" inválido")
        {
        }

        public override bool IsValid(object value)
        {
            if (value != null && !string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationHelper.IsModule11(value.ToString());
            }
            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(CultureInfo.CurrentCulture,
                ErrorMessageString, name);
        }


    }
}