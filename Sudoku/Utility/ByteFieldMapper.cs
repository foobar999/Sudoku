using Foobar999.Sudoku.Interface;
using System;

namespace Foobar999.Sudoku.Utility
{
	public class ByteFieldMapper : IMapper<String[,], Byte[,]>
	{
		public Byte[,] Map(String[,] data)
		{
			if (data == null)
			{
				throw new ArgumentNullException(nameof(data));
			}

			if (data.GetLength(0) != data.GetLength(1))
			{
				throw new ArgumentOutOfRangeException(nameof(data), $"Number of rows {data.GetLength(0)} does not match number of columns {data.GetLength(1)})");
			}

			Byte[,] field = new Byte[data.GetLength(0), data.GetLength(1)];

			for (Int32 row = 0; row < data.GetLength(0); row++)
			{
				for (Int32 column = 0; column < data.GetLength(1); column++)
				{
					String token = data[row, column] ?? "0";
					if (!Byte.TryParse(token, out Byte element) || element < 0 || element > data.GetLength(0))
					{
						throw new ArgumentOutOfRangeException(nameof(data), $"Invalid token \"{data[row, column]}\" at row {row}, column {column}");
					}

					field[row, column] = element;
				}
			}

			return field;
		}
	}
}