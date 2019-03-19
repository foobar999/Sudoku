namespace Foobar999.Sudoku.Interface
{
	public interface IMapper<in TData, out TResult>
	{
		TResult Map(TData data);
	}
}