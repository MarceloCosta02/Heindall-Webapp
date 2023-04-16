using AppHeindall.Interfaces;
using AppHeindall.Models;

namespace AppHeindall.Services;

public class GrupoService : IGrupoService
{
	protected HttpClient _httpClient;

	public GrupoService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public Task<IEnumerable<Grupo>> Obter()
	{
		throw new NotImplementedException();
	}

	public Task<Grupo> ObterPorId(int id)
	{
		throw new NotImplementedException();
	}

	public Task Criar(Grupo item)
	{
		throw new NotImplementedException();
	}

	public Task Atualizar(int id, Grupo item)
	{
		throw new NotImplementedException();
	}

	public Task Remover(int id)
	{
		throw new NotImplementedException();
	}
}
