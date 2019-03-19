using Foobar999.Sudoku.Interface;
using System;
using System.Linq;

namespace Foobar999.Sudoku.Utility
{
	public class MatrixFieldMapper<T> : IMapper<T[][], T[,]>
	{
		public T[,] Map(T[][] jaggedField)
		{
			if (jaggedField == null)
			{
				throw new ArgumentNullException(nameof(jaggedField));
			}

			Int32 numberOfRows = jaggedField.Length;
			Int32 numberOfColumns = jaggedField.Max(subArray => subArray.Length);
			
			if (!jaggedField.All(row => row.Length == numberOfColumns))
			{
				throw new ArgumentOutOfRangeException(nameof(jaggedField), "Not all rows have the same number of columns.");
			}

			T[,] matrixField = new T[numberOfRows, numberOfColumns];
			for (Int32 i = 0; i < numberOfRows; i++)
			{
				numberOfColumns = jaggedField[i].Length;
				for (Int32 j = 0; j < numberOfColumns; j++)
				{
					matrixField[i, j] = jaggedField[i][j];
				}
			}
			return matrixField;
		}
	}
}