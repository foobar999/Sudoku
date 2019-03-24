using System;
using System.Diagnostics.CodeAnalysis;

namespace Foobar999.Sudoku.Processing
{
	[ExcludeFromCodeCoverage]
	public class SudokuItem
	{
		public Byte[,] Field { get; set; }

		public Int32 NumBlockRows { get; set; }

		public Int32 NumBlockColumns { get; set; }
	}
}