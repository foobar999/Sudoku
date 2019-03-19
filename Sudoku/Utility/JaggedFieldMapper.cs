using Foobar999.Sudoku.Interface;
using System;
using System.Linq;

namespace Foobar999.Sudoku.Utility
{
	public class JaggedFieldMapper<T> : IMapper<T[][], T[,]>
	{
		public T[,] Map(T[][] jaggedField)
		{
			if (jaggedField == null)
			{
				throw new ArgumentNullException(nameof(jaggedField));
			}

			Int32 rows = jaggedField.Length;
			Int32 columns = jaggedField.Max(subArray => subArray.Length);
			
			if (!jaggedField.All(row => row.Length == columns))
			{
				throw new ArgumentOutOfRangeException(nameof(jaggedField), "Not all rows have the same number of columns.");
			}

			T[,] field = new T[rows, columns];
			for (Int32 i = 0; i < rows; i++)
			{
				columns = jaggedField[i].Length;
				for (Int32 j = 0; j < columns; j++)
				{
					field[i, j] = jaggedField[i][j];
				}
			}
			return field;
		}
	}
}