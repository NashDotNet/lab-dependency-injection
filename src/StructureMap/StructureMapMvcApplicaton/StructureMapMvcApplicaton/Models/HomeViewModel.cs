using System.Collections.Generic;

namespace StructureMapMvcApplicaton.Models
{
	public class HomeViewModel
	{
		public IEnumerable<string> Products { get; set; }
	}
}