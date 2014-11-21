using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyToyLanguage.Core;

namespace MyToyLanguage.Expression
{
	public class ToyNumberValue : ToyExpression
	{
		public ToyNumberValue(decimal value)
		{
			Value = value;
		}

		public decimal Value
		{
			get;
			private set;
		}

		public override string ToString()
		{
			return Value%1 == 0 ? Convert.ToInt32(Value).ToString(CultureInfo.InvariantCulture) : Value.ToString(CultureInfo.InvariantCulture);
		}

		public override ToyExpression Reduce(ToyContext context)
		{
			return this;
		}
	}
}
