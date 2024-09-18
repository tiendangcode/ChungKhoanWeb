using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using api.Mappers;
using api.Dtos.Stock;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Microsoft.Identity.Client;
//using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;


namespace api.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/stock")]
    //[Microsoft.AspNetCore.Components.Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase 
    {
        private readonly ApplicationDBContext _context;
        public StockController(ApplicationDBContext context) 
        {
            _context = context;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
        var stocks = _context.Stocks.ToList()
        .Select(s => s.ToStockDto());
        return Ok(stocks);
        }

        [HttpGet("{id}")] 
        public IActionResult GetById([FromRoute] int id) 
        {
            var stock = _context.Stocks.Find(id);
            if(stock == null) 
            {
                return NotFound();
            }
            return Ok(stock.ToStockDto());

        }
        [HttpPost]
        public IActionResult Create ([FromBody] CreateStockRequestDto stockDto) 
        {
            var stockModel = stockDto.ToStockFromCreateDTO();
            _context.Stocks.Add(stockModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {id = stockModel.Id }, stockModel.ToStockDto());
        }
       
       [HtppPut]
       [Route("{id}")]
       
       public IActionResult Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
       {
            var stockModel = _context.Stocks.FirstOrDefault(x => x.Id == id);

            if(stockModel == null)
            {
                return NotFound();
            }

            stockModel.Symbol = updateDto.Symbol;
            stockModel.CompanyName = updateDto.CompanyName;
            stockModel.Purchase = updateDto.Purchase;
            stockModel.LastDiv = updateDto.LastDiv;
            stockModel.Industry = updateDto.Industry;
            stockModel.MarketCap = updateDto.MarketCap;
            _context.SaveChanges();
            return Ok(stockModel.ToStockDto());
       }




        private class HtppPutAttribute : Attribute
       {
        }
    }}

    
