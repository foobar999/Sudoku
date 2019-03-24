using CommandLine;
using CommandLine.Text;
using Foobar999.Sudoku.Cli;
using Foobar999.Sudoku.Interface;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;

namespace Foobar999.Sudoku
{
	public class Application : IApplication
	{
		private readonly IProcessor<Options, Object> processor;
		private readonly ILogger<Application> logger;

		public Application(IProcessor<Options, Object> processor, ILogger<Application> logger)
		{
			this.processor = processor ?? throw new ArgumentNullException(nameof(processor));
			this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		public Int32 Run(String[] args)
		{
			if (args == null)
			{
				throw new ArgumentNullException(nameof(args));
			}

			Parser parser = new Parser(config => config.HelpWriter = null);
			ParserResult<Options> parserResult = parser.ParseArguments<Options>(args);

			parserResult.WithParsed(options =>
			{
				this.logger.LogInformation($"Processing arguments {JsonConvert.SerializeObject(options)}");
				this.processor.Process(options);
			});

			parserResult.WithNotParsed((errs) =>
			{
				String message = HelpText.AutoBuild(parserResult).ToString();
				this.logger.LogError(message);
				this.logger.LogError("\n");
			});

			return (Int32)parserResult.Tag;
		}
	}
}