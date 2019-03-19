using Foobar999.Sudoku.Interface;
using System;
using System.Linq;
using Thinktecture.IO;

namespace Foobar999.Sudoku.Io
{
	public class JaggedFieldReader : IReader<String, String[][]>
	{
		private readonly IFile file;

		public JaggedFieldReader(IFile file)
		{
			this.file = file ?? throw new ArgumentNullException(nameof(file));
		}

		public String[][] Read(String filePath)
		{
			if (String.IsNullOrWhiteSpace(filePath))
			{
				throw new ArgumentOutOfRangeException(nameof(filePath), "Parameter must not be null, empty or whitespace.");
			}

			return this.file.ReadLines(filePath).Select(x => this.GetLineTokens(x)).Where(x => x.Length > 0).ToArray();
		}

		private String[] GetLineTokens(String line)
		{
			return line.Split((Char[])null, StringSplitOptions.RemoveEmptyEntries);
		}
	}
}