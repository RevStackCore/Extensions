﻿using System;
using System.Text;
using System.Text.RegularExpressions;

namespace RevStackCore.Extensions
{
	public static partial class Extensions
	{
		/// <summary>
		/// Returns Last N chars.
		/// </summary>
		/// <returns>The chars.</returns>
		/// <param name="source">Source.</param>
		/// <param name="tailLength">Tail length.</param>
		public static string LastChars(this string source, int tailLength)
		{
			if (string.IsNullOrEmpty(source))
				return "";
			if (tailLength >= source.Length)
				return source;
			return source.Substring(source.Length - tailLength);
		}

		/// <summary>
		/// Firsts the first N chars.
		/// </summary>
		/// <returns>The chars.</returns>
		/// <param name="source">Source.</param>
		/// <param name="startLength">Start length.</param>
		public static string FirstChars(this string source, int startLength)
		{
			if (string.IsNullOrEmpty(source))
				return "";
			return source.Substring(0, startLength);
		}

		/// <summary>
		/// Trims the first char.
		/// </summary>
		/// <returns>The first char.</returns>
		/// <param name="src">Source.</param>
		public static string TrimFirstChar(this string src)
		{
			if (string.IsNullOrEmpty(src))
				return "";
			return src.Substring(1);
		}

		/// <summary>
		/// Trims the first N Chars.
		/// </summary>
		/// <returns>The first NC hars.</returns>
		/// <param name="src">Source.</param>
		/// <param name="n">N.</param>
		public static string TrimFirstNChars(this string src, int n)
		{
			if (string.IsNullOrEmpty(src))
				return "";
			return src.Substring(n);
		}

		/// <summary>
		/// Trims the last char.
		/// </summary>
		/// <returns>The last char.</returns>
		/// <param name="src">Source.</param>
		public static string TrimLastChar(this string src)
		{
			if (string.IsNullOrEmpty(src))
			{
				return src;
			}
			else
			{
				return src.TrimEnd(src[src.Length - 1]);
			}
		}

		/// <summary>
		/// Trims the last N chars.
		/// </summary>
		/// <returns>The last NC hars.</returns>
		/// <param name="src">Source.</param>
		/// <param name="n">N.</param>
		public static string TrimLastNChars(this string src, int n)
		{
			if (string.IsNullOrEmpty(src))
				return "";
			return src.Substring(0,src.Length - n);
		}

		/// <summary>
		/// Ins the string.
		/// </summary>
		/// <returns><c>true</c>, if string was ined, <c>false</c> otherwise.</returns>
		/// <param name="source">Source.</param>
		/// <param name="value">Value.</param>
		public static bool InString(this string source, string value)
		{
			if (string.IsNullOrEmpty(source))
				return false;
			var index = source.IndexOf(value, StringComparison.Ordinal);
			return (index > -1);
		}

		/// <summary>
		/// Concatenate the specified source, str and separator.
		/// </summary>
		/// <returns>The concatenate.</returns>
		/// <param name="source">Source.</param>
		/// <param name="str">String.</param>
		/// <param name="separator">Separator.</param>
		public static string Concatenate(this string source, string str, string separator)
		{
			if (string.IsNullOrEmpty(source))
				return "";
			if (source.Length > 0)
			{
				source = source + separator + str;
			}
			else
			{
				source = str;
			}

			return source;
		}

		/// <summary>
		/// Tos the title case.
		/// </summary>
		/// <returns>The title case.</returns>
		/// <param name="source">Source.</param>
		public static string ToTitleCase(this string source)
		{
			if (string.IsNullOrEmpty(source))
				return "";
			return source.ToProperCase();
		}

		/// <summary>
		/// Tos the proper case.
		/// </summary>
		/// <returns>The proper case.</returns>
		/// <param name="source">Source.</param>
		public static string ToProperCase(this string source)
		{
			if (string.IsNullOrEmpty(source))
				return "";
			const string pattern = @"(?<=\w)(?=[A-Z])";
			var result = Regex.Replace(source, pattern,
				" ", RegexOptions.None);
			return result.Substring(0, 1).ToUpper() + result.Substring(1);
		}

		/// <summary>
		/// Tos the camel case.
		/// </summary>
		/// <returns>The camel case.</returns>
		/// <param name="source">Source.</param>
		public static string ToCamelCase(this string source)
		{
			if (string.IsNullOrEmpty(source))
				return "";
			source = source.ToTitleCase();
			return source.Substring(0, 1).ToLower() + source.Substring(1);
		}

        /// <summary>
        /// Tos the quoted string.
        /// </summary>
        /// <returns>The quoted string.</returns>
        /// <param name="source">Source.</param>
        public static string ToQuotedString(this string source)
        {
            if (string.IsNullOrEmpty(source))
                source = "";
            string QUOTE = "\"";
            source = source.Replace("\"", "\"\"");
            return QUOTE + source + QUOTE;
        }

