using Allocator.API.DTO.Stock;
using Allocator.API.Models;
using Allocator.API.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Allocator.API.Controllers;

[ApiController]
[Route("v{api:apiVersion}/stock")]
[Produces("application/json")]
[ApiVersion("1.0")]
public class StockController : ControllerBase
{
    private readonly ILogger<StockController> _logger;
    private readonly IStockService _stockService;
    private readonly IMapper _mapper;

    public StockController(IStockService stockService, IMapper mapper, ILogger<StockController> logger)
    {
        _stockService = stockService;
        _mapper = mapper;
        _logger = logger;
    }

    [Route("/v{api:apiVersion}/stocks/{accountId}:int")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StockDTO>>> GetByAccount(int accountId)
    {
        var stocks = await _stockService.GetStocks(accountId);
        var stocksDto = _mapper.Map<IEnumerable<StockDTO>>(stocks);
        return Ok(stocksDto);
    }

    [Route("{stockId}:int")]
    [HttpGet]
    public async Task<ActionResult<StockDTO>> Get(int stockId)
    {
        var stock = await _stockService.GetStock(stockId);
        var stockDto = _mapper.Map<StockDTO>(stock);
        return Ok(stockDto);
    }

    [HttpPost]
    public async Task<ActionResult> Create(CreateStockDTO createStockDto)
    {
        var stock = _mapper.Map<Stock>(createStockDto);
        var createdStock = await _stockService.Create(stock);
        return RedirectToAction(nameof(Get), new { stockId = createdStock.StockId});
    }

    [HttpPut]
    public async Task<ActionResult<StockDTO>> Update(StockDTO updateStockDto)
    {
        var stock = _mapper.Map<Stock>(updateStockDto);
        var updatedStock = await _stockService.Update(stock);
        var updatedStockDto = _mapper.Map<StockDTO>(updatedStock);
        return Ok(updatedStockDto);
    }

    [Route("{stockId}:int")]
    [HttpDelete]
    public async Task<ActionResult> Delete(int stockId)
    {
        await _stockService.Remove(stockId);
        return NoContent();
    }

    [Route("/v{api:apiVersion}/stocks")]
    [HttpDelete]
    public async Task<ActionResult> DeleteRange(IEnumerable<int> stockIds)
    {
        await _stockService.RemoveRange(stockIds);
        return NoContent();
    }
}