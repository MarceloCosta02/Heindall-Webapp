using AppHeindall.Interfaces;
using AppHeindall.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.RegularExpressions;

namespace AppHeindall.Controllers;

public class IntegradoresdoUsuarioController : Controller
{
    private readonly IIntegradorDoUsuarioService _integradorDoUsuarioService;
    private readonly IIntegradorService _integradorService;
    private readonly IUsuarioService _usuarioService;

    public IntegradoresdoUsuarioController(IIntegradorDoUsuarioService integradorDoUsuarioService, 
        IIntegradorService integradorService, IUsuarioService usuarioService)
    {
        _integradorDoUsuarioService = integradorDoUsuarioService;
        _integradorService = integradorService;
        _usuarioService = usuarioService;
    }

    // GET: IntegradoresdoUsuario
    public async Task<IActionResult> Index()
    {
        var integradoresDeUsuarios = await _integradorDoUsuarioService.Obter();

        if (integradoresDeUsuarios is null)
            return Problem("Não existem Integradores de Usuarios a serem exibidos");

        return View(integradoresDeUsuarios);
    }

    // GET: IntegradoresdoUsuario/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
            return BadRequest("Id não pode ser nulo");

        var integradorDoUsuario = await _integradorDoUsuarioService.ObterPorId(id.Value);

        if (integradorDoUsuario == null)
            return NotFound($"Não foi encontrado um Integrador do Usuario com id {id}");

        return View(integradorDoUsuario);
    }

    // GET: IntegradoresdoUsuario/Create
    public async Task<IActionResult> Create()
    {
        ViewData["IntegradorId"] = new SelectList(await _integradorService.Obter(), "Id", "Id");
        ViewData["UsuarioId"] = new SelectList(await _usuarioService.Obter(), "Id", "Id");

        return View();
    }

    // POST: IntegradoresdoUsuario/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,UsuarioId,IntegradorId")] IntegradorDoUsuario integradordoUsuario)
    {
        if (ModelState.IsValid)
        {
            await _integradorDoUsuarioService.Criar(integradordoUsuario);
            return RedirectToAction(nameof(Index));
        }

        ViewData["IntegradorId"] = new SelectList(await _integradorService.Obter(), "Id", "Id");
        ViewData["UsuarioId"] = new SelectList(await _usuarioService.Obter(), "Id", "Id");

        return View(integradordoUsuario);
    }

    // GET: IntegradoresdoUsuario/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
            return BadRequest("Id não pode ser nulo");

        var integradorDoUsuario = await _integradorDoUsuarioService.ObterPorId(id.Value);

        if (integradorDoUsuario == null)
            return NotFound($"Não foi encontrado um Integrador do Usuario com id {id}");

        ViewData["IntegradorId"] = new SelectList(await _integradorService.Obter(), "Id", "Id");
        ViewData["UsuarioId"] = new SelectList(await _usuarioService.Obter(), "Id", "Id");

        return View(integradorDoUsuario);
    }

    // POST: IntegradoresdoUsuario/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,UsuarioId,IntegradorId")] IntegradorDoUsuario integradordoUsuario)
    {
        if (id != integradordoUsuario.Id)
            return NotFound("Ids divergentes");

        if (ModelState.IsValid)
        {
            try
            {
                await _integradorDoUsuarioService.Atualizar(id, integradordoUsuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }

        ViewData["IntegradorId"] = new SelectList(await _integradorService.Obter(), "Id", "Id");
        ViewData["UsuarioId"] = new SelectList(await _usuarioService.Obter(), "Id", "Id");

        return View(integradordoUsuario);
    }

    // GET: IntegradoresdoUsuario/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return BadRequest("Id não pode ser nulo");

        var integradorDoUsuario = await _integradorDoUsuarioService.ObterPorId(id.Value);

        if (integradorDoUsuario == null)
            return NotFound($"Não foi encontrado um Integrador do Usuario com id {id}");

        return View(integradorDoUsuario);
    }

    // POST: IntegradoresdoUsuario/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var integradorDoUsuario = await _integradorDoUsuarioService.ObterPorId(id);

        if (integradorDoUsuario == null)
        {
            await _integradorDoUsuarioService.Remover(id);
        }

        return RedirectToAction(nameof(Index));
    }
}
