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
    //[Authorize]
    public class ProductController : /*BaseController*/ ControllerBase
    {
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public bool CheckLogin()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return false;
            }
            return true;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct([FromQuery] PagingParameter paging)
        {
            //var status = CheckToken();
            //if (status.StatusCode == 401)
            //{
            //    return Ok(new PageList<StatusResponse>(
            //        status.StatusCode,
            //        status.Messages,
            //        status.Token
            //    ));
            //}
            if (!CheckLogin())
            {
                return Ok(new
                {
                    StatusCode = 401,
                    Messages = "Error"
                });
            }
            var pageList = await _productRepository.GetAllProduct(paging);

            var productList = pageList.Items.Select(x => new Producted()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                UserId = x.UserId,
                Status = x.Status,
                Created_at = x.Created_at,
                Updated_at = x.Updated_at,
            }).Where(x => x.Status == true);

            return Ok(new PageList<Producted>(
                productList.ToList(),
                pageList.metaData.TotalCount,
                pageList.metaData.CurrentPage,
                pageList.metaData.PageSize
            ));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetail(Guid id)
        {
            var product = await _productRepository.GetProductDetail(id);

            if (product == null)
            {
                return NotFound($"{id} is not found");
            }

            return Ok(product);
        }

        [HttpPost]
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
                Created_at = DateTime.Now,
                Updated_at = DateTime.Now,
                Status = true
            });

            return CreatedAtAction(nameof(GetProductDetail), new { id = productCreate.Id }, productCreate);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdatedProduct(Guid id, [FromBody] UpdateProduct req)
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
            product.Updated_at = DateTime.Now;

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
        public async Task<IActionResult> DeletedSoftProduct(Guid id)
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
            product.Updated_at = DateTime.Now;

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
        public async Task<IActionResult> DeletedEternalProduct(Guid id)
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
