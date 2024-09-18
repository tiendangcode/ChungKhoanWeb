using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Models;
//using api.Dtos; // hoặc namespace chính xác chứa StockDto

namespace api.Mappers
{
    public static class StockMappers
    {
        public static StockDto ToStockDto(this Stock stockModel)
        {
            return new StockDto 
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Purchase = stockModel.Purchase,
                LastDiv = stockModel.LastDiv,
                Industry = stockModel.Industry,
                MarketCap = stockModel.MarketCap,

            };
        }
        public static Stock ToStockFromCreateDTO(this CreateStockRequestDto stockDto) 
        {
            return new Stock 
        {
            Symbol = stockDto.Symbol,
            CompanyName = stockDto.CompanyName,
            Purchase = stockDto.Purchase,
            LastDiv = stockDto.LastDiv,
            Industry = stockDto.Industry,
            MarketCap = stockDto.MarketCap
        };
    }

    public class StockDto
    {
        public int Id { get; internal set; }
        public string? Symbol { get; internal set; }
        public string? CompanyName { get; internal set; }
        public decimal Purchase { get; internal set; }
        public decimal LastDiv { get; internal set; }
        public string? Industry { get; internal set; }
        public long MarketCap { get; internal set; }
    }
}
}