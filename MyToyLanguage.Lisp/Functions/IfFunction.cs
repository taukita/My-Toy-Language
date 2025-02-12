﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToyLanguage.Lisp.Functions
{
	class IfFunction : LispFunction
	{
		public override string Id
		{
			get
			{
				return "if";
			}
		}

		public override LispExpression Apply(IEnumerable<LispExpression> expressions, LispContext context)
		{
			var e = expressions as LispExpression[] ?? expressions.ToArray();
			CanBeCalledWithOnlyNArguments(Id, e, 3);
			return e[0].Reduce(context).ToString() != "()" ? e[1].Reduce(context) : e[2].Reduce(context);
		}
	}
}
