﻿using Foobar999.Sudoku.Cli;
using Foobar999.Sudoku.Interface;
using Foobar999.Sudoku.Io;
using Foobar999.Sudoku.Processing;
using Foobar999.Sudoku.Solving;
using Foobar999.Sudoku.Utility;
using Foobar999.Sudoku.Validation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Thinktecture.IO;
using Thinktecture.IO.Adapters;

namespace Foobar999.Sudoku.DependencyInjection
{
	public class ServiceConfigurator
	{
		public IServiceCollection ConfigureServices(IServiceCollection serviceCollection)
		{
			serviceCollection.AddTransient<IReader<String, Byte[,]>, FieldReader<Byte>>();
			serviceCollection.AddTransient<IReader<String, String[][]>, JaggedFieldReader>();
			serviceCollection.AddTransient<IMapper<String[][], String[,]>, MatrixFieldMapper<String>>();
			serviceCollection.AddTransient<IMapper<String[,], Byte[,]>, ByteFieldMapper>();
			serviceCollection.AddTransient<IValidator<Byte[,], Byte[,]>, ByteFieldValidator>();
			serviceCollection.AddTransient<IMapper<SudokuItem, SudokuResult>, ResultMapper>();
			serviceCollection.AddTransient<ISolver<SudokuItem, IEnumerable<SudokuResult>>, Solver>();

			serviceCollection.AddTransient<IFile, FileAdapter>();

			serviceCollection.AddTransient<IApplication, Application>();
			serviceCollection.AddTransient<IProcessor<Options, Object>, Processor>();
			serviceCollection.AddLogging(loggingBuilder =>
			{
				loggingBuilder.SetMinimumLevel(LogLevel.Debug);
				loggingBuilder.AddConsole();
				loggingBuilder.AddDebug();
			});

			return serviceCollection;
		}
	}
}