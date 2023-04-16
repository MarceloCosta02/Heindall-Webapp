using AppHeindall.Interfaces;
using AppHeindall.Models;

namespace AppHeindall.Services;

public class UsuarioService : IUsuarioService
{
	protected HttpClient _httpClient;

	public UsuarioService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public Task<IEnumerable<Usuario>> Obter()
	{
		throw new NotImplementedException();
	}

	public Task<Usuario> ObterPorId(int id)
	{
		throw new NotImplementedException();
	}

	public Task Criar(Usuario item)
	{
		throw new NotImplementedException();
	}

	public Task Atualizar(int id, Usuario item)
	{
		throw new NotImplementedException();
	}

	public Task Remover(int id)
	{
		throw new NotImplementedException();
	}
}
