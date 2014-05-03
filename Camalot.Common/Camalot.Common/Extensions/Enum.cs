using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camalot.Common.Extensions {
	public static partial class CamalotCommonExtensions {
		/// <summary>
		/// Gets the custom attribute value.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <typeparam name="Expected">The type of the expected.</typeparam>
		/// <param name="enumeration">The enumeration.</param>
		/// <param name="expression">The expression.</param>
		/// <returns></returns>
		/// <gist id="55ff82073abe0b2ba0fd"></gist>
		public static Expected GetCustomAttributeValue<T, Expected> ( this Enum enumeration, Func<T, Expected> expression ) where T : Attribute {
			T attribute = enumeration.GetType ( ).GetMember ( enumeration.ToString ( ) ).First ( ).GetCustomAttributes ( typeof ( T ), false ).Cast<T> ( ).FirstOrDefault ( );
			if ( attribute == null )
				return default ( Expected );
			return expression ( attribute );
			//string description = enumInstance.GetAttributeValue<DescriptionAttribute, string>(x => x.Description);
		}

		/// <summary>
		/// Gets the custom attribute.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="enumeration">The enumeration.</param>
		/// <returns></returns>
		public static T GetCustomAttribute<T> ( this Enum enumeration ) where T : Attribute {
			T attribute = enumeration.GetType ( ).GetMember ( enumeration.ToString ( ) ).First ( ).GetCustomAttributes( typeof ( T ), false ).Cast<T> ( ).FirstOrDefault ( );
			return attribute;
		}
	}
}
