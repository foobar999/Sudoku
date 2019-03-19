using Foobar999.Sudoku.Interface;
using Foobar999.Sudoku.Io;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Foobar999.Sudoku.DependencyInjection
{
	public class ServiceConfigurator
	{
		public IServiceCollection ConfigureServices(IServiceCollection services)
		{
			services.AddTransient<IReader<Object, Object>, Reader>();

			return services;
		}
	}
}