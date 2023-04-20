using AppHeindall.Interfaces;
using AppHeindall.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.RegularExpressions;

namespace AppHeindall.Controllers;

public class IntegradoresController : Controller
{
	private readonly IIntegradorService _integradorService;
	private readonly IGrupoService _grupoService;

	public IntegradoresController(IIntegradorService integradorService, IGrupoService grupoService)
	{
		_integradorService = integradorService;
		_grupoService = grupoService;
	}

	// GET: Integradores
	public async Task<IActionResult> Index()
	{
		var integradores = await _integradorService.Obter();

		if (integradores is null)
			return Problem("Não existem integradores a serem exibidos");

		return View(integradores);
	}

	// GET: Integradores/Details/5
	public async Task<IActionResult> Details(int? id)
	{
		if (id == null)
			return BadRequest("Id não pode ser nulo");

		var integrador = await _integradorService.ObterPorId(id.Value);

		if (integrador == null)
			return NotFound($"Não foi encontrado um integrador com id {id}");

		return View(integrador);
	}

	// GET: Integradores/Create
	public async Task<IActionResult> Create()
	{
		ViewData["GrupoId"] = new SelectList(await _grupoService.Obter(), "Id", "Id");
		return View();
	}

	// POST: Integradores/Create
	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Create([Bind("IntegradorNome,IntegradorGrupo,IntegradorEndpoint,IntegradorPublicKey,IntegradorPrivateKey,GrupoId")] Integrador integrador)
	{
		if (ModelState.IsValid)
		{
			await _integradorService.Criar(integrador);
			return RedirectToAction(nameof(Index));
		}

		ViewData["GrupoId"] = new SelectList(await _grupoService.Obter(), "Id", "Id");
		
		return View(integrador);
	}

	// GET: Integradores/Edit/5
	public async Task<IActionResult> Edit(int? id)
	{
		if (id == null)
			return BadRequest("Id não pode ser nulo");

		var integrador = await _integradorService.ObterPorId(id.Value);

		if (integrador == null)
			return NotFound($"Não foi encontrado um integrador com id {id}");

		ViewData["GrupoId"] = new SelectList(await _grupoService.Obter(), "Id", "Id");

		return View(integrador);
	}

	// POST: Integradores/Edit/5
	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Edit(int id, [Bind("Id,IntegradorNome,IntegradorGrupo,IntegradorEndpoint,IntegradorPublicKey,IntegradorPrivateKey,GrupoId")] Integrador integrador)
	{
		if (id != integrador.Id)
			return NotFound("Ids divergentes");

		if (ModelState.IsValid)
		{
			try
			{
				await _integradorService.Atualizar(id, integrador);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

			return RedirectToAction(nameof(Index));
		}
		ViewData["GrupoId"] = new SelectList(await _grupoService.Obter(), "Id", "Id");
	   
		return View(integrador);
	}

	// GET: Integradores/Delete/5
	public async Task<IActionResult> Delete(int? id)
	{
		if (id == null)
			return BadRequest("Id não pode ser nulo");

		var integrador = await _integradorService.ObterPorId(id.Value);

		if (integrador == null)
			return NotFound($"Não foi encontrado um integrador com id {id}");

		return View(integrador);
	}

	// POST: Integradores/Delete/5
	[HttpPost, ActionName("Delete")]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> DeleteConfirmed(int id)
	{
		var integrador = await _integradorService.ObterPorId(id);

		if (integrador != null)
		{
			await _integradorService.Remover(id);
		}

		return RedirectToAction(nameof(Index));
	}
}