        /// <summary>
        /// Tos the yes no string.
        /// </summary>
        /// <returns>The yes no string.</returns>
        /// <param name="source">If set to <c>true</c> source.</param>
        public static string ToYesNoString(this bool source)
        {
            if (source == true) return "Yes";
            else return "No";
        }

        /// <summary>
        /// Tos the csv string.
        /// </summary>
        /// <returns>The csv string.</returns>
        /// <param name="source">Source.</param>
        public static string ToCsvString(this string[] source)
        {
            string separator = ",";
            StringBuilder sb = new StringBuilder();
            foreach (string s in source)
            {
                sb.Append(s.ToQuotedString() + separator);
            }
            string result = sb.ToString();
            return result.TrimLastChar();
        }

		/// <summary>
		/// Tos the wrapped in quotes.
		/// </summary>
		/// <returns>The wrapped in quotes.</returns>
		/// <param name="source">Value.</param>
		public static string ToWrappedInQuotes(this string source)
		{
			if (string.IsNullOrEmpty(source))
				return "";
			return "\"" + source + "\"";
		}

		/// <summary>
		/// Tos the wrapped in single quotes.
		/// </summary>
		/// <returns>The wrapped in single quotes.</returns>
		/// <param name="source">Value.</param>
		public static string ToWrappedInSingleQuotes(this string source)
		{
			if (string.IsNullOrEmpty(source))
				return "";
			return "'" + source + "'";
		}

		/// <summary>
		/// Tos the string first part.
		/// </summary>
		/// <returns>The string first part.</returns>
		/// <param name="source">Source.</param>
		/// <param name="chrSeparator">Chr separator.</param>
		public static string ToStringFirstPart(this string source, char chrSeparator)
		{
			if (string.IsNullOrEmpty(source))
				return "";
			var parts = source.Split(chrSeparator);
			return parts[0];
		}

		/// <summary>
		///     Returns the last part of a split string
		/// </summary>
		/// <param name="source"></param>
		/// <param name="chrSeparator"></param>
		/// <returns></returns>
		public static string ToStringLastPart(this string source, char chrSeparator)
		{
			if (string.IsNullOrEmpty(source))
				return "";
			var parts = source.Split(chrSeparator);
			var length = parts.Length;
			return parts[length - 1];
		}

		/// <summary>
		/// Tos the phrase case.
		/// </summary>
		/// <returns>The phrase case.</returns>
		/// <param name="source">Source.</param>
		public static string ToPhraseCase(this string source)
		{
			if (string.IsNullOrEmpty(source))
				return "";
			return Regex.Replace(source, "[a-z][A-Z]", m => m.Value[0] + " " + char.ToLower(m.Value[1]));
		}

		/// <summary>
		/// Tos the default select value.
		/// </summary>
		/// <returns>The default select value.</returns>
		/// <param name="source">Source.</param>
		public static string ToDefaultSelectValue(this string source)
		{
			if (string.IsNullOrEmpty(source))
				return "";
			if (source.ToLower() == "select")
			{
				return null;
			}
			return source;
		}

		/// <summary>
		/// Tos the possessive case.
		/// </summary>
		/// <returns>The possessive case.</returns>
		/// <param name="src">Source.</param>
		public static string ToPossessiveCase(this string src)
		{
			if (string.IsNullOrEmpty(src))
				return "";
			if (src.LastChars(1).ToLower() == "s") return src + "'";
			else return src + "'s";
		}

		/// <summary>
		/// Tos the html link.
		/// </summary>
		/// <returns>The html link.</returns>
		/// <param name="src">Source.</param>
		public static string ToHtmlLink(this string src)
		{
			if (string.IsNullOrEmpty(src))
				return "";
			return "<a href =\"" + src + "\">" + src + "</a>";
		}

		/// <summary>
		/// Tos the html link.
		/// </summary>
		/// <returns>The html link.</returns>
		/// <param name="src">Source.</param>
		/// <param name="label">Label.</param>
		public static string ToHtmlLink(this string src, string label)
		{
			if (string.IsNullOrEmpty(src))
				return "";
			return "<a href =\"" + src + "\">" + label + "</a>";
		}

		/// <summary>
		/// Tos the ratio value.
		/// </summary>
		/// <returns>The ratio value.</returns>
		/// <param name="src">Source.</param>
		public static decimal ToRatioValue(this decimal src)
		{
			if (src > 1)
			{
				src = src / 100;
			}
			return src;
		}

		/// <summary>
		/// Tos the percentage value.
		/// </summary>
		/// <returns>The percentage value.</returns>
		/// <param name="src">Source.</param>
		public static decimal ToPercentageValue(this decimal src)
		{
			if (src < 1)
			{
				src = src * 100;
			}
			return src;
		}

		/// <summary>
		/// Tos the html line break.
		/// </summary>
		/// <returns>The html line break.</returns>
		/// <param name="src">Source.</param>
		public static string ToHtmlLineBreak(this string src)
		{
			if (string.IsNullOrEmpty(src))
				return "";
			src = src.Replace(Environment.NewLine, "<br>");
			return src;
		}

        /// <summary>
        /// Tos the dollar currency.
        /// </summary>
        /// <returns>The dollar currency.</returns>
        /// <param name="src">Source.</param>
        public static string ToDollarCurrency(this decimal src)
        {
            var curr = String.Format("{0:N}", src);
            curr = "$" + curr;
            return curr;
        }

        /// <summary>
        /// Tos the short date string.
        /// </summary>
        /// <returns>The short date string.</returns>
        /// <param name="src">Source.</param>
        public static string ToShortDateString(this DateTime src)
        {
            return src.ToString("d");
        }
        /// <summary>
        /// Tos the long date string.
        /// </summary>
        /// <returns>The long date string.</returns>
        /// <param name="src">Source.</param>
        public static string ToLongDateString(this DateTime src)
        {
            return src.ToString("D");
        }
        /// <summary>
        /// Tos the short time string.
        /// </summary>
        /// <returns>The short time string.</returns>
        /// <param name="src">Source.</param>
        public static string ToShortTimeString(this DateTime src)
        {
            return src.ToString("t");
        }
        /// <summary>
        /// Tos the long time string.
        /// </summary>
        /// <returns>The long time string.</returns>
        /// <param name="src">Source.</param>
        public static string ToLongTimeString(this DateTime src)
        {
            return src.ToString("T");
        }

        /// <summary>
        /// Tos the date summary.
        /// </summary>
        /// <returns>The date summary.</returns>
        /// <param name="date">Date.</param>
        public static string ToDateSummary(this DateTime? date)
        {
            var src = Convert.ToDateTime(date);
            int month = src.Month;
            int day = src.Day;
            int year = src.Year;
            string strMonth = month.ToFullMonthName();
            return strMonth + " " + day.ToString() + ", " + year.ToString();
        }

        /// <summary>
        /// Tos the date summary.
        /// </summary>
        /// <returns>The date summary.</returns>
        /// <param name="date">Date.</param>
        public static string ToDateSummary(this DateTime date)
        {
            var src = Convert.ToDateTime(date);
            int month = src.Month;
            int day = src.Day;
            int year = src.Year;
            string strMonth = month.ToFullMonthName();
            return strMonth + " " + day.ToString() + ", " + year.ToString();
        }

        /// <summary>
        /// Tos the short date summary.
        /// </summary>
        /// <returns>The short date summary.</returns>
        /// <param name="src">Source.</param>
        public static string ToShortDateSummary(this DateTime src)
        {
            int month = src.Month;
            int day = src.Day;
            string strMonth = month.ToFullMonthName();
            return strMonth + " " + day.ToString();
        }

        public static string ToLongFormattedDateTimeString(this DateTime dt)
        {
            return String.Format("{0:MM/dd/yyyy HH:mm:ss}", dt);
        }

		/// <summary>
		/// Tos the name of the month.
		/// </summary>
		/// <returns>The month name.</returns>
		/// <param name="src">Source.</param>
		public static string ToMonthName(this int src)
		{
			string month = "";
			switch (src)
			{
				case 1:
					month = "Jan";
					break;
				case 2:
					month = "Feb";
					break;
				case 3:
					month = "March";
					break;
				case 4:
					month = "April";
					break;
				case 5:
					month = "May";
					break;
				case 6:
					month = "June";
					break;
				case 7:
					month = "July";
					break;
				case 8:
					month = "Aug";
					break;
				case 9:
					month = "Sep";
					break;
				case 10:
					month = "Oct";
					break;
				case 11:
					month = "Nov";
					break;
				case 12:
					month = "Dec";
					break;
			}

			return month;
		}

        /// <summary>
        /// Tos the name of the month.
        /// </summary>
        /// <returns>The month name.</returns>
        /// <param name="src">Source.</param>
        public static string ToFullMonthName(this int src)
        {
            string month = "";
            switch (src)
            {
                case 1:
                    month = "January";
                    break;
                case 2:
                    month = "February";
                    break;
                case 3:
                    month = "March";
                    break;
                case 4:
                    month = "April";
                    break;
                case 5:
                    month = "May";
                    break;
                case 6:
                    month = "June";
                    break;
                case 7:
                    month = "July";
                    break;
                case 8:
                    month = "August";
                    break;
                case 9:
                    month = "September";
                    break;
                case 10:
                    month = "October";
                    break;
                case 11:
                    month = "November";
                    break;
                case 12:
                    month = "December";
                    break;
            }

            return month;
        }

	}
}

