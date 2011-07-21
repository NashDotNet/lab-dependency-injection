using System.Collections.Generic;

namespace OpenGenericsExample2
{
	public class ConcreteRepository<T> : IRepository<T>
	{
		readonly IDatabaseContext _databaseContext;

		public ConcreteRepository(IDatabaseContext databaseContext)
		{
			_databaseContext = databaseContext;
		}

		public IEnumerable<T> GetAll()
		{
			var items = _databaseContext.Query<T>();
			return items;
		}
	}
}