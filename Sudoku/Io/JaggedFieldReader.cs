using Foobar999.Sudoku.Interface;
using System;
using System.IO;
using System.Linq;

namespace Foobar999.Sudoku.Io
{
	public class JaggedFieldReader : IReader<String, Int32[][]>
	{
		public Int32[][] Read(String filePath)
		{
			

			return File.ReadLines(filePath).Select(x => x.Split().Select(Int32.Parse).ToArray()).ToArray();
		}
	}
}