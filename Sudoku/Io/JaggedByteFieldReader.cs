using Foobar999.Sudoku.Interface;
using System;
using System.IO;
using System.Linq;

namespace Foobar999.Sudoku.Io
{
	public class JaggedByteFieldReader : IReader<String, Byte[][]>
	{
		public Byte[][] Read(String filePath)
		{
			return File.ReadLines(filePath).Select(x => x.Split().Select(Byte.Parse).ToArray()).ToArray();
		}
	}
}