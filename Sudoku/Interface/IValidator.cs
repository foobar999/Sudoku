namespace Foobar999.Sudoku.Interface
{
	public interface IValidator<in TData, out TResult>
	{
		TResult ValidateThrows(TData data);
	}
}