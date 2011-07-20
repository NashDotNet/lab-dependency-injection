using System.Collections.Generic;

namespace StructureMapMvcApplicaton.Infrastructure
{
	public class ProductRepository : IProductRepository
	{
		public IEnumerable<string> GetAll()
		{
			return new[] {"product 1", "product 2", "product 3"};
		}
	}
}