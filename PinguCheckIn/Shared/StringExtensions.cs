using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PinguCheckIn.Shared
{
    public static class StringExtensions
    {
        public static string GetValue(this string line, int size, char charFormat = ' ')
        {
            if (string.IsNullOrEmpty(line))
            {
                return string.Empty;
            }


            var value = (line.Length > size ? line.Substring(0, size) : line);

            if (charFormat != ' ')
            {
                var formato = "{0:" + new string(charFormat, size) + "}";
                var result = string.Format(formato, value);
                return result;
            }

            return value;
        }

        public static string GetValue(this int line, int size, char charFormat = ' ')
        {
            if (line <= 0)
            {
                return string.Empty;
            }

            var texto = line.ToString();

            var value = (texto.Length > size ? texto.Substring(0, size) : line.ToString());

            if (charFormat != ' ')
            {
                var formato = "{0:" + new string(charFormat, size) + "}";
                var result = string.Format(formato, Convert.ToInt64(value));
                return result;
            }

            return value;
        }

        public static string GetValue(this int? line, int size, char charFormat = ' ')
        {
            if (!line.HasValue)
            {
                return string.Empty;
            }

            var texto = line.ToString();

            var value = (texto.Length > size ? texto.Substring(0, size) : line.ToString());

            if (charFormat != ' ')
            {
                var formato = "{0:" + new string(charFormat, size) + "}";
                var result = string.Format(formato, Convert.ToInt64(value));
                return result;
            }

            return value;
        }

        public static string GetValue(this decimal line, int size, char charFormat = ' ')
        {
            if (line <= 0)
            {
                return string.Empty;
            }

            var texto = line.ToString();

            var value = (texto.Length > size ? texto.Substring(0, size) : line.ToString());

            if (charFormat != ' ')
            {
                var formato = "{0:" + new string(charFormat, size) + "}";
                var result = string.Format(formato, Convert.ToDecimal(value));
                return result;
            }

            return value;
        }

        public static string GetValue(this decimal? line, int size, char charFormat = ' ')
        {
            if (!line.HasValue)
            {
                return string.Empty;
            }

            var texto = line.ToString();

            var value = (texto.Length > size ? texto.Substring(0, size) : line.ToString());

            if (charFormat != ' ')
            {
                var formato = "{0:" + new string(charFormat, size) + "}";
                var result = string.Format(formato, Convert.ToDecimal(value));
                return result;
            }

            return value;
        }


        public static string GetValueWithFormatting(this string line, int size, string format = "")
        {
            if (string.IsNullOrEmpty(line))
            {
                return string.Empty;
            }

            var value = (line.Length > size ? line.Substring(0, size) : line);

            if (!string.IsNullOrEmpty(format))
            {
                var result = string.Format(format, value);
                return result;
            }

            return value;
        }

        public static string GetValueWithFormatting(this int? line, int size, string format = "")
        {
            if (!line.HasValue)
            {
                return string.Empty;
            }

            var texto = line.Value.ToString();

            var value = (texto.Length > size ? texto.Substring(0, size) : line.Value.ToString());

            if (!string.IsNullOrEmpty(format))
            {
                var result = string.Format(format, Convert.ToInt64(value));
                return result;
            }

            return value;
        }

        public static string GetValue(this long? line, int size, char charFormat = ' ')
        {
            if (!line.HasValue)
            {
                return string.Empty;
            }

            var texto = line.Value.ToString();

            var value = (texto.Length > size ? texto.Substring(0, size) : line.Value.ToString());

            if (charFormat != ' ')
            {
                var formato = "{0:" + new string(charFormat, size) + "}";
                var result = string.Format(formato, Convert.ToInt64(value));
                return result;
            }

            return value;
        }

        public static string GetValueWithFormatting(this decimal? line, int size, string format = "")
        {
            if (!line.HasValue)
            {
                return string.Empty;
            }

            var texto = line.Value.ToString();

            var value = (texto.Length > size ? texto.Substring(0, size) : line.Value.ToString());

            if (!string.IsNullOrEmpty(format))
            {
                var result = string.Format(format, Convert.ToDecimal(value));
                return result;
            }

            return value;
        }


        public static string GetValue(this DateTime? line, int size, string format = "")
        {
            if (!line.HasValue)
            {
                return string.Empty;
            }

            if (!string.IsNullOrEmpty(format))
            {
                var result = string.Format(format, line);
                return result;
            }

            return line.ToString();
        }


        public static string GetValueWithFormatting(this int line, int size, string format = "")
        {
            if (line <= 0)
            {
                return string.Empty;
            }

            var texto = line.ToString();

            var value = (texto.Length > size ? texto.Substring(0, size) : line.ToString());

            if (!string.IsNullOrEmpty(format))
            {
                var result = string.Format(format, Convert.ToInt64(value));
                return result;
            }

            return value;
        }

        public static string GetValueWithFormatting(this decimal line, int size, string format = "")
        {
            if (line <= 0)
            {
                return string.Empty;
            }

            var texto = line.ToString();

            var value = (texto.Length > size ? texto.Substring(0, size) : line.ToString());

            if (!string.IsNullOrEmpty(format))
            {
                var result = string.Format(format, Convert.ToDecimal(value));
                return result;
            }

            return value;
        }

        public static string GetValueWithFormatting(this DateTime? line, int size, string format = "")
        {
            if (!line.HasValue)
            {
                return string.Empty;
            }

            if (!string.IsNullOrEmpty(format))
            {
                var result = string.Format(format, line);
                return result;
            }

            return line.ToString();
        }


        public static string GetValueWithFormatting(this DateTime line, int size, string format = "")
        {
            if (line == DateTime.MinValue)
            {
                return string.Empty;
            }

            if (!string.IsNullOrEmpty(format))
            {
                var result = string.Format(format, line);
                return result;
            }

            return line.ToString();
        }

        public static string removerAcentos(this string texto)
        {
            string comAcentos = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç";
            string semAcentos = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc";

            for (int i = 0; i < comAcentos.Length; i++)
            {
                texto = texto.Replace(comAcentos[i].ToString(), semAcentos[i].ToString());
            }

            return texto;
        }

        public static string GetLast(this string source, int tail_length)
        {
            if (tail_length >= source.Length)
                return source;
            return source.Substring(source.Length - tail_length);
        }


        public static string ReplaceFirst(this string @this, string oldValue, string newValue)
        {
            int startindex = @this.IndexOf(oldValue);

            if (startindex == -1)
            {
                return @this;
            }

            return @this.Remove(startindex, oldValue.Length).Insert(startindex, newValue);
        }

        /// <summary>
        ///     A string extension method that replace first number of occurences.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="number">Number of.</param>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        /// <returns>The string with the numbers of occurences of old value replace by new value.</returns>
        public static string ReplaceFirst(this string @this, int number, string oldValue, string newValue)
        {
            List<string> list = @this.Split(oldValue).ToList();
            int old = number + 1;
            IEnumerable<string> listStart = list.Take(old);
            IEnumerable<string> listEnd = list.Skip(old);

            return string.Join(newValue, listStart) +
                   (listEnd.Any() ? oldValue : "") +
                   string.Join(oldValue, listEnd);
        }

        public static int GetWorkingDays(this DateTime from, DateTime to)
        {
            var dayDifference = (int)to.Subtract(from).TotalDays;
            return Enumerable
                .Range(1, dayDifference)
                .Select(x => from.AddDays(x))
                .Count(x => x.DayOfWeek != DayOfWeek.Saturday && x.DayOfWeek != DayOfWeek.Sunday);
        }
    }
}

