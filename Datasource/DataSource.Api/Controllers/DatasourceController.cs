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
         var insertedDatasource = await _service.DatasourceService.InsertDatasource(datasource);
         return StatusCode(200,  insertedDatasource);

        }
        catch (Exception ex)
        {
            Console.WriteLine( "Error while inserting datasources." + ex);
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDatasource(string id)
    {
        try
        {
            var isDeleted = await _service.DatasourceService.DeleteDatasource(id);

            if (isDeleted)
            {
                return NoContent(); // 204 No Content if the document was successfully deleted
            }
            else
            {
                return NotFound(); // 404 Not Found if the document with the specified id was not found
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions and return an appropriate response
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }
}