using AppHeindall.Interfaces;
using AppHeindall.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AppHeindall.Controllers;

public class HomeController : Controller
{
	private readonly ILogger<HomeController> _logger;
	private readonly IImportacaoService _service;

	public HomeController(ILogger<HomeController> logger, IImportacaoService service)
	{
		_logger = logger;
		_service = service;
	}

	public IActionResult Index()
	{
		return View();
	}

	public IActionResult About()
	{
		return View();
	}
	public IActionResult Menu()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Importar()
	{
		try
		{
			await _service.ImportacaoRextur();
			return View("Index");
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);	
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

		}
	}

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
		return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
}