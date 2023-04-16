using Microsoft.AspNetCore.Mvc;
using AppHeindall.Models;
using AppHeindall.Interfaces;
using System.Text.RegularExpressions;

namespace AppHeindall.Controllers;

public class MetasController : Controller
{
	private readonly IMetaService _service;

	public MetasController(IMetaService service)
	{
		_service = service;
	}

	// GET: Metas
	public async Task<IActionResult> Index()
	{
		var metas = await _service.Obter();

		if (metas is null)
			return Problem("Não existem metas a serem exibidos");

		return View(metas);
	}

	// GET: Metas/Details/5
	public async Task<IActionResult> Details(int? id)
	{
		if (id == null)
			return BadRequest("Id não pode ser nulo");

		var meta = await _service.ObterPorId(id.Value);

		if (meta == null)
			return NotFound($"Não foi encontrado uma meta com id {id}");

		return View(meta);
	}

	// GET: Metas/Create
	public IActionResult Create()
	{
		return View();
	}

	// POST: Metas/Create
	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Create([Bind("Id,Prioridade,Projeto,Start,Finish,Demanda,Pendencia")] Meta meta)
	{
		if (ModelState.IsValid)
		{
			await _service.Criar(meta);
			return RedirectToAction(nameof(Index));
		}

		return View(meta);
	}

	// GET: Metas/Edit/5
	public async Task<IActionResult> Edit(int? id)
	{
		if (id == null)
			return BadRequest("Id não pode ser nulo");

		var meta = await _service.ObterPorId(id.Value);

		if (meta == null)
			return NotFound($"Não foi encontrado um meta com id {id}");

		return View(meta);
	}

	// POST: Metas/Edit/5
	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Edit(int id, [Bind("Id,Prioridade,Projeto,Start,Finish,Demanda,Pendencia")] Meta meta)
	{
		if (id != meta.Id)
			return NotFound("Ids divergentes");

		if (ModelState.IsValid)
		{
			try
			{
				await _service.Atualizar(id, meta);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

			return RedirectToAction(nameof(Index));
		}

		return View(meta);
	}

	// GET: Metas/Delete/5
	public async Task<IActionResult> Delete(int? id)
	{
		if (id == null)
			return BadRequest("Id não pode ser nulo");

		var meta = await _service.ObterPorId(id.Value);

		if (meta == null)
			return NotFound($"Não foi encontrado uma meta com id {id}");

		return View(meta);
	}

	// POST: Metas/Delete/5
	[HttpPost, ActionName("Delete")]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> DeleteConfirmed(int id)
	{
		var meta = await _service.ObterPorId(id);

		if (meta != null)
		{
			await _service.Remover(id);
		}

		return RedirectToAction(nameof(Index));
	}
}
