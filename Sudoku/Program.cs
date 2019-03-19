using Foobar999.Sudoku.DependencyInjection;
using Foobar999.Sudoku.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Foobar999.Sudoku
{
	internal class Program
	{
		private static Int32 Main(String[] args)
		{
			IServiceCollection serviceCollection = new ServiceConfigurator().ConfigureServices(new ServiceCollection());

			using (ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider()) // required for logging of final messages (https://github.com/serilog/serilog-extensions-logging-file/issues/16)
			{
				return serviceProvider.GetService<IApplication>().Run(args);
			}
		}
	}
}