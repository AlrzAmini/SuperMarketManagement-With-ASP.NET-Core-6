using Microsoft.AspNetCore.Mvc;
using SuperMarketManagement.Application.DTOs.Product;

namespace SuperMarketManagement.Web.Controllers.Product
{
    [Route("products")]
    public class ProductsController : BaseController
    {
        #region index

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        #endregion

        #region add

        [HttpGet("add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost("add")]
        public IActionResult Add(CreateProductDto createProductDto)
        {
            if (!ModelState.IsValid)
            {
                return View(createProductDto);
            }
            return View();
        }        

        #endregion

        #region edit

        [HttpGet("edit/{productId}")]
        public IActionResult Edit(int productId)
        {
            return View();
        }

        #endregion

        #region delete

        [HttpGet("delete/{productId}")]
        public IActionResult Delete(int productId)
        {
            return View();
        }

        #endregion

        #region details

        [HttpGet("details/{productId}")]
        public IActionResult Details(int productId)
        {
            return View();
        }

        #endregion
    }
}
