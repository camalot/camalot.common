using System;
using System.Collections.Generic;
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
	}
}
