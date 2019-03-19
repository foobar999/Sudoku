using System;
using System.Diagnostics.CodeAnalysis;

namespace Foobar999.Sudoku.Block
{
	[ExcludeFromCodeCoverage]
	public class Block<T>
	{
		public Int32 Row { get; set; }
		public Int32 Column { get; set; }

		public Int32 Width { get; set; }
		public Int32 Height { get; set; }

		public T[,] Field { get; set; }
	}
}