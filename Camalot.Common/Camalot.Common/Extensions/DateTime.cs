using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Camalot.Common.Properties;

namespace Camalot.Common.Extensions {
	public static partial class CamalotCommonExtensions {
		/// <summary>
		/// just gets Epoch representation of DateTime
		/// </summary>
		/// <param name="dt">The dt.</param>
		/// <returns></returns>
		public static DateTime Epoch ( this DateTime dt ) {
			return new DateTime ( 1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc );
		}

		/// <summary>
		/// To the kind.
		/// </summary>
		/// <param name="dateTime">The date time.</param>
		/// <param name="kind">The kind.</param>
		/// <returns></returns>
		public static DateTime ToKind ( this DateTime dateTime, DateTimeKind kind ) {
			return DateTime.SpecifyKind ( dateTime, kind );
		}

		/// <summary>
		/// Returns a string representation of the time
		/// </summary>
		/// <param name="date">The date.</param>
		/// <returns></returns>
		public static String ToTimeString(this DateTime date, CultureInfo culture) {
			return date.ToString(culture.DateTimeFormat.ShortTimePattern);
		}

		/// <summary>
		/// To the friendly string.
		/// </summary>
		/// <param name="dt">The datetime.</param>
		/// <returns></returns>
		public static String ToFriendlyString ( this DateTime dt ) {
			TimeSpan ts = DateTime.UtcNow - dt.ToKind(DateTimeKind.Utc);
			if ( ts.TotalMinutes < 1 )//seconds ago
				return Resources.Date_FriendlyNow;
			if ( ts.TotalHours < 1 )//min ago
				return (int)ts.TotalMinutes == 1 ? Resources.Date_Friendly1Minute : Resources.Date_FriendlyMinutes.With ( (int)ts.TotalMinutes );
			if ( ts.TotalDays < 1 )//hours ago
				return (int)ts.TotalHours == 1 ? Resources.Date_Friendly1Hour : Resources.Date_FriendlyHours.With ( (int)ts.TotalHours );
			if ( ts.TotalDays < 7 )//days ago
				return (int)ts.TotalDays == 1 ? Resources.Date_Friendly1Day : Resources.Date_FriendlyDays.With ( (int)ts.TotalDays );
			if ( ts.TotalDays < 30.4368 )//weeks ago
				return (int)( ts.TotalDays / 7 ) == 1 ? Resources.Date_Friendly1Week : Resources.Date_FriendlyWeeks.With ( (int)( ts.TotalDays / 7 ) );
			if ( ts.TotalDays < 365.242 )//months ago
				return (int)( ts.TotalDays / 30.4368 ) == 1 ? Resources.Date_Friendly1Month : Resources.Date_FriendlyMonths.With ( (int)( ts.TotalDays / 30.4368 ) );
			//years ago
			return (int)( ts.TotalDays / 365.242 ) == 1 ? Resources.Date_Friendly1Year : Resources.Date_FriendlyYears.With ( (int)( ts.TotalDays / 365.242 ) );
		}

		/// <summary>
		/// To the short friendly string.
		/// </summary>
		/// <param name="dt">The datetime.</param>
		/// <returns></returns>
		public static String ToShortFriendlyString ( this DateTime dt ) {
			TimeSpan ts = DateTime.UtcNow - dt.ToKind(DateTimeKind.Utc);
			if ( ts.TotalMinutes < 1 )//seconds ago
				return Resources.Date_FriendlyNow_Short;
			if ( ts.TotalHours < 1 )//min ago
				return (int)ts.TotalMinutes + Resources.Date_FriendlyMinute_Short;
			if ( ts.TotalDays < 1 )//hours ago
				return (int)ts.TotalHours + Resources.Date_FriendlyHour_Short;
			if ( ts.TotalDays < 7 )//days ago
				return (int)ts.TotalDays + Resources.Date_FriendlyDay_Short;
			if ( ts.TotalDays < 30.4368 )//weeks ago
				return (int)( ts.TotalDays / 7 ) + Resources.Date_FriendlyWeek_Short;
			if ( ts.TotalDays < 365.242 )//months ago
				return (int)( ts.TotalDays / 30.4368 ) + Resources.Date_FriendlyMonth_Short;
			//years ago
			return (int)( ts.TotalDays / 365.242 ) + Resources.Date_FriendlyYear_Short;
		}

		/// <summary>
		/// Rounds a datetime up to the time span
		/// </summary>
		/// <param name="dt">The datetime.</param>
		/// <param name="d">The timespan.</param>
		/// <returns></returns>
		public static DateTime RoundUp ( this DateTime dt, TimeSpan d ) {
			return new DateTime ( ( ( dt.Ticks + d.Ticks - 1 ) / d.Ticks ) * d.Ticks );
		}

		/// <summary>
		/// Rounds a datetime down to the time span.
		/// </summary>
		/// <param name="dt">The datetime.</param>
		/// <param name="d">The timespan.</param>
		/// <returns></returns>
		/// <returns></returns>
		public static DateTime RoundDown ( this DateTime dt, TimeSpan d ) {
			return new DateTime ( ( dt.Ticks / d.Ticks ) * d.Ticks );
		}

		/// <summary>
		/// Determines whether the specified date falls on the specified day of the week.
		/// </summary>
		/// <param name="date">The date.</param>
		/// <param name="dow">The day of the week.</param>
		/// <returns></returns>
		public static bool IsDayOfWeek(this DateTime date, DayOfWeek dow) {
			return date.DayOfWeek == dow;
		}

		/// <summary>
		/// Determines whether the specified date is the end of the accounting period (the last friday of the month).
		/// </summary>
		/// <param name="date">The date.</param>
		/// <returns></returns>
		public static bool IsEndOfAccountingPeriod(this DateTime date) {
			var d = date.Day;
			var dow = date.DayOfWeek;

			if(dow == DayOfWeek.Friday) {
				// last friday of the month?
				return date.AddDays(2).Month != date.Month;
			} else {
				return false;
			}
		}

		/// <summary>
		/// Determines whether the specified date is a week day.
		/// </summary>
		/// <param name="date">The date.</param>
		/// <returns></returns>
		public static bool IsWeekDay(this DateTime date) {
			return !date.Date.IsDayOfWeek(DayOfWeek.Saturday) && !date.Date.IsDayOfWeek(DayOfWeek.Sunday);
		}

		/// <summary>
		/// Determines whether the specified date is today.
		/// </summary>
		/// <param name="date">The date.</param>
		/// <returns></returns>
		public static bool IsToday(this DateTime date) {
			var d1 = new DateTimeOffset(date);
			var d2 = new DateTimeOffset(DateTime.UtcNow);

			return DateTime.Compare(d1.ToLocalTime().Date, d2.ToLocalTime().Date) == 0;
		}

		/// <summary>
		/// Determines whether the specified date is the same day as the utc date.
		/// </summary>
		/// <param name="date">The date.</param>
		/// <param name="utcDate">The UTC date.</param>
		/// <returns></returns>
		public static bool IsSameDate(this DateTime date, DateTime utcDate) {
			var d1 = new DateTimeOffset(date);
			var d2 = new DateTimeOffset(utcDate);

			return DateTime.Compare(d1.ToLocalTime().Date, d2.ToLocalTime().Date) == 0;
		}

		/// <summary>
		/// Converts the ticks since Epoch to a date.
		/// </summary>
		/// <param name="ticks">The ticks.</param>
		/// <returns></returns>
		public static DateTime FromUnixEpoch(this long ticks) {
			var date = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
			return date.AddSeconds(ticks);
		}

		/// <summary>
		/// Returns the ticks since Epoch
		/// </summary>
		/// <param name="date">The date.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentOutOfRangeException"></exception>
		public static long ToUnixEpoch(this DateTime date) {
			var epoc = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

			if(date.Kind == DateTimeKind.Local) {
				date = new DateTimeOffset(date, new TimeSpan(0)).DateTime;
			}

			var delta = date - epoc;
			if(delta.TotalSeconds < 0) {
				throw new ArgumentOutOfRangeException(
						String.Format("Unix epoch starts January 1st, 1970 - {0}", date.ToString()));
			}
			return (long)delta.TotalSeconds;
		}
	}
}
