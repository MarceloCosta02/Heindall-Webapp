using AppHeindall.Interfaces;
using AppHeindall.Models;

namespace AppHeindall.Services;

public class IntegradorDoUsuarioService : IIntegradorDoUsuarioService
{
	protected HttpClient _httpClient;

	public IntegradorDoUsuarioService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public Task<IEnumerable<IntegradorDoUsuario>> Obter()
	{
		throw new NotImplementedException();
	}

	public Task<IntegradorDoUsuario> ObterPorId(int id)
	{
		throw new NotImplementedException();
	}

	public Task Criar(IntegradorDoUsuario item)
	{
		throw new NotImplementedException();
	}

	public Task Atualizar(int id, IntegradorDoUsuario item)
	{
		throw new NotImplementedException();
	}

	public Task Remover(int id)
	{
		throw new NotImplementedException();
	}
}
