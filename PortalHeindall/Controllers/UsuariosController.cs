using AppHeindall.Interfaces;
using AppHeindall.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace AppHeindall.Controllers;

public class UsuariosController : Controller
{
	private readonly IUsuarioService _service;

	public UsuariosController(IUsuarioService service)
	{
		_service = service;
	}

	// GET: Usuarios
	public async Task<IActionResult> Index()
	{
		var usuarios = await _service.Obter();

		if (usuarios is null)
			return Problem("Não existem usuarios a serem exibidos");

		return View(usuarios);
	}

	// GET: Usuarios/Details/5
	public async Task<IActionResult> Details(int? id)
	{
		if (id == null)
			return BadRequest("Id não pode ser nulo");

		var usuario = await _service.ObterPorId(id.Value);

		if (usuario == null)
			return NotFound($"Não foi encontrado um usuario com id {id}");

		return View(usuario);
	}

	// GET: Usuarios/Create
	public IActionResult Create()
	{
		return View();
	}

	// POST: Usuarios/Create
	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Create([Bind("Id,UsuarioId,UsuarioName,UsuarioIDAgencia,UsuarioCNPJ,UsuarioNivel,UsuarioBancoDestino")] Usuario usuario)
	{
		if (ModelState.IsValid)
		{
			await _service.Criar(usuario);
			return RedirectToAction(nameof(Index));
		}

		return View(usuario);
	}

	// GET: Usuarios/Edit/5
	public async Task<IActionResult> Edit(int? id)
	{
		if (id == null)
			return BadRequest("Id não pode ser nulo");

		var usuario = await _service.ObterPorId(id.Value);

		if (usuario == null)
			return NotFound($"Não foi encontrado um usuario com id {id}");

		return View(usuario);
	}

	// POST: Usuarios/Edit/5
	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Edit(int id, [Bind("Id,UsuarioId,UsuarioName,UsuarioIDAgencia,UsuarioCNPJ,UsuarioNivel,UsuarioBancoDestino")] Usuario usuario)
	{
		if (id != usuario.Id)
			return NotFound("Ids divergentes");

		if (ModelState.IsValid)
		{
			try
			{
				await _service.Atualizar(id, usuario);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

			return RedirectToAction(nameof(Index));
		}

		return View(usuario);
	}

	// GET: Usuarios/Delete/5
	public async Task<IActionResult> Delete(int? id)
	{
		if (id == null)
			return BadRequest("Id não pode ser nulo");

		var usuario = await _service.ObterPorId(id.Value);

		if (usuario == null)
			return NotFound($"Não foi encontrado um usuario com id {id}");

		return View(usuario);
	}

	// POST: Usuarios/Delete/5
	[HttpPost, ActionName("Delete")]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> DeleteConfirmed(int id)
	{
		var usuario = await _service.ObterPorId(id);

		if (usuario != null)
		{
			await _service.Remover(id);
		}

		return RedirectToAction(nameof(Index));
	}
}
