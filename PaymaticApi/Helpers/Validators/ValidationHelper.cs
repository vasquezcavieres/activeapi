using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Cl.Intertrade.ActivPay.OAuth.Validators
{
    public static class StringExtension
    {
        public static string CleanScriptPoint(this string str)
        {
            return Regex.Replace(str, @"[^0-9a-zA-Z]+", "");
        }

        public static string CleanPoint(this string str)
        {
            return Regex.Replace(str, @"[^0-9a-zA-Z\-]+", "");
        }

        public static string Repeat(this string str, char separator, int count)
        {
            if (count == 0)
                count = 1;
            return string.Join(separator, Enumerable.Repeat(str, count));
        }


        public static string TrimAndReduce(this string str)
        {
            return ConvertWhitespacesToSingleSpaces(str).Trim();
        }

        public static string ConvertWhitespacesToSingleSpaces(this string value)
        {
            return Regex.Replace(value, @"\s+", " ");
        }
    }
    public static class ValidationHelper
    {
        public static string CalculoDV11(string rut)
        {
            string dvRut;
            long num2 = 0L;
            long num3 = 0L;
            long num4 = 0L;
            try
            {
                rut = rut.Trim();
                for (int i = 1; i <= rut.Length; i++)
                {
                    num3 = ((i + 5) % 6) + 2;
                    num2 += long.Parse(rut.Substring((rut.Length - (i - 1)) - 1, 1)) * num3;
                }
                num4 = num2 % 11L;
                if (num4 != 0L)
                {
                    num4 = 11L - num4;
                }
                if (num4 == 10L)
                {
                    return "K";
                }
                dvRut = num4.ToString().Trim();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return dvRut;
        }

        public static bool IsEmail(string email)
        {
            bool result;
            string pattern = "";
            Regex regex = null;
            try
            {
                pattern = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                regex = new Regex(pattern);
                if (regex.IsMatch(email))
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return result;
        }

        public static bool EsPatente(string value)
        {
            Regex regex = new Regex(@"([^. \s'@AEIMNOQUaeimnoqu,0123456789-]{4}\d{2})|([^.\s'@,0123456789-]{2}\d{4})|([^.\s'@,0123456789-]{3}\d{3})");
            return regex.IsMatch(value);
        }

        public static bool EsFormatoMotor(string value)
        {
            //Regex regex = new Regex(@"([^\W])\1{4}");
            Regex caracteres = new Regex(@"\W");
            bool val = false;
            if (!caracteres.IsMatch(value))
            {
                Regex regex = new Regex(@"([a-z0-9])\1{4}");
                val = regex.IsMatch(value);
            }
            return val;
        }

        public static bool IsInteger(string value)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(value);
        }

        public static bool IsDecimal(string value)
        {
            decimal number;
            return Decimal.TryParse(value, out number);
        }

        public static bool IsDate(string date)
        {
            DateTime dateTime;
            return DateTime.TryParse(date, out dateTime);
        }

        public static bool IsModule11(string rut)
        {
            string dvRut = rut.Substring(rut.Length - 1, 1);
            long num2 = 0L;
            long num3 = 0L;
            long num4 = 0L;
            try
            {
                while (rut.StartsWith("0"))
                {
                    rut = rut.Substring(1);
                }
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                rut = rut.Substring(0, rut.Length - 1);
                rut = rut.Trim();
                for (int i = 1; i <= rut.Length; i++)
                {
                    num3 = ((i + 5) % 6) + 2;
                    num2 += long.Parse(rut.Substring((rut.Length - (i - 1)) - 1, 1)) * num3;
                }
                num4 = num2 % 11L;
                if (num4 != 0L)
                {
                    num4 = 11L - num4;
                }
                string str2 = num4.ToString().Trim();
                if (num4 == 10L)
                {
                    str2 = "K";
                }
                return str2.Equals(dvRut, StringComparison.OrdinalIgnoreCase);
            }
            catch
            {
                return false;
            }
        }

    }


}