using Foobar999.Sudoku.Interface;
using Foobar999.Sudoku.Io;
using Foobar999.Sudoku.Utility;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Foobar999.Sudoku.DependencyInjection
{
	public class ServiceConfigurator
	{
		public IServiceCollection ConfigureServices(IServiceCollection serviceCollection)
		{
			serviceCollection.AddTransient<IReader<String, Int32[][]>, JaggedFieldReader>();
			serviceCollection.AddTransient<IReader<String, Int32[,]>, FieldReader>();
			serviceCollection.AddTransient<IMapper<Int32[][], Int32[,]>, JaggedFieldMapper<Int32>>();
			serviceCollection.AddTransient<IApplication, Application>();

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