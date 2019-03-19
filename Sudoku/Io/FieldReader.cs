using Foobar999.Sudoku.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Foobar999.Sudoku.Io
{
	public class FieldReader<T> : IReader<String, T[,]>
	{
		private readonly IReader<String, String[][]> jaggedFieldReader;
		private readonly IMapper<String[][], String[,]> jaggedFieldMapper;
		private readonly IMapper<String[,], T[,]> fieldTypeMapper;
		private readonly IValidator<T[,], T[,]> fieldValidator;

		public FieldReader(
			IReader<String, String[][]> jaggedFieldReader,
			IMapper<String[][], String[,]> jaggedFieldMapper,
			IMapper<String[,], T[,]> fieldTypeMapper,
			IValidator<T[,], T[,]> fieldValidator)
		{
			this.jaggedFieldReader = jaggedFieldReader ?? throw new ArgumentNullException(nameof(jaggedFieldReader));
			this.jaggedFieldMapper = jaggedFieldMapper ?? throw new ArgumentNullException(nameof(jaggedFieldMapper));
			this.fieldTypeMapper = fieldTypeMapper ?? throw new ArgumentNullException(nameof(fieldTypeMapper));
			this.fieldValidator = fieldValidator ?? throw new ArgumentNullException(nameof(fieldValidator));
		}

		public T[,] Read(String filePath)
		{
			if (String.IsNullOrWhiteSpace(filePath))
			{
				throw new ArgumentOutOfRangeException(nameof(filePath), "Parameter must not be null, empty or whitespace.");
			}

			return this.fieldValidator.ValidateThrows(this.fieldTypeMapper.Map(this.jaggedFieldMapper.Map(this.jaggedFieldReader.Read(filePath))));
		}
	}
}