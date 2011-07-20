using System.Collections.Generic;

namespace StructureMapMvcApplicaton.Infrastructure
{
	public interface IProductRepository
	{
		IEnumerable<string> GetAll();
	}
}