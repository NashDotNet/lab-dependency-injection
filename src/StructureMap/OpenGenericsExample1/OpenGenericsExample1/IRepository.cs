using System.Collections.Generic;

namespace OpenGenericsExample2
{
	public interface IRepository<T>
	{
		IEnumerable<T> GetAll();
	}
}