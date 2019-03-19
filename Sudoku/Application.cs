﻿using CommandLine;
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
		private readonly IReader<String, Byte[,]> fieldReader;
		private readonly ILogger<Application> logger;

		public Application(IReader<String, Byte[,]> fieldReader, ILogger<Application> logger)
		{
			this.fieldReader = fieldReader ?? throw new ArgumentNullException(nameof(fieldReader));
			this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		public Int32 Run(String[] args)
		{
			if (args == null)
			{
				throw new ArgumentNullException(nameof(args));
			}

			Parser parser = new Parser(config => config.HelpWriter = null);
			ParserResult<Options> parserResult =parser.ParseArguments<Options>(args);

			parserResult.WithParsed(opts =>
			{
				this.logger.LogInformation($"Reading field from {opts.FilePath}");
				Byte[,] field = this.fieldReader.Read(opts.FilePath);

				this.logger.LogInformation("Read following field:");
				this.logger.LogInformation(JsonConvert.SerializeObject(field, Formatting.Indented));
				this.logger.LogInformation($"Field dimensions: {field.GetLength(0)} x {field.GetLength(1)}.");
				
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