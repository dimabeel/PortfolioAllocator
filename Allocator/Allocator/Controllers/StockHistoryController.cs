using Allocator.API.DTO.StockHistoryRow;
using Allocator.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Allocator.API.Controllers;

[ApiController]
[Route("stock-history")]
[Produces("application/json")]
public class StockHistoryController : ControllerBase
{
    //private readonly ILogger<StockHistoryController> _logger;
    private readonly IStockHistoryRowService _stockHistoryRowService;

    public StockHistoryController(IStockHistoryRowService stockHistoryRowService
        /*ILogger<StockHistoryController> logger*/)
    {
        _stockHistoryRowService = stockHistoryRowService;
        //_logger = logger;
    }

    [Route("stocks-history")]
    [HttpGet]
    public ActionResult<IEnumerable<StockHistoryRowDTO>> GetAll()
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public ActionResult<StockHistoryRowDTO> Get(int id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public ActionResult<StockHistoryRowDTO> Create(CreateStockHistoryRowDTO request)
    {
        //Redirect to get user with created AccountId.
        throw new NotImplementedException();
    }

    [HttpPut]
    public ActionResult<StockHistoryRowDTO> Update(StockHistoryRowDTO request)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    public ActionResult Delete(int id)
    {
        throw new NotImplementedException();
    }
}
