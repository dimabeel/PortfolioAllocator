using Allocator.API.DTO.StockHistoryRow;
using Microsoft.AspNetCore.Mvc;

namespace Allocator.API.Controllers;

[ApiController]
[Route("stock-history")]
[Produces("application/json")]
public class StockHistoryController : ControllerBase
{

    private readonly ILogger<StockHistoryController> _logger;

    public StockHistoryController(ILogger<StockHistoryController> logger)
    {
        _logger = logger;
    }

    [Route("by-stock")]
    [HttpGet]
    public IEnumerable<StockHistoryRowDTO> GetAll(GetStockHistoryRowsByStockDTO request)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public ActionResult<StockHistoryRowDTO> Get(GetStockHistoryRowDTO request)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public ActionResult<StockHistoryRowDTO> Create(CreateStockHistoryRowDTO request)
    {
        //Redirect to get user with created Id.
        throw new NotImplementedException();
    }

    [HttpPut]
    public ActionResult<StockHistoryRowDTO> Update(StockHistoryRowDTO request)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    public ActionResult Delete(GetStockHistoryRowDTO request)
    {
        throw new NotImplementedException();
    }
}
