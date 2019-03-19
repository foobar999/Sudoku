using Foobar999.Sudoku.Interface;
using Microsoft.Extensions.Logging;
using System;

namespace Foobar999.Sudoku.Io
{
	public class Reader : IReader<Object, Object>
	{
		private readonly ILogger<Reader> logger;

		public Reader(ILogger<Reader> logger)
		{
			this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		public Object Read(Object data)
		{
			this.logger.LogError("hallo");
			throw new NotImplementedException();
		}
	}
}