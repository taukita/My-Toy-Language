using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToyLanguage.Lisp
{
	internal class LispQuotedList : LispList
	{
		public LispQuotedList(IEnumerable<LispExpression> expressions) : base(expressions)
		{
		}

		public override LispExpression Reduce(LispContext context)
		{
			return new LispList(Expressions);
		}
	}
}
