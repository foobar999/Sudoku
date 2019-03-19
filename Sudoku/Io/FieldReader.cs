using Foobar999.Sudoku.Interface;
using System;

namespace Foobar999.Sudoku.Io
{
	public class FieldReader<T> : IReader<String, T[,]>
	{
		private readonly IReader<String, String[][]> jaggedFieldReader;
		private readonly IMapper<String[][], String[,]> jaggedFieldMapper;
		private readonly IMapper<String[,], T[,]> fieldTypeMapper;

		public FieldReader(
			IReader<String, String[][]> jaggedFieldReader,
			IMapper<String[][], String[,]> jaggedFieldMapper,
			IMapper<String[,], T[,]> fieldTypeMapper)
		{
			this.jaggedFieldReader = jaggedFieldReader ?? throw new ArgumentNullException(nameof(jaggedFieldReader));
			this.jaggedFieldMapper = jaggedFieldMapper ?? throw new ArgumentNullException(nameof(jaggedFieldMapper));
			this.fieldTypeMapper = fieldTypeMapper ?? throw new ArgumentNullException(nameof(fieldTypeMapper));
		}

		public T[,] Read(String data)
		{
			return this.fieldTypeMapper.Map(this.jaggedFieldMapper.Map(this.jaggedFieldReader.Read(data)));
		}
	}
}