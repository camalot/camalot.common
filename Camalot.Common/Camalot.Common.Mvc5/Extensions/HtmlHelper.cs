using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Camalot.Common.Extensions;
using Camalot.Common.Mvc.Attributes;
using System.Web.Mvc.Html;
using System.Web;
using Camalot.Common.Attributes;

namespace Camalot.Common.Mvc.Extensions {
	public static partial class CamalotCommonMvcExtensions {

		/// <summary>
		/// Returns an HTML select element for each field by the specified enum items and HTML attributes.
		/// </summary>
		/// <typeparam name="TEnum">The type of the enum.</typeparam>
		/// <param name="helper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the select field.</param>
		/// <param name="optionLabel">The option label.</param>
		/// <param name="htmlAttributes">An object containing a list of html sttributes to apply to the select element.</param>
		/// <returns></returns>
		/// <ignore>true</ignore>
		public static MvcHtmlString EnumDropDownList<TEnum>(this HtmlHelper helper, string name, string optionLabel, object htmlAttributes = null) {
			return EnumDropDownList(helper, name, default(TEnum), optionLabel, htmlAttributes);
		}

		/// <summary>
		/// Returns an HTML select element for each field by the specified enum items and HTML attributes.
		/// </summary>
		/// <typeparam name="TEnum">The type of the enum.</typeparam>
		/// <param name="helper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the select field.</param>
		/// <param name="htmlAttributes">An object containing a list of html sttributes to apply to the select element.</param>
		/// <returns></returns>
		/// <ignore>true</ignore>
		public static MvcHtmlString EnumDropDownList<TEnum>(this HtmlHelper helper, string name, object htmlAttributes = null) {
			return EnumDropDownList(helper, name, default(TEnum), null, htmlAttributes);
		}

		/// <summary>
		/// Returns an HTML select element for each field by the specified enum items and HTML attributes.
		/// </summary>
		/// <typeparam name="TEnum">The type of the enum.</typeparam>
		/// <param name="helper">The HTML helper instance that this method extends.</param>
		/// <param name="htmlAttributes">An object containing a list of html sttributes to apply to the select element.</param>
		/// <returns></returns>
		/// <ignore>true</ignore>
		public static MvcHtmlString EnumDropDownList<TEnum>(this HtmlHelper helper, object htmlAttributes = null) {
			return EnumDropDownList(helper, null, default(TEnum), null, htmlAttributes);
		}

		/// <summary>
		/// Returns an HTML select element for each field by the specified enum items and HTML attributes.
		/// </summary>
		/// <typeparam name="TEnum">The type of the enum.</typeparam>
		/// <param name="helper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the select field.</param>
		/// <param name="selected">The selected value.</param>
		/// <param name="htmlAttributes">An object containing a list of html sttributes to apply to the select element.</param>
		/// <returns></returns>
		/// <ignore>true</ignore>
		public static MvcHtmlString EnumDropDownList<TEnum>(this HtmlHelper helper, string name, TEnum selected, object htmlAttributes = null) {
			return EnumDropDownList(helper, name, selected, null, htmlAttributes);
		}

		/// <summary>
		/// Returns an HTML select element for each field by the specified enum items and HTML attributes.
		/// </summary>
		/// <typeparam name="TEnum">The type of the enum.</typeparam>
		/// <param name="helper">The HTML helper instance that this method extends.</param>
		/// <param name="selected">The selected value.</param>
		/// <param name="htmlAttributes">An object containing a list of html sttributes to apply to the select element.</param>
		/// <returns></returns>
		/// <ignore>true</ignore>
		public static MvcHtmlString EnumDropDownList<TEnum>(this HtmlHelper helper, TEnum selected, object htmlAttributes = null) {
			return EnumDropDownList(helper, null, selected, null, htmlAttributes);
		}

		/// <summary>
		/// Returns an HTML select element for each field by the specified enum items and HTML attributes.
		/// </summary>
		/// <typeparam name="TEnum">The type of the enum.</typeparam>
		/// <param name="helper">The HTML helper instance that this method extends.</param>
		/// <param name="selected">The selected value.</param>
		/// <param name="optionLabel">The option label.</param>
		/// <param name="htmlAttributes">An object containing a list of html sttributes to apply to the select element.</param>
		/// <returns></returns>
		/// <ignore>true</ignore>
		public static MvcHtmlString EnumDropDownList<TEnum>(this HtmlHelper helper, TEnum selected, string optionLabel, object htmlAttributes = null) {
			return EnumDropDownList(helper, null, selected, optionLabel, htmlAttributes);
		}

		/// <summary>
		/// Returns an HTML select element for each field by the specified enum items and HTML attributes.
		/// </summary>
		/// <typeparam name="TEnum">The type of the enum.</typeparam>
		/// <param name="helper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the select field.</param>
		/// <param name="selected">The selected value.</param>
		/// <param name="optionLabel">The option label.</param>
		/// <param name="htmlAttributes">An object containing a list of html sttributes to apply to the select element.</param>
		/// <returns></returns>
		public static MvcHtmlString EnumDropDownList<TEnum>(this HtmlHelper helper, string name, TEnum selected, string optionLabel, object htmlAttributes = null) {
			Type enumType = typeof(TEnum);
			Type baseEnumType = Enum.GetUnderlyingType(enumType);
			List<SelectListItem> items = new List<SelectListItem>();

			foreach(var field in enumType.GetFields(BindingFlags.Static | BindingFlags.GetField | BindingFlags.Public)) {
				string text;
				string value;

				if(field.HasAttribute<EnumValueAttribute>()) {
					value = field.GetCustomAttribute<EnumValueAttribute>().Value.Or(field.Name);
				} else {
					value = field.Name;
				}

				if(field.HasAttribute<EnumDisplayAttribute>()) {
					text = field.GetCustomAttribute<EnumDisplayAttribute>().Value.Or(field.Name);
				} else {
					text = field.Name;
				}

				if(!field.HasAttribute<EnumIgnoreAttribute>()) {
					items.Add(new SelectListItem() {
						Text = text,
						Value = value,
						Selected = selected.Equals((TEnum)field.GetValue(null))
					});
				}
			}

			if(enumType.IsNullable()) {
				items.Insert(0, new SelectListItem { Text = optionLabel.Or(""), Value = "" });
			}

			return helper.DropDownList(name.Or(enumType.Name), items, optionLabel, htmlAttributes);
		}

	}
}
