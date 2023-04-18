using AppHeindall.Enums;
using AppHeindall.Extensions;
using AppHeindall.Interfaces;
using AppHeindall.Models;
using Newtonsoft.Json;
using System.Diagnostics.Metrics;
using System.Net.Http.Headers;
using System.Text;

namespace AppHeindall.Services;

public class MetaService : IMetaService
{
	protected HttpClient _httpClient;

	public MetaService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public async Task<IEnumerable<Meta>> Obter()
	{
		string url = $"{Endpoints.Metas.Descricao()}";

		var response = await _httpClient.GetAsync(url);

		if (!response.IsSuccessStatusCode)
			throw new Exception($"Status Code: {response.StatusCode} - Erro ao chamar API: {url}");

		var metas = JsonConvert.DeserializeObject<IEnumerable<Meta>>(await response.Content.ReadAsStringAsync());

		return metas;
	}

	public async Task<Meta> ObterPorId(int id)
	{
		string url = $"{Endpoints.MetasObterPorId.Descricao()}?id={id}";

		var response = await _httpClient.GetAsync(url);

		if (!response.IsSuccessStatusCode)
			throw new Exception($"Status Code: {response.StatusCode} - Erro ao chamar API: {url}");

		var meta = JsonConvert.DeserializeObject<Meta>(await response.Content.ReadAsStringAsync());

		return meta;
	}

	public async Task Criar(Meta item)
	{
		string url = $"{Endpoints.Metas.Descricao()}";

		var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, mediaType: new MediaTypeHeaderValue("application/json"));

		var response = await _httpClient.PostAsync(url, content);

		if (!response.IsSuccessStatusCode)
			throw new Exception($"Status Code: {response.StatusCode} - Erro ao chamar API: {url}");
	}

	public async Task Atualizar(int id, Meta item)
	{
		string url = $"{Endpoints.Metas.Descricao()}?id={id}";

		var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, mediaType: new MediaTypeHeaderValue("application/json"));

		var response = await _httpClient.PutAsync(url, content);

		if (!response.IsSuccessStatusCode)
			throw new Exception($"Status Code: {response.StatusCode} - Erro ao chamar API: {url}");
	}

	public async Task Remover(int id)
	{
		string url = $"{Endpoints.Metas.Descricao()}?id={id}";

		var response = await _httpClient.DeleteAsync(url);

		if (!response.IsSuccessStatusCode)
			throw new Exception($"Status Code: {response.StatusCode} - Erro ao chamar API: {url}");
	}
}
