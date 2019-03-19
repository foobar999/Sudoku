using Foobar999.Sudoku.Interface;
using System;

namespace Foobar999.Sudoku.Validation
{
	public class ByteFieldValidator : IValidator<Byte[,], Byte[,]>
	{
		public Byte[,] ValidateThrows(Byte[,] byteField)
		{
			if (byteField == null)
			{
				throw new ArgumentNullException(nameof(byteField));
			}

			if (byteField.GetLength(0) != byteField.GetLength(1))
			{
				throw new ArgumentOutOfRangeException(nameof(byteField), $"Number of rows {byteField.GetLength(0)}" +
					$" does not match number of columns {byteField.GetLength(1)}");
			}

			for (Int32 row = 0; row < byteField.GetLength(0); row++)
			{
				for (Int32 column = 0; column < byteField.GetLength(1); column++)
				{
					Byte element = byteField[row, column];
					if (element < 0 || element > byteField.GetLength(0))
					{
						throw new ArgumentOutOfRangeException(nameof(byteField), $"Element at row {row}, column {column} is not within valid" +
							$" range [0,{byteField.GetLength(0)}]");
					}
				}
			}

			return byteField;
		}
	}
}