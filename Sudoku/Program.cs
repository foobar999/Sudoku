using Foobar999.Sudoku.DependencyInjection;
using Foobar999.Sudoku.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Foobar999.Sudoku
{
	internal class Program
	{
		private static void Main(String[] args)
		{
			IServiceCollection serviceCollection = new ServiceConfigurator().ConfigureServices(new ServiceCollection());

			IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

			serviceProvider.GetService<IReader<Object, Object>>().Read(null);
		}
	}
}