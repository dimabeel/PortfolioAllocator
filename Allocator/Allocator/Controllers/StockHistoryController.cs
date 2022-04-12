using Allocator.API.DTO.StockHistoryRow;
using Allocator.API.Models;
using Allocator.API.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Allocator.API.Controllers;

[ApiController]
[Route("v{api:apiVersion}/stock-history")]
[Produces("application/json")]
[ApiVersion("1.0")]
public class StockHistoryController : ControllerBase
{
    private readonly ILogger<StockHistoryController> _logger;
    private readonly IStockHistoryRowService _stockHistoryRowService;
    private readonly IMapper _mapper;

    public StockHistoryController(IStockHistoryRowService stockHistoryRowService, IMapper mapper,
        ILogger<StockHistoryController> logger)
    {
        _stockHistoryRowService = stockHistoryRowService;
        _mapper = mapper;
        _logger = logger;
    }

    [Route("/v{api:apiVersion}/stock-histories/{stockId}:int")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StockHistoryRowDTO>>> GetByStock(int stockId)
    {
        var stockHistoryRows = await _stockHistoryRowService.GetStockHistoryRows(stockId);
        var stockHistoryRowsDto = _mapper.Map<IEnumerable<StockHistoryRowDTO>>(stockHistoryRows);
        return Ok(stockHistoryRowsDto);
    }

    [Route("/v{api:apiVersion}/stock-histories/")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StockHistoryRowDTO>>> GetRange([FromQuery]IEnumerable<int> stockHistoryRowIds)
    {
        var stockHistoryRows = await _stockHistoryRowService.GetStockHistoryRows(stockHistoryRowIds);
        var stockHistoryRowsDto = _mapper.Map<IEnumerable<StockHistoryRowDTO>>(stockHistoryRows);
        return Ok(stockHistoryRowsDto);
    }

    [Route("/v{api:apiVersion}/stock-histories/{stockId}:int/{from}:datetime/{till}:datetime")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StockHistoryRowDTO>>> GetRange(int stockId, DateTime from, DateTime till)
    {
        var stockHistoryRows = await _stockHistoryRowService.GetStockHistoryRows(stockId, from, till);
        var stockHistoryRowsDto = _mapper.Map<IEnumerable<StockHistoryRowDTO>>(stockHistoryRows);
        return Ok(stockHistoryRowsDto);
    }

    [Route("{stockHistoryRowId}:int")]
    [HttpGet]
    public async Task<ActionResult<StockHistoryRowDTO>> Get(int stockHistoryRowId)
    {
        var stockHistoryRow = await _stockHistoryRowService.GetStockHistoryRow(stockHistoryRowId);
        var stockHistoryRowDto = _mapper.Map<StockHistoryRowDTO>(stockHistoryRow);
        return Ok(stockHistoryRowDto);
    }

    [HttpPost]
    public async Task<RedirectToActionResult> Create(CreateStockHistoryRowDTO createStockHistoryRowDto)
    {
        var stockHistoryRow = _mapper.Map<StockHistoryRow>(createStockHistoryRowDto);
        var createdStockHistoryRow = await _stockHistoryRowService.Create(stockHistoryRow);
        return RedirectToAction(nameof(Get), new { stockHistoryRowId = createdStockHistoryRow.StockHistoryRowId});
    }

    [Route("/v{api:apiVersion}/stock-histories")]
    [HttpPost]
    public async Task<ActionResult> CreateRange(
        IEnumerable<CreateStockHistoryRowDTO> createStockHistoryRowDtoCollection)
    {
        var stockHistoryRows = _mapper.Map<IEnumerable<StockHistoryRow>>(createStockHistoryRowDtoCollection);
        var createdStockHistoryRows = await _stockHistoryRowService.CreateRange(stockHistoryRows);
        var createdIds = createdStockHistoryRows.Select(x => x.StockHistoryRowId);
        return RedirectToAction(nameof(GetRange), new { stockHistoryRowIds = createdIds });
    }

    [HttpPut]
    public async Task<ActionResult<StockHistoryRowDTO>> Update(StockHistoryRowDTO updateStockHistoryRowDto)
    {
        var stockHistoryRow = _mapper.Map<StockHistoryRow>(updateStockHistoryRowDto);
        var updatedStockHistoryRow = await _stockHistoryRowService.Update(stockHistoryRow);
        var updatedStockHistoryRowDto = _mapper.Map<StockHistoryRowDTO>(updatedStockHistoryRow);
        return Ok(updatedStockHistoryRowDto);
    }

    [Route("{stockHistoryRowId}:int")]
    [HttpDelete]
    public async Task<ActionResult> Delete(int stockHistoryRowId)
    {
        await _stockHistoryRowService.Remove(stockHistoryRowId);
        return NoContent();
    }

    [Route("/v{api:apiVersion}/stock-histories")]
    [HttpDelete]
    public async Task<ActionResult> DeleteRange(IEnumerable<int> stockHistoryRowIds)
    {
        await _stockHistoryRowService.RemoveRange(stockHistoryRowIds);
        return NoContent();
    }
}
