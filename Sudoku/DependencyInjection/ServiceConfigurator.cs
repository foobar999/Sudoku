using Foobar999.Sudoku.Interface;
using Foobar999.Sudoku.Io;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Foobar999.Sudoku.DependencyInjection
{
	public class ServiceConfigurator
	{
		public IServiceCollection ConfigureServices(IServiceCollection serviceCollection)
		{
			serviceCollection.AddTransient<IReader<Object, Object>, Reader>();

			serviceCollection.AddLogging(loggingBuilder =>
			{
				loggingBuilder.AddConsole();
				loggingBuilder.AddDebug();
			});

			return serviceCollection;
		}
	}
}