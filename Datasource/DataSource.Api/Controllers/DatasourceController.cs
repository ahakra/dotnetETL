using Microsoft.AspNetCore.Mvc;
using DataSource.Services;
using DataSource.Contracts;
using Microsoft.AspNetCore.Http;
using DataSource.Entities;

namespace DataSource.Api.Controllers;

[Route("api/datasource")]
[ApiController]
public class DatasourceController: ControllerBase {
    private readonly IServiceManager _service; public DatasourceController(IServiceManager service) => _service = service;
    
    public async Task<IActionResult> GetAllDatasources()
    {
        Console.WriteLine("Inside Getall Datasource controller");
        try
        {
            var datasources = await _service.DatasourceService.GetAllDatasources();

            if (datasources != null)
            {
                return Ok(datasources);
            }
            else
            {
                return NotFound();
            }
        }
        catch (Exception ex)
        {

            return StatusCode(500, "Internal server error");
        }
    }
    
    
    [HttpPost]
    public async Task<IActionResult> InsertDatasource([FromBody] DatasourceEntity datasource)
    {
        if (datasource == null)
        {
            return BadRequest("Datasource cannot be null");
        }
        try
        {
            _service.DatasourceService.InsertDatasource(datasource);
            return Ok();
        }
        catch (Exception ex)
        {
            Console.WriteLine( "Error while inserting datasources." + ex);
            return StatusCode(500, "Internal server error");
        }
    }
}