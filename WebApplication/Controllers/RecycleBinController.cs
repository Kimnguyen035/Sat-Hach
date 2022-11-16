using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Repositories;
using WebModels;
using WebModels.Pagination;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecycleBinController : ControllerBase
    {
        private IRecycleBinRepository _recycleBinRepository;
        private IProductRepository _productRepository;

        public RecycleBinController(IRecycleBinRepository recycleBinRepository, IProductRepository productRepository)
        {
            _recycleBinRepository = recycleBinRepository;
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct([FromQuery] PagingParameter paging)
        {
            var list = await _recycleBinRepository.GetAllRecycleBin();

            var recycleList = list.Select(x => new Producted()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                UserId = x.UserId,
                Status = x.Status,
                Created_at = x.Created_at,
                Updated_at = x.Updated_at,
            }).Where(x => x.Status == false);

            return Ok(recycleList);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Restore(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var product = await _productRepository.GetProductDetail(id);

            if (product == null)
            {
                return NotFound($"{id} is not found");
            }

            product.Status = true;
            product.Updated_at = DateTime.Now;

            var Restore = await _productRepository.UpdatedProduct(product);
            return Ok(new Producted
            {
                Status = Restore.Status,
                Name = Restore.Name,
                Price = Restore.Price,
                UserId = Restore.UserId,
                Created_at = Restore.Created_at,
                Updated_at = Restore.Updated_at,
                Id = Restore.Id
            });
        }
    }
}
