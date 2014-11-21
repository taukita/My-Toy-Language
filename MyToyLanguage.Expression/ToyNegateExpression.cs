using MyToyLanguage.Core;

namespace MyToyLanguage.Expression
{
	internal class ToyNegateExpression : ToyExpression
	{
		private readonly ToyExpression _expression;

		public ToyNegateExpression(ToyExpression expression)
		{
			_expression = expression;
		}

		public override ToyExpression Reduce(ToyContext context)
		{
			var reduced = _expression.Reduce(context);

			var number = reduced as ToyNumberValue;

			if (number != null)
			{
				return new ToyNumberValue(-number.Value);
			}

			return new ToyNegateExpression(reduced);
		}

		public override string ToString()
		{
			return string.Format("-{0}", _expression);
		}
	}
}