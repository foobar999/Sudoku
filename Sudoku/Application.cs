using Foobar999.Sudoku.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;

namespace Foobar999.Sudoku
{
	public class Application : IApplication
	{
		private readonly IReader<String, Int32[,]> fieldReader;
		private readonly ILogger<Application> logger;

		public Application(IReader<String, Int32[,]> fieldReader, ILogger<Application> logger)
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

			Int32[,] field = this.fieldReader.Read(args[0]);

			if (field.Length == 0)
			{
				this.logger.LogError("Read field must contain at least one element.");
				return;
			}

			this.logger.LogDebug($"Read field {field}.");
			this.logger.LogInformation($"Read field of size {field.GetLength(0)} x {field.GetLength(1)}.");
			
		}
	}
}