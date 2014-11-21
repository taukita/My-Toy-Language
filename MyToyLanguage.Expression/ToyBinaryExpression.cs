using System;
using MyToyLanguage.Core;

namespace MyToyLanguage.Expression
{
	internal class ToyBinaryExpression : ToyExpression
	{
		private readonly ToyExpression _operand1;
		private readonly ToyExpression _operand2;
		private readonly ToyOperatorType _operator;

		public ToyBinaryExpression(ToyOperatorType @operator, ToyExpression operand1, ToyExpression operand2)
		{
			_operand1 = operand1;
			_operand2 = operand2;
			_operator = @operator;
		}

		public override ToyExpression Reduce(ToyContext context)
		{
			var reduced1 = _operand1.Reduce(context);
			var reduced2 = _operand2.Reduce(context);

			var number1 = reduced1 as ToyNumberValue;
			var number2 = reduced2 as ToyNumberValue;

			if (number1 != null && number2 != null)
			{
				switch (_operator)
				{
					case ToyOperatorType.Add:
						return new ToyNumberValue(number1.Value + number2.Value);
					case ToyOperatorType.Sub:
						return new ToyNumberValue(number1.Value - number2.Value);
					case ToyOperatorType.Mul:
						return new ToyNumberValue(number1.Value*number2.Value);
					case ToyOperatorType.Div:
						return new ToyNumberValue(number1.Value/number2.Value);
					default:
						throw new ArgumentOutOfRangeException();
				}
			}

			return new ToyBinaryExpression(_operator, reduced1, reduced2);
		}

		public override string ToString()
		{
			return String.Format("({0} {1} {2})", _operand1, _operator.GetDescription(), _operand2);
		}

		public static ToyExpression Produce(ToyOperatorType arg1, ToyExpression arg2, ToyExpression arg3)
		{
			return new ToyBinaryExpression(arg1, arg2, arg3);
		}
	}
}