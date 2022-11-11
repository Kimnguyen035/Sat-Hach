using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Entities;
using WebApplication.Repositories;
using WebModels;
using WebModels.Pagination;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;
        private IRoleRepository _roleRepository;

        public ProductController(IProductRepository productRepository, IRoleRepository roleRepository)
        {
            _productRepository = productRepository;
            _roleRepository = roleRepository;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> GetAllProduct([FromQuery] PagingParameter paging)
        {
            var pageList = await _productRepository.GetAllProduct(paging);

            var productList = pageList.Items;

            return Ok(new PageList<Product>(
                productList.ToList(),
                pageList.metaData.TotalCount,
                pageList.metaData.CurrentPage,
                pageList.metaData.PageSize
            ));
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> GetProductDetail(long id)
        {
            var product = await _productRepository.GetProductDetail(id);

            if (product == null)
            {
                return NotFound($"{id} is not found");
            }

            return Ok(product);
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProduct req)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var productCreate = await _productRepository.CreateProduct(new Product
            {
                Name = req.Name,
                Price = req.Price,
                Created_at = DateTime.UtcNow,
                Updated_at = DateTime.UtcNow,
                Status = true
            });

            return CreatedAtAction(nameof(GetProductDetail), new { id = productCreate.Id }, productCreate);
        }

        [HttpPut("update/{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> UpdatedProduct(long id, [FromBody] UpdateProduct req)
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

            product.Name = req.Name;
            product.Price = req.Price;
            product.Updated_at = DateTime.UtcNow;

            var productUpdate = await _productRepository.UpdatedProduct(product);
            return Ok(new Producted
            {
                Status = productUpdate.Status,
                Name = productUpdate.Name,
                Price = productUpdate.Price,
                UserId = productUpdate.UserId,
                Created_at = productUpdate.Created_at,
                Updated_at = productUpdate.Updated_at,
                Id = productUpdate.Id
            });
        }

        [HttpPut("deleteSoft/{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> DeletedSoftProduct(long id)
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

            product.Status = false;

            var productDelete = await _productRepository.UpdatedProduct(product);
            return Ok(new Producted
            {
                Status = productDelete.Status,
                Name = productDelete.Name,
                Price = productDelete.Price,
                UserId = productDelete.UserId,
                Created_at = productDelete.Created_at,
                Updated_at = productDelete.Updated_at,
                Id = productDelete.Id
            });
        }

        [HttpDelete("deleteEternal/{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> DeletedEternalProduct(long id)
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

            var productDelete = await _productRepository.DeleteProduct(product);
            return Ok(new Producted
            {
                Status = productDelete.Status,
                Name = productDelete.Name,
                Price = productDelete.Price,
                UserId = productDelete.UserId,
                Created_at = productDelete.Created_at,
                Updated_at = productDelete.Updated_at,
                Id = productDelete.Id
            });
        }
    }
}
