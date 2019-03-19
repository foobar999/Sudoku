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
			Int32 rows = data.Length;
			Int32 cols = data.Max(subArray => subArray.Length);
			String[,] array = new String[rows, cols];
			for (Int32 i = 0; i < rows; i++)
			{
				cols = data[i].Length;
				for (Int32 j = 0; j < cols; j++)
				{
					array[i, j] = data[i][j];
				}
			}
			return array;
		}
	}
}