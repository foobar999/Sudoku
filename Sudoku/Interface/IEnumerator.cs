using System.Collections.Generic;

namespace Foobar999.Sudoku.Interface
{
	public interface IEnumerator<in TData, out TResult>
	{
		IEnumerable<TResult> Get(TData data);
	}
}