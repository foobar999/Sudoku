using Foobar999.Sudoku.Interface;
using System;
using System.Linq;

namespace Foobar999.Sudoku.Utility
{
	public class JaggedFieldMapper<T> : IMapper<T[][], T[,]>
	{
		public T[,] Map(T[][] data)
		{
			if (data == null)
			{
				throw new ArgumentNullException(nameof(data));
			}

			Int32 rows = data.Length;
			Int32 columns = data.Max(subArray => subArray.Length);
			
			if (!data.All(row => row.Length == columns))
			{
				throw new ArgumentOutOfRangeException(nameof(data), "Not all rows have the same number of columns.");
			}

			T[,] array = new T[rows, columns];
			for (Int32 i = 0; i < rows; i++)
			{
				columns = data[i].Length;
				for (Int32 j = 0; j < columns; j++)
				{
					array[i, j] = data[i][j];
				}
			}
			return array;
		}
	}
}