using Allocator.API.DTO.StockHistoryRow;
using Allocator.API.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Allocator.API.Controllers;

[ApiController]
[Route("stock-history")]
[Produces("application/json")]
public class StockHistoryController : ControllerBase
{
    //private readonly ILogger<StockHistoryController> _logger;
    private readonly IStockHistoryRowService _stockHistoryRowService;
    private readonly IMapper _mapper;

    public StockHistoryController(IStockHistoryRowService stockHistoryRowService, IMapper mapper
        /*ILogger<StockHistoryController> logger*/)
    {
        _stockHistoryRowService = stockHistoryRowService;
        _mapper = mapper;
        //_logger = logger;
    }

    [Route("/stock-histories/{stockId}:int")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StockHistoryRowDTO>>> GetAll(int stockId)
    {
        throw new NotImplementedException();
    }

    [Route("{stockHistoryRowId}:int")]
    [HttpGet]
    public async Task<ActionResult<StockHistoryRowDTO>> Get(int stockHistoryRowId)
    {
        throw new NotImplementedException();
    }

    [Route("/stock-histories/")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StockHistoryRowDTO>>> GetRange(IEnumerable<int> stockHistoryRowIds)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<ActionResult<StockHistoryRowDTO>> Create(CreateStockHistoryRowDTO createStockHistoryRowDto)
    {
        //Redirect to get with created Id.
        throw new NotImplementedException();
    }

    [Route("/stock-histories")]
    [HttpPost]
    public async Task<ActionResult<IEnumerable<StockHistoryRowDTO>>> CreateRange(
        IEnumerable<CreateStockHistoryRowDTO> createStockHistoryRowDtoCollection)
    {
        //Redirect to get user with created Id's (createStockHistoryRowDtoCollection).
        throw new NotImplementedException();
    }

    [HttpPut]
    public async Task<ActionResult<StockHistoryRowDTO>> Update(StockHistoryRowDTO updateStockHistoryRowDto)
    {
        throw new NotImplementedException();
    }

    [Route("{stockHistoryRowId}:int")]
    [HttpDelete]
    public async Task<ActionResult> Delete(int stockHistoryRowId)
    {
        throw new NotImplementedException();
    }

    [Route("/stock-histories")]
    [HttpDelete]
    public async Task<ActionResult> DeleteRange(IEnumerable<int> stockHistoryRowIds)
    {
        throw new NotImplementedException();
    }
}
