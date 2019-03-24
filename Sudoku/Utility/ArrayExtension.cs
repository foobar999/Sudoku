using System;
using System.Collections.Generic;

namespace Foobar999.Sudoku.Utility
{
	public static class ArrayExtension
	{
		public static String ToStringPretty<T>(this T[,] array)
		{
			String arrayString = "";
			for (Int32 i = 0; i < array.GetLength(0); i++)
			{
				for (Int32 j = 0; j < array.GetLength(1); j++)
				{
					arrayString += String.Format("{0}{1}", array[i, j], j == array.GetLength(1) - 1 ? "" : " ");
				}
				arrayString += i == array.GetLength(0) - 1 ? "" : Environment.NewLine;
			}

			return arrayString;
		}

		public static IEnumerable<(T value, Int32 row, Int32 column)> Iterate<T>(this T[,] self)
		{
			for (Int32 i = 0; i < self.GetLength(0); i++)
			{
				for (Int32 j = 0; j < self.GetLength(1); j++)
				{
					yield return (self[i, j], i, j);
				}
			}
		}
	}
}