﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToyLanguage.Lisp
{
	public class LispAtom : LispExpression
	{
		private readonly string _value;

		public LispAtom(string value)
		{
			_value = value;
		}

		public override string ToString()
		{
			return _value;
		}

		public override LispExpression Reduce(LispContext context)
		{
			return this;
		}

		public decimal ToDecimal()
		{
			return decimal.Parse(_value, CultureInfo.InvariantCulture);
		}
	}
}
