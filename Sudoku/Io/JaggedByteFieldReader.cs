using Foobar999.Sudoku.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Foobar999.Sudoku.Io
{
	public class JaggedByteFieldReader : IReader<String, Byte[][]>
	{
		public Byte[][] Read(String filePath)
		{
			List<Byte[]> field = new List<Byte[]>();

			Int32 rowIndex = 0;
			foreach (String line in File.ReadLines(filePath))
			{
				List<Byte> row = new List<Byte>();

				Int32 columnIndex = 0;
				foreach (String token in line.Split((Char[])null, StringSplitOptions.RemoveEmptyEntries))
				{
					Boolean isValidElement = Byte.TryParse(token, out Byte element);
					if (!isValidElement)
					{
						throw new ArgumentOutOfRangeException(nameof(filePath), $"Invalid element at row {rowIndex}, column {columnIndex}");
					}
					row.Add(element);
					columnIndex += 1;
				}
				field.Add(row.ToArray());
				rowIndex += 1;
			}

			return field.Where(x => x.Length > 0).ToArray();
		}
	}
}