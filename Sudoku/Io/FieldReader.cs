using Foobar999.Sudoku.Interface;
using System;

namespace Foobar999.Sudoku.Io
{
	public class FieldReader : IReader<String, Int32[,]>
	{
		private readonly IReader<String, Int32[][]> jaggedFieldReader;
		private readonly IMapper<Int32[][], Int32[,]> jaggedFieldMapper;

		public FieldReader(IReader<String, Int32[][]> jaggedFieldReader, IMapper<Int32[][], Int32[,]> jaggedFieldMapper)
		{
			this.jaggedFieldReader = jaggedFieldReader ?? throw new ArgumentNullException(nameof(jaggedFieldReader));
			this.jaggedFieldMapper = jaggedFieldMapper ?? throw new ArgumentNullException(nameof(jaggedFieldMapper));
		}

		public Int32[,] Read(String data)
		{
			return this.jaggedFieldMapper.Map(this.jaggedFieldReader.Read(data));
		}
	}
}