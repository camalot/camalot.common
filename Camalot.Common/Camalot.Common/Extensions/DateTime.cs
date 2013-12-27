using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			TimeSpan ts = DateTime.UtcNow - dt;
			if ( ts.TotalMinutes < 1 )//seconds ago
				return "just now";
			if ( ts.TotalHours < 1 )//min ago
				return (int)ts.TotalMinutes == 1 ? "a minute ago" : (int)ts.TotalMinutes + " minutes ago";
			if ( ts.TotalDays < 1 )//hours ago
				return (int)ts.TotalHours == 1 ? "an hour ago" : (int)ts.TotalHours + " hours ago";
			if ( ts.TotalDays < 7 )//days ago
				return (int)ts.TotalDays == 1 ? "a day ago" : (int)ts.TotalDays + " days ago";
			if ( ts.TotalDays < 30.4368 )//weeks ago
				return (int)( ts.TotalDays / 7 ) == 1 ? "a week ago" : (int)( ts.TotalDays / 7 ) + " weeks ago";
			if ( ts.TotalDays < 365.242 )//months ago
				return (int)( ts.TotalDays / 30.4368 ) == 1 ? "a month ago" : (int)( ts.TotalDays / 30.4368 ) + " months ago";
			//years ago
			return (int)( ts.TotalDays / 365.242 ) == 1 ? "a year ago" : (int)( ts.TotalDays / 365.242 ) + " years ago";
		}

		/// <summary>
		/// To the short friendly string.
		/// </summary>
		/// <param name="dt">The datetime.</param>
		/// <returns></returns>
		public static String ToShortFriendlyString ( this DateTime dt ) {
			TimeSpan ts = DateTime.UtcNow - dt;
			if ( ts.TotalMinutes < 1 )//seconds ago
				return "now";
			if ( ts.TotalHours < 1 )//min ago
				return (int)ts.TotalMinutes + "m";
			if ( ts.TotalDays < 1 )//hours ago
				return (int)ts.TotalHours + "h";
			if ( ts.TotalDays < 7 )//days ago
				return (int)ts.TotalDays + "d";
			if ( ts.TotalDays < 30.4368 )//weeks ago
				return (int)( ts.TotalDays / 7 ) + "w";
			if ( ts.TotalDays < 365.242 )//months ago
				return (int)( ts.TotalDays / 30.4368 ) + "m";
			//years ago
			return (int)( ts.TotalDays / 365.242 ) + "y";
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
