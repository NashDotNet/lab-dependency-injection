using System.Collections.Generic;

namespace OpenGenericsExample2
{
	public interface IDatabaseContext
	{
		IEnumerable<T> Query<T>();
	}
}