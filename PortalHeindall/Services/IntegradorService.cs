using AppHeindall.Enums;
using AppHeindall.Extensions;
using AppHeindall.Interfaces;
using AppHeindall.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace AppHeindall.Services;

public class IntegradorService : IIntegradorService
{
	protected HttpClient _httpClient;

	public IntegradorService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public async Task<IEnumerable<Integrador>> Obter()
	{
		string url = $"{Endpoints.Integradores.Descricao()}";

		var response = await _httpClient.GetAsync(url);

		if (!response.IsSuccessStatusCode)
			throw new Exception($"Status Code: {response.StatusCode} - Erro ao chamar API: {url}");

		var integradores = JsonConvert.DeserializeObject<IEnumerable<Integrador>>(await response.Content.ReadAsStringAsync());

		return integradores;
	}

	public async Task<Integrador> ObterPorId(int id)
	{
		string url = $"{Endpoints.IntegradoresObterPorId.Descricao()}?id={id}";

		var response = await _httpClient.GetAsync(url);

		if (!response.IsSuccessStatusCode)
			throw new Exception($"Status Code: {response.StatusCode} - Erro ao chamar API: {url}");

		var integrador = JsonConvert.DeserializeObject<Integrador>(await response.Content.ReadAsStringAsync());

		return integrador;
	}

	public async Task Criar(Integrador item)
	{
		string url = $"{Endpoints.Integradores.Descricao()}";

		var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, mediaType: new MediaTypeHeaderValue("application/json"));

		var response = await _httpClient.PostAsync(url, content);

		if (!response.IsSuccessStatusCode)
			throw new Exception($"Status Code: {response.StatusCode} - Erro ao chamar API: {url}");
	}

	public async Task Atualizar(int id, Integrador item)
	{
		string url = $"{Endpoints.Integradores.Descricao()}";

		var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, mediaType: new MediaTypeHeaderValue("application/json"));

		var response = await _httpClient.PutAsync(url, content);

		if (!response.IsSuccessStatusCode)
			throw new Exception($"Status Code: {response.StatusCode} - Erro ao chamar API: {url}");
	}

	public async Task Remover(int id)
	{
		string url = $"{Endpoints.Integradores.Descricao()}?id={id}";

		var response = await _httpClient.DeleteAsync(url);

		if (!response.IsSuccessStatusCode)
			throw new Exception($"Status Code: {response.StatusCode} - Erro ao chamar API: {url}");
	}
}
