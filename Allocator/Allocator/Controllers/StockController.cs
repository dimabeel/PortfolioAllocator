using Allocator.API.DTO.Stock;
using Allocator.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Allocator.API.Controllers;

[ApiController]
[Route("stock")]
[Produces("application/json")]
public class StockController : ControllerBase
{
    //private readonly ILogger<StockController> _logger;
    private readonly IStockService _stockService;

    public StockController(IStockService stockService /*ILogger<StockController> logger*/)
    {
        _stockService = stockService;
        //_logger = logger;
    }

    [Route("by-account")]
    [HttpGet]
    public IEnumerable<StockDTO> GetAll(GetStocksByAccountDTO request)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public ActionResult<StockDTO> Get(GetStockDTO request)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public ActionResult<StockDTO> Create(CreateStockDTO request)
    {
        //Redirect to get user with created Id.
        throw new NotImplementedException();
    }

    [HttpPut]
    public ActionResult<StockDTO> Update(StockDTO request)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    public ActionResult Delete(GetStockDTO request)
    {
        throw new NotImplementedException();
    }
}