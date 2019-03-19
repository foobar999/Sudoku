namespace Foobar999.Sudoku.Interface
{
	public interface IReader<in TData, out TResult>
	{
		TResult Read(TData data);
	}
}