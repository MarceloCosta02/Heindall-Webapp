using AppHeindall.Interfaces;
using AppHeindall.Models;

namespace AppHeindall.Services;

public class MetaService : IMetaService
{
	protected HttpClient _httpClient;

	public MetaService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public Task<IEnumerable<Meta>> Obter()
	{
		throw new NotImplementedException();
	}

	public Task<Meta> ObterPorId(int id)
	{
		throw new NotImplementedException();
	}

	public Task Criar(Meta item)
	{
		throw new NotImplementedException();
	}

	public Task Atualizar(int id, Meta item)
	{
		throw new NotImplementedException();
	}

	public Task Remover(int id)
	{
		throw new NotImplementedException();
	}
}
