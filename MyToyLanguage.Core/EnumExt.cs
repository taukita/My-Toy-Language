using System;
using System.ComponentModel;
using System.Reflection;

namespace MyToyLanguage.Core
{
	public static class EnumExt
	{
		public static string GetDescription(this Enum value)
		{
			var type = value.GetType();
			var name = Enum.GetName(type, value);
			if (name != null)
			{
				FieldInfo field = type.GetField(name);
				if (field != null)
				{
					var attr = Attribute.GetCustomAttribute(field, typeof (DescriptionAttribute)) as DescriptionAttribute;
					if (attr != null)
					{
						return attr.Description;
					}
				}
			}
			return null;
		}
	}
}