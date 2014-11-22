using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprache;

namespace MyToyLanguage.Lisp
{
	public abstract class LispExpression
	{
		public abstract LispExpression Reduce(LispContext context);
	}
}
