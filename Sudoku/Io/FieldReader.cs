using Foobar999.Sudoku.Interface;
using System;

namespace Foobar999.Sudoku.Io
{
	public class FieldReader<T> : IReader<String, T[,]>
	{
		private readonly IReader<String, T[][]> jaggedFieldReader;
		private readonly IMapper<T[][], T[,]> jaggedFieldMapper;

		public FieldReader(IReader<String, T[][]> jaggedFieldReader, IMapper<T[][], T[,]> jaggedFieldMapper)
		{
			this.jaggedFieldReader = jaggedFieldReader ?? throw new ArgumentNullException(nameof(jaggedFieldReader));
			this.jaggedFieldMapper = jaggedFieldMapper ?? throw new ArgumentNullException(nameof(jaggedFieldMapper));
		}

		public T[,] Read(String data)
		{
			return this.jaggedFieldMapper.Map(this.jaggedFieldReader.Read(data));
		}
	}
}