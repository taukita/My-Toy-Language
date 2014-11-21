using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToyLanguage.Expression
{
	enum ToyOperatorType
	{
		[Description("+")]
		Add,
		[Description("-")]
		Sub,
		[Description("*")]
		Mul,
		[Description("/")]
		Div
	}
}
