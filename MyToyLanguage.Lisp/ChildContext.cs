using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToyLanguage.Lisp
{
	internal class ChildContext : LispContext
	{
		private readonly LispContext _parentContext;

		public ChildContext(LispContext parentContext)
		{
			_parentContext = parentContext;
		}

		public override LispExpression this[string key]
		{
			get
			{
				return InnerDictionary.ContainsKey(key) ? InnerDictionary[key] : _parentContext[key];
			}
			set
			{
				base[key] = value;
			}
		}
	}
}
