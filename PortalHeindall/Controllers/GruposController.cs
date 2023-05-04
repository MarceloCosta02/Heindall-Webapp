using AppHeindall.Interfaces;
using AppHeindall.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppHeindall.Controllers;

public class GruposController : Controller
{
	private readonly IGrupoService _service;

	public GruposController(IGrupoService service)
	{
		_service = service;
	}

	// GET: Grupos
	public async Task<IActionResult> Index()
	{
		var grupos = await _service.Obter();

		if (grupos is null)
			return Problem("Não existem grupos a serem exibidos");

		return View(grupos);
	}

	// GET: Grupos/Details/5
	public async Task<IActionResult> Details(int? id)
	{
		if (id == null)
			return BadRequest("Id não pode ser nulo");

		var grupo = await _service.ObterPorId(id.Value);

		if (grupo == null)
			return NotFound($"Não foi encontrado um grupo com id {id}");

		return View(grupo);
	}

	// GET: Grupos/Create
	public IActionResult Create()
	{
		return View();
	}

	// POST: Grupos/Create
	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Create([Bind("GrupoName,GrupoDescription,GrupoType,GrupoArea,GrupoMetodo,GrupoURL,GrupoUser,GrupoPassword,GrupoPort,PublicKey,PrivateKey")] Grupo grupo)
	{
		if (ModelState.IsValid)
		{
			await _service.Criar(grupo);
			return RedirectToAction(nameof(Index));
		}

		return View(grupo);
	}

	// GET: Grupos/Edit/5
	public async Task<IActionResult> Edit(int? id)
	{
		if (id == null)
			return BadRequest("Id não pode ser nulo");

		var grupo = await _service.ObterPorId(id.Value);

		if (grupo == null)
			return NotFound($"Não foi encontrado um grupo com id {id}");

		return View(grupo);
	}

	// POST: Grupos/Edit/5
	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Edit(int id, [Bind("Id,GrupoName,GrupoDescription,GrupoType,GrupoArea,GrupoMetodo,GrupoURL,GrupoUser,GrupoPassword,GrupoPort,PublicKey,PrivateKey")] Grupo grupo)
	{
		if (id != grupo.Id)		
			return NotFound("Ids divergentes");		

		if (ModelState.IsValid)
		{
			try
			{
				await _service.Atualizar(id, grupo);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

			return RedirectToAction(nameof(Index));
		}

		return View(grupo);
	}

	// GET: Grupos/Delete/5
	public async Task<IActionResult> Delete(int? id)
	{
		if (id == null)
			return BadRequest("Id não pode ser nulo");

		var grupo = await _service.ObterPorId(id.Value);

		if (grupo == null)
			return NotFound($"Não foi encontrado um grupo com id {id}");

		return View(grupo);
	}

	// POST: Grupos/Delete/5
	[HttpPost, ActionName("Delete")]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> DeleteConfirmed(int id)
	{
		var grupo = await _service.ObterPorId(id);
		
		if (grupo != null)
		{
			await _service.Remover(id);
		}

		return RedirectToAction(nameof(Index));
	}
}
