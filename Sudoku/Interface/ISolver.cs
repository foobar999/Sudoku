namespace Foobar999.Sudoku.Interface
{
	public interface ISolver<in TData, out TResult>
	{
		TResult Solve(TData data);
	}
}