using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprache;

namespace MyToyLanguage.Expression
{
	public static class ToyExpressionParser
	{
		private static Parser<ToyOperatorType> Operator(string op, ToyOperatorType opType)
		{
			return Parse.String(op).Token().Return(opType);
		}

		private static readonly Parser<ToyOperatorType> Add = Operator("+", ToyOperatorType.Add);
		private static readonly Parser<ToyOperatorType> Sub = Operator("-", ToyOperatorType.Sub);
		private static readonly Parser<ToyOperatorType> Mul = Operator("*", ToyOperatorType.Mul);
		private static readonly Parser<ToyOperatorType> Div = Operator("/", ToyOperatorType.Div);

		private static readonly Parser<string> DecimalWithoutLeadingDigits =
			Parse.Return("")
			     .SelectMany(nothing => Parse.String(".").Text(), (nothing, dot) => new {nothing, dot})
			     .SelectMany(param0 => Parse.Number, (param0, fraction) => param0.dot + fraction);

		private static readonly Parser<string> DecimalWithLeadingDigits = Parse.Number.Then(n => DecimalWithoutLeadingDigits.XOr(Parse.Return("")).Select(f => n + f));

		private static readonly Parser<string> Decimal = DecimalWithLeadingDigits.XOr(DecimalWithoutLeadingDigits);

		private static readonly Parser<ToyExpression> NumberValue =
			Decimal.Select(s => new ToyNumberValue(decimal.Parse(s, CultureInfo.InvariantCulture)));

		private static readonly Parser<ToyExpression> ParenExpr =
			from lparen in Parse.Char('(')
			from spaces1 in Parse.WhiteSpace.Many()
			from expr in Parse.Ref(() => AddExpr)
			from spaces2 in Parse.WhiteSpace.Many()
			from rparen in Parse.Char(')')
			from spaces3 in Parse.WhiteSpace.Many()
			select expr;

		private static readonly Parser<ToyExpression> NegExpr = (
			from sign in Parse.Chars('-', '+')
			from spaces1 in Parse.WhiteSpace.Many()
			from expr in ParenExpr.XOr(NumberValue)
			select new { sign, expr }).Select(arg => arg.sign == '-' ? new ToyNegateExpression(arg.expr) : arg.expr);

		private static readonly Parser<ToyExpression> MulExpr =
			Parse.ChainOperator(Mul.Or(Div), NegExpr.XOr(ParenExpr).XOr(NumberValue), ToyBinaryExpression.Produce);

		private static readonly Parser<ToyExpression> AddExpr =
			Parse.ChainOperator(Add.Or(Sub), MulExpr, ToyBinaryExpression.Produce);

		private static readonly Parser<ToyExpression> Expr =
			from spaces1 in Parse.WhiteSpace.Many()
			from expr in AddExpr
			select expr;

		public static ToyExpression ParseExpression(string code)
		{
			return Expr.Parse(code);
		}
	}
}
