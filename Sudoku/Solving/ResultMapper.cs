using Foobar999.Sudoku.Interface;
using Foobar999.Sudoku.Processing;
using System;

namespace Foobar999.Sudoku.Solving
{
	public class ResultMapper : IMapper<SudokuItem, SudokuResult>
	{
		public SudokuResult Map(SudokuItem sudokuItem)
		{
			if (sudokuItem == null)
			{
				throw new ArgumentNullException(nameof(sudokuItem));
			}

			return new SudokuResult()
			{
				Field = (Byte[,])sudokuItem.Field.Clone()
			};
		}
	}
}