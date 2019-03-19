using Foobar999.Sudoku.Interface;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;

namespace Foobar999.Sudoku
{
	public class Application : IApplication
	{
		private readonly IReader<String, Byte[,]> fieldReader;
		private readonly ILogger<Application> logger;

		public Application(IReader<String, Byte[,]> fieldReader, ILogger<Application> logger)
		{
			this.fieldReader = fieldReader ?? throw new ArgumentNullException(nameof(fieldReader));
			this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		public void Run(String[] args)
		{
			if (args == null)
			{
				throw new ArgumentNullException(nameof(args));
			}

			if (args.Length != 1)
			{
				throw new ArgumentOutOfRangeException(nameof(args), "Parameter must contain exactly one element.");
			}

			this.logger.LogInformation($"Reading field from {args[0]}");

			Byte[,] field = this.fieldReader.Read(args[0]);

			this.logger.LogInformation("Read following field:");
			this.logger.LogInformation(JsonConvert.SerializeObject(field, Formatting.Indented));
			this.logger.LogInformation($"Field dimensions: {field.GetLength(0)} x {field.GetLength(1)}.");
			





		}
	}
}