using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camalot.Common.Extensions {
	public static partial class CamalotCommonExtensions {
		public static Expected GetCustomAttributeValue<T, Expected> ( this Enum enumeration, Func<T, Expected> expression ) where T : Attribute {
			T attribute = enumeration.GetType ( ).GetMember ( enumeration.ToString ( ) ).First ( ).GetCustomAttributes ( typeof ( T ), false ).Cast<T> ( ).FirstOrDefault ( );
			if ( attribute == null )
				return default ( Expected );
			return expression ( attribute );
			//string description = enumInstance.GetAttributeValue<DescriptionAttribute, string>(x => x.Description);
		}

		public static T GetCustomAttribute<T> ( this Enum enumeration ) where T : Attribute {
			T attribute = enumeration.GetType ( ).GetMember ( enumeration.ToString ( ) ).First ( ).GetCustomAttributes( typeof ( T ), false ).Cast<T> ( ).FirstOrDefault ( );
			return attribute;
		}
	}
}
