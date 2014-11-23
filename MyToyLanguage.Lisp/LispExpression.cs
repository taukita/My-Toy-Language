using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprache;

namespace MyToyLanguage.Lisp
{
	public abstract class LispExpression : IPositionAware<LispExpression>
	{
		public Position Position
		{
			get;
			protected set;
		}

		public int Length
		{
			get;
			protected set;
		}

		public abstract LispExpression Reduce(LispContext context);

		LispExpression IPositionAware<LispExpression>.SetPos(Position startPos, int length)
		{
			Position = startPos;
			Length = length;
			return this;
		}
	}
}
