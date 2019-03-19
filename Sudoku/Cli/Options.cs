using CommandLine;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Foobar999.Sudoku.Cli
{
	[ExcludeFromCodeCoverage]
	public class Options
	{
		[Option('f', "file", Required = true, HelpText = "Input sudoku file to be processed.")]
		public String FilePath { get; set; }

		// Omitting long name, defaults to name of property, ie "--verbose"
		//[Option(Default = false,
		//	HelpText = "Prints all messages to standard output.")]
		//public bool Verbose { get; set; }

		[Option('r', "blockrows", Default = 0, HelpText = "Number of rows per block")]
		public Int32 NumBlockRows { get; set; }

		[Option('c', "blockcolumns", Default = 0, HelpText = "Number of columns per block")]
		public Int32 NumBlockColumns { get; set; }
	}
}