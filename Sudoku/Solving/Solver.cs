using Foobar999.Sudoku.Interface;
using Foobar999.Sudoku.Processing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Foobar999.Sudoku.Solving
{
	public class Solver : ISolver<SudokuItem, IEnumerable<SudokuResult>>
	{
		private readonly IMapper<SudokuItem, SudokuResult> resultMapper;
		private readonly ILogger<Solver> logger;

		public Solver(IMapper<SudokuItem, SudokuResult> resultMapper, ILogger<Solver> logger)
		{
			this.resultMapper = resultMapper ?? throw new ArgumentNullException(nameof(resultMapper));
			this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		public IEnumerable<SudokuResult> Solve(SudokuItem sudokuItem)
		{
			if (sudokuItem == null)
			{
				throw new ArgumentNullException(nameof(sudokuItem));
			}

			return this.FindSolutions(sudokuItem, 0, 0);
		}

		private IEnumerable<SudokuResult> FindSolutions(SudokuItem sudokuItem, Int32 row, Int32 column)
		{
			if (row == sudokuItem.Field.GetLength(0))
			{
				return new List<SudokuResult>()
				{
					this.resultMapper.Map(sudokuItem)
				};
			}

			Int32 nextRow = row + ((column + 1) / sudokuItem.Field.GetLength(0));
			Int32 nextColumn = (column + 1) % sudokuItem.Field.GetLength(1);
			if (sudokuItem.Field[row, column] != 0)
			{
				return this.FindSolutions(sudokuItem, nextRow, nextColumn);
			}

			IEnumerable<SudokuResult> results = new List<SudokuResult>();
			foreach (Byte candidateValue in this.GetCandidates(sudokuItem, row, column))
			{
				sudokuItem.Field[row, column] = candidateValue;
				//findAllSingles(newSudoku);
				results = results.Union(this.FindSolutions(sudokuItem, nextRow, nextColumn));
			}
			sudokuItem.Field[row, column] = 0;

			return results;
		}

		// TODO 1x berechnen, dann wiederholt zugreifen
		private IEnumerable<Byte> GetCandidates(SudokuItem sudokuItem, Int32 row, Int32 column)
		{
			if(sudokuItem.Field[row, column] != 0)
			{
				yield break;
			}

			for (Byte candidateValue = 1; candidateValue <= sudokuItem.Field.GetLength(0); candidateValue++)
			{
				if (this.CanBeSet(sudokuItem, row, column, candidateValue))
				{
					yield return candidateValue;
				}
			}
		}

		private Boolean CanBeSet(SudokuItem sudokuItem, Int32 row, Int32 column, Byte value)
		{
			for (Int32 i = 0; i < sudokuItem.Field.GetLength(0); i++)
			{
				if (sudokuItem.Field[row, i] == value)
				{
					return false;
				}
				if (sudokuItem.Field[i, column] == value)
				{
					return false;
				}
			}

			Int32 boxSize = (Int32)Math.Sqrt(sudokuItem.Field.GetLength(0));
			Int32 boxRow = row / boxSize;
			Int32 boxColumn = column / boxSize;
			for (Int32 i = boxRow * boxSize; i < (boxRow * boxSize) + boxSize; i++)
			{
				for (Int32 j = boxColumn * boxSize; j < (boxColumn * boxSize) + boxSize; j++)
				{
					if (sudokuItem.Field[i, j] == value)
					{
						return false;
					}
				}
			}
			return true;
		}
	}
}