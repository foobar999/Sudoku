namespace Foobar999.Sudoku.Interface
{
	public interface IProcessor<in TData, out TResult>
	{
		TResult Process(TData data);
	}
}