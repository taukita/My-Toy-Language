using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprache;

namespace MyToyLanguage.Lisp
{
	public static class ToyLispParser
	{
		private static readonly Parser<LispExpression> Atom =
			from v in Parse.Char(c => c != '(' && c != ')' && c != '"' && !char.IsWhiteSpace(c), string.Empty).Many()
			select new LispAtom(new string(v.ToArray()));

		private static readonly Parser<LispExpression> List =
			from lparen in Parse.Char('(')
			from spaces1 in Parse.WhiteSpace.Many()
			from expressions in
				(from expr in Parse.Ref(() => Expression)
				 from spaces2 in Parse.WhiteSpace.Many()
				 select expr).Many()
			from rparen in Parse.Char(')')
			select new LispList(expressions);

		private static readonly Parser<LispExpression> QuotedString =
			from lquote in Parse.Char('"')
			from v in Parse.CharExcept(new[] { '"', '\\' }).Or(Parse.String(@"\""").Select(s => '"')).Or(Parse.String(@"\\").Select(s => '\\')).Many()
			from rquote in Parse.Char('"')
			select new LispQuotedString(new string(v.ToArray()));

		private static readonly Parser<LispExpression> Expression = Atom.XOr(List).XOr(QuotedString);

		public static LispExpression ParseExpression(string code)
		{
			return (from spaces1 in Parse.WhiteSpace.Many()
			        from expression in Expression.End()
			        select expression).Parse(code);
		}
	}
}
