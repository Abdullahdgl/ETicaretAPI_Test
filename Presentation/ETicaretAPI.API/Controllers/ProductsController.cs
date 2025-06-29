﻿using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ETicaretAPI.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		#region ilk deneme sadece ProductService için dumyy datadaki örnekleme

		/*
		private readonly IProductService _productService;

		public ProductsController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet]
		public IActionResult GetProducts()
		{
			var products = _productService.GetProducts();
			return Ok(products);
		}
		*/
		#endregion 

		readonly private IProductWriteRepository _productWriteRepository;
		readonly private IProductReadRepository _productReadRepository;

		public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
		{
			_productWriteRepository = productWriteRepository;
			_productReadRepository = productReadRepository;
		}
		[HttpGet]
		public async Task Get()
		{
			//await _productWriteRepository.AddRangeAsync(new()
			//{
			//	new(){Id=Guid.NewGuid(), Name="Product 1" , Price =100, CreatedDate=DateTime.UtcNow, Stock=10},
			//	new(){Id=Guid.NewGuid(), Name="Product 2" , Price =200, CreatedDate=DateTime.UtcNow, Stock=20},
			//	new(){Id=Guid.NewGuid(), Name="Product 3" , Price =300, CreatedDate=DateTime.UtcNow, Stock=40},

			//});
			//await _productWriteRepository.SaveAsync();
			Product p = await _productReadRepository.GetByIdAsync("8dc7eb2e-1cfc-405e-89e6-9bc41cafd6ff",false);
			p.Name = "Memo";
			 await _productWriteRepository.SaveAsync();
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(string id)
		{
			Product product = await _productReadRepository.GetByIdAsync(id);
			return Ok(product); 
		}
	}
}
