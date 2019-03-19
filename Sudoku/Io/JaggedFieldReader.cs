using Foobar999.Sudoku.Interface;
using System;
using System.IO;
using System.Linq;

namespace Foobar999.Sudoku.Io
{
	public class JaggedFieldReader : IReader<String, String[][]>
	{
		public String[][] Read(String filePath)
		{
			return File.ReadLines(filePath).Select(x => this.GetLineTokens(x)).Where(x => x.Length > 0).ToArray();
		}

		private String[] GetLineTokens(String line)
		{
			return line.Split((Char[])null, StringSplitOptions.RemoveEmptyEntries);
		}
	}
}