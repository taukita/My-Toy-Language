using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyToyLanguage.Core;

namespace MyToyLanguage.Expression
{
	public abstract class ToyExpression
	{
		public abstract ToyExpression Reduce(ToyContext context);
	}
}
