using Microsoft.AspNetCore.Mvc;
using Services;
using WebApi.Requests;
using WebApi.ViewModels;

namespace CarServiceSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportsController(IAutomobileService automobileService, IMasterService masterService) : ControllerBase
{
    [HttpGet]
    public IActionResult Get([FromQuery] ReportFilter reportRequest)
    {
        var autoReport = automobileService.GetRepairingAutomobilesByDate(reportRequest);
        var masterWorkLoadReport = masterService.GetPercentageOfMasterWorkload(reportRequest.Start, reportRequest.End);

        ReportViewModel results = new (autoReport, masterWorkLoadReport);

        return Ok(results);
    }
}
