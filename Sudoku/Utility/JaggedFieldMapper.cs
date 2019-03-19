using Foobar999.Sudoku.Interface;
using System;
using System.Linq;

namespace Foobar999.Sudoku.Utility
{
	public class JaggedFieldMapper : IMapper<String[][], String[,]>
	{
		// https://stackoverflow.com/questions/1781172/generate-a-two-dimensional-array-via-linq/1814063#1814063
		public String[,] Map(String[][] data)
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

			String[,] array = new String[rows, columns];
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