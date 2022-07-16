using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace NOM.Common.Lib
{
    public class Validate
    {
        public struct RegexDefine
        {
            public const string Email = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            public const string Year = @"^\d{4}$";
            public const string Interger = @"^\d*$";//"^0|([1-9]+[0-9]*)$";
            public const string IntergerAm = @"^((\-\d+)|(\d*))$";//@"^0|(\-?[1-9]+[0-9]*)$";
            public const string Numeric = @"^(\d+(\.\d+)?)$";
            public const string NumericAm = @"^(\-?\d+(\.\d+)?)$";
            public const string PhoneNumber = @"^(\+?[0-9\s\-\.]{9,15})$";
            public const string AscII = @"^([a-zA-Z\s]+)$";
            public const string Unicode = "^([\u00c0-\u020f\u1ea0-\u1ef9a-zA-Z0-9_\\-\\.\\s]*)$";
            public const string Code = @"^[a-zA-Z0-9_\-\.]+$";
            public const string CodeVN = "^[\u00c0-\u020fa-zA-Z0-9_\\-\\.]+$";
            public const string CharacterNumber = @"^[a-zA-Z0-9]+$";
            public const string LstCodeVN = "^[\u00c0-\u020fa-zA-Z0-9_\\-\\.\\,]+$";
            public const string CardNumber = @"^[a-zA-Z0-9_ \-\.]+$";
            public const string DateVN = @"^((((31\/(0?[13578]|1[02]))|((29|30)\/(0?[1,3-9]|1[0-2])))\/(1[6-9]|[2-9]\d)?\d{2})|(29\/0?2\/(((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))|(0?[1-9]|1\d|2[0-8])\/((0?[1-9])|(1[0-2]))\/((1[6-9]|[2-9]\d)?\d{2}))$";
            public const string DateTimeVN = @"^((((31\/(0?[13578]|1[02]))|((29|30)\/(0?[1,3-9]|1[0-2])))\/(1[6-9]|[2-9]\d)?\d{2})|(29\/0?2\/(((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))|(0?[1-9]|1\d|2[0-8])\/((0?[1-9])|(1[0-2]))\/((1[6-9]|[2-9]\d)?\d{2}))\s([0-1]?[0-9]|2[0-3]):[0-5][0-9]$";
            public const string DateIso = @"^$";
            public const string MaSoThue = @"^([a-zA-Z0-9\s\-]*)$";
            public const string Time24 = "^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$";
            public const string Time12VN = "^(0?[0-9]|1[0-2]):[0-5][0-9] (SA|CH)$";
            public const string Time12EN = "^(0?[0-9]|1[0-2]):[0-5][0-9] (AM|PM)$";
            public const string Guid = "^\\{?[a-fA-F\\d]{8}-([a-fA-F\\d]{4}-){3}[a-fA-F\\d]{12}\\}?$";
            public const string Boolean = "^(true|false)$";
        }

        public struct MaxMinValue
        {
            public const string IntStrMax = "2147483647";
            public const int IntLenMax = 10;
            public const string DecimalStrMax = "999999999999999999.999";
            public const int DecimalLenMax = 20;
        }

        public static Regex RgxInterger = new Regex(RegexDefine.Interger, RegexOptions.None);
        public static Regex RgxNumber = new Regex(RegexDefine.Numeric, RegexOptions.None);
        public static Regex RgxDateVn = new Regex(RegexDefine.DateVN, RegexOptions.None);
        public static Regex RgxDateTimeVn = new Regex(RegexDefine.DateTimeVN, RegexOptions.None);
        public static Regex RgxDateIso = new Regex(RegexDefine.DateIso, RegexOptions.None);
        public static Regex RgxGuid = new Regex(RegexDefine.Guid, RegexOptions.IgnoreCase);
        public static Regex RgxBoolean = new Regex(RegexDefine.Boolean, RegexOptions.IgnoreCase);

        public static bool IsInterger(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;
            var valCheck = value.TrimStart('0');
            if (valCheck.Length > MaxMinValue.IntLenMax)
                return false;
            if (RgxInterger.IsMatch(value))
            {
                if (valCheck.Length < MaxMinValue.IntLenMax || MaxMinValue.IntStrMax.CompareTo(valCheck) >= 0)
                    return true;
            }
            return false;
        }

        public static int ConvertInt(string value, int defaultValue = 0)
        {
            if (IsInterger(value))
                return Convert.ToInt32(value);
            return defaultValue;
        }

        public static int? ConvertIntAlowNull(string value, int? defaultValue = null)
        {
            if (IsInterger(value))
                return Convert.ToInt32(value);
            else
                return defaultValue;
        }

        public static byte ConvertByte(string value, byte defaultValue = 0)
        {
            if (IsInterger(value))
                return Convert.ToByte(value);
            else
                return defaultValue;
        }

        public static byte? ConvertByteAlowNull(string value, byte? defaultValue = null)
        {
            if (IsInterger(value))
                return Convert.ToByte(value);
            else
                return defaultValue;
        }

        public static short ConvertShort(string value, short defaultValue = 0)
        {
            if (IsInterger(value))
                return Convert.ToInt16(value);
            else
                return defaultValue;
        }

        public static short? ConvertShortAlowNull(string value, short? defaultValue = null)
        {
            if (IsInterger(value))
                return Convert.ToInt16(value);
            else
                return defaultValue;
        }

        public static long ConvertLong(string value, long defaultValue = 0)
        {
            if (IsInterger(value))
                return Convert.ToInt64(value);
            else
                return defaultValue;
        }

        public static long? ConvertLongAlowNull(string value, long? defaultValue = null)
        {
            if (IsInterger(value))
                return Convert.ToInt64(value);
            else
                return defaultValue;
        }

        public static bool IsNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;
            return RgxNumber.IsMatch(value);
        }

        public static bool IsDecimal(string value, char dot = '.')
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;
            return Regex.IsMatch(value, @"^\d{1,18}(\" + dot + @"\d{1,3})?$");
        }

        public static decimal ConvertDecimal(string value, decimal defaultValue = 0, char dot = '.')
        {
            CultureInfo myCIintl = new CultureInfo("en-US", false);
            if (IsDecimal(value, dot))
            {
                if (dot == '.')
                    return Convert.ToDecimal(value, myCIintl);
                else
                    return Convert.ToDecimal(value.Replace(dot, '.'), myCIintl);
            }
            else
                return defaultValue;
        }

        public static decimal? ConvertDecimalAlowNull(string value, decimal? defaultValue = null, char dot = '.')
        {
            CultureInfo myCIintl = new CultureInfo("en-US", false);
            if (IsDecimal(value, dot))
            {
                if (dot == '.')
                    return Convert.ToDecimal(value, myCIintl);
                else
                    return Convert.ToDecimal(value.Replace(dot, '.'), myCIintl);
            }
            else
                return defaultValue;
        }

        public static double ConvertDouble(string value, double defaultValue = 0, char dot = '.')
        {
            CultureInfo myCIintl = new CultureInfo("en-US", false);
            if (IsDecimal(value, dot))
            {
                if (dot == '.')
                    return Convert.ToDouble(value, myCIintl);
                else
                    return Convert.ToDouble(value.Replace(dot, '.'), myCIintl);
            }
            else
                return defaultValue;
        }

        public static double? ConvertDoubleAlowNull(string value, double? defaultValue = null, char dot = '.')
        {
            CultureInfo myCIintl = new CultureInfo("en-US", false);
            if (IsDecimal(value, dot))
            {
                if (dot == '.')
                    return Convert.ToDouble(value, myCIintl);
                else
                    return Convert.ToDouble(value.Replace(dot, '.'), myCIintl);
            }
            else
                return defaultValue;
        }

        public static bool IsDateVn(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;
            return RgxDateVn.IsMatch(value);
        }

        public static bool IsDateTimeVn(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;
            return RgxDateTimeVn.IsMatch(value);
        }

        public static bool IsGuid(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;
            return RgxGuid.IsMatch(value);
        }

        public static Guid ConvertGuid(string value, Guid? defaultValue = null)
        {
            if (IsGuid(value))
                return new Guid(value);
            else
                return defaultValue ?? Guid.NewGuid();
        }

        public static bool IsBoolean(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;
            return RgxBoolean.IsMatch(value);
        }

        public static bool ConvertBoolean(string value, bool defaultValue = false)
        {
            if (IsBoolean(value))
                return Convert.ToBoolean(value);
            else
                return defaultValue;
        }

        public static DateTime ConvertDateVN(string value, DateTime? defaultValue = null)
        {
            if (IsDateVn(value))
                return DateTime.ParseExact(value, "d/M/yyyy", CultureInfo.InvariantCulture);
            else
                return defaultValue.HasValue ? defaultValue.Value : DateTime.MinValue;
        }

        public static DateTime ConvertDateMonthVN(string value, DateTime? defaultValue = null)
        {
            value = "01/" + value;
            if (IsDateVn(value))
                return DateTime.ParseExact(value, "d/M/yyyy", CultureInfo.InvariantCulture);
            else
                return defaultValue.HasValue ? defaultValue.Value : DateTime.MinValue;
        }

        public static DateTime ConvertDateTimeVN(string value, DateTime? defaultValue = null)
        {
            if (IsDateTimeVn(value))
                return DateTime.ParseExact(value, "d/M/yyyy HH:mm", CultureInfo.InvariantCulture);
            else
                return ConvertDateVN(value, defaultValue);
        }

        public static DateTime? ConvertDateVNAlowNull(string value, DateTime? defaultValue = null)
        {
            if (IsDateVn(value))
                return DateTime.ParseExact(value, "d/M/yyyy", CultureInfo.InvariantCulture);
            else
                return defaultValue;
        }

        public static DateTime ConvertDateVNShortAlowNull(string value, DateTime defaultValue)
        {
            if (IsDateVn(value))
                return DateTime.ParseExact(value, "d/M/yyyy", CultureInfo.InvariantCulture);
            else
                return defaultValue;
        }

        public static DateTime? ConvertDateTimeVNAlowNull(string value, DateTime? defaultValue = null)
        {
            if (IsDateTimeVn(value))
                return DateTime.ParseExact(value, "d/M/yyyy HH:mm", CultureInfo.InvariantCulture);
            else
                return ConvertDateVNAlowNull(value, defaultValue);
        }

        public static bool IsDateIso(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;
            return RgxInterger.IsMatch(value);
        }

        public static DateTime ConvertDateIso(string value, DateTime? defaultValue)
        {
            if (IsDateIso(value))
                return Convert.ToDateTime(value);
            else
                return defaultValue.HasValue ? defaultValue.Value : DateTime.Now;
        }

        public static bool CheckCustom(string pattern, string value)
        {
            return Regex.IsMatch(value, pattern);
        }

        public static DateTime ConvertDate(string value, string format = "d/M/yyy", string DateSeparator = "/")
        {
            DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
            dtfi.ShortDatePattern = format;
            dtfi.DateSeparator = DateSeparator;
            return Convert.ToDateTime(value, dtfi);
        }

        public static DateTime? MaxDate(DateTime? date1, DateTime? date2)
        {
            if (date1.HasValue && date2.HasValue)
            {
                if (date1.Value > date2.Value)
                    return date1;
                return date2;
            }
            if (date1.HasValue)
                return date1;
            if (date2.HasValue)
                return date2;
            return null;
        }

        public static DateTime? MinDate(DateTime? date1, DateTime? date2)
        {
            if (date1.HasValue && date2.HasValue)
            {
                if (date1.Value > date2.Value)
                    return date2;
                return date1;
            }
            if (date1.HasValue)
                return date1;
            if (date2.HasValue)
                return date2;
            return null;
        }
    }
}