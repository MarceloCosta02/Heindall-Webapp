using AppHeindall.Interfaces;
using AppHeindall.Models;

namespace AppHeindall.Services;

public class IntegradorService : IIntegradorService
{
	protected HttpClient _httpClient;

	public IntegradorService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public Task<IEnumerable<Integrador>> Obter()
	{
		throw new NotImplementedException();
	}

	public Task<Integrador> ObterPorId(int id)
	{
		throw new NotImplementedException();
	}

	public Task Criar(Integrador item)
	{
		throw new NotImplementedException();
	}

	public Task Atualizar(int id, Integrador item)
	{
		throw new NotImplementedException();
	}

	public Task Remover(int id)
	{
		throw new NotImplementedException();
	}
}
