using Foobar999.Sudoku.Cli;
using Foobar999.Sudoku.Interface;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;

namespace Foobar999.Sudoku.Processing
{
	public class Processor : IProcessor<Options, Object>
	{
		private readonly IReader<String, Byte[,]> fieldReader;
		private readonly ILogger<Processor> logger;

		public Processor(IReader<String, Byte[,]> fieldReader, ILogger<Processor> logger)
		{
			this.fieldReader = fieldReader ?? throw new ArgumentNullException(nameof(fieldReader));
			this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		public Object Process(Options options)
		{
			if (options == null)
			{
				throw new ArgumentNullException(nameof(options));
			}

			this.logger.LogInformation($"Reading field from {options.FilePath}.");
			Byte[,] field = this.fieldReader.Read(options.FilePath);

			this.logger.LogInformation($"Read {field.GetLength(0)}x{field.GetLength(1)} field:");
			this.logger.LogInformation(JsonConvert.SerializeObject(field, Formatting.Indented));

			Int32 numBlockRows = options.NumBlockRows > 0 ? options.NumBlockRows : (Int32)Math.Sqrt(field.GetLength(0));
			Int32 numBlockColumns = options.NumBlockColumns > 0 ? options.NumBlockColumns : (Int32)Math.Sqrt(field.GetLength(1));
			this.logger.LogInformation($"Using {numBlockRows}x{numBlockColumns} blocks.");

			return options;
		}
	}
}