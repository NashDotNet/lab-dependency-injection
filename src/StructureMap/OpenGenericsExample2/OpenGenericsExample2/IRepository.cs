using System.Collections.Generic;

namespace OpenGenericsExample2
{
	public interface IRepository<T>
	{
		IEnumerable<T> GetAll();
	}

	public class FruitRepository : IRepository<Fruit>
	{
		public IEnumerable<Fruit> GetAll()
		{
			yield return new Fruit("Apple");
			yield return new Fruit("Orange");
			yield return new Fruit("Peach");
		}
	}
}