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
		private readonly ILogger<FieldReader<T>> logger;

		public FieldReader(
			IReader<String, String[][]> jaggedFieldReader,
			IMapper<String[][], String[,]> jaggedFieldMapper,
			IMapper<String[,], T[,]> fieldTypeMapper,
			ILogger<FieldReader<T>> logger)
		{
			this.jaggedFieldReader = jaggedFieldReader ?? throw new ArgumentNullException(nameof(jaggedFieldReader));
			this.jaggedFieldMapper = jaggedFieldMapper ?? throw new ArgumentNullException(nameof(jaggedFieldMapper));
			this.fieldTypeMapper = fieldTypeMapper ?? throw new ArgumentNullException(nameof(fieldTypeMapper));
			this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		public T[,] Read(String data)
		{
			String[][] jaggedField = this.jaggedFieldReader.Read(data);

			Int32 maxNumberOfColumns = jaggedField.Max(row => row.Length);
			if(!jaggedField.All(row => row.Length == maxNumberOfColumns))
			{
				this.logger.LogWarning($"Not all rows have the same number of columns. Zero-padding all rows to maximum column number {maxNumberOfColumns}");
			}

			return this.fieldTypeMapper.Map(this.jaggedFieldMapper.Map(jaggedField));
		}
	}
}