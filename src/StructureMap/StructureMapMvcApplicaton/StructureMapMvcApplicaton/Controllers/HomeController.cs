using System.Collections.Generic;
using System.Web.Mvc;
using StructureMapMvcApplicaton.Infrastructure;
using StructureMapMvcApplicaton.Models;

namespace StructureMapMvcApplicaton.Controllers
{
	public class HomeController : Controller
	{
		readonly IProductRepository _productRepository;

		public HomeController(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public ActionResult Index()
		{
			IEnumerable<string> products = _productRepository.GetAll();
			var model = new HomeViewModel {Products = products};
			return View(model);
		}
	}
}