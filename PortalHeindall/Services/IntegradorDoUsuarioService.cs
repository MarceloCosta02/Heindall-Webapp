using AppHeindall.Enums;
using AppHeindall.Extensions;
using AppHeindall.Interfaces;
using AppHeindall.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace AppHeindall.Services;

public class IntegradorDoUsuarioService : IIntegradorDoUsuarioService
{
	protected HttpClient _httpClient;

	public IntegradorDoUsuarioService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public async Task<IEnumerable<IntegradorDoUsuario>> Obter()
	{
		string url = $"{Endpoints.IntegradoresDoUsuario.Descricao()}";

		var response = await _httpClient.GetAsync(url);

		if (!response.IsSuccessStatusCode)
			throw new Exception($"Status Code: {response.StatusCode} - Erro ao chamar API: {url}");

		var integradoresDoUsuario = JsonConvert.DeserializeObject<IEnumerable<IntegradorDoUsuario>>(await response.Content.ReadAsStringAsync());

		return integradoresDoUsuario;
	}

	public async Task<IntegradorDoUsuario> ObterPorId(int id)
	{
		string url = $"{Endpoints.IntegradoresDoUsuarioObterPorId.Descricao()}?id={id}";

		var response = await _httpClient.GetAsync(url);

		if (!response.IsSuccessStatusCode)
			throw new Exception($"Status Code: {response.StatusCode} - Erro ao chamar API: {url}");

		var integradoresDoUsuario = JsonConvert.DeserializeObject<IntegradorDoUsuario>(await response.Content.ReadAsStringAsync());

		return integradoresDoUsuario;
	}

	public async Task Criar(IntegradorDoUsuario item)
	{
		string url = $"{Endpoints.IntegradoresDoUsuario.Descricao()}";

		var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, mediaType: new MediaTypeHeaderValue("application/json"));

		var response = await _httpClient.PostAsync(url, content);

		if (!response.IsSuccessStatusCode)
			throw new Exception($"Status Code: {response.StatusCode} - Erro ao chamar API: {url}");
	}

	public async Task Atualizar(int id, IntegradorDoUsuario item)
	{
		string url = $"{Endpoints.IntegradoresDoUsuario.Descricao()}?id={id}";

		var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, mediaType: new MediaTypeHeaderValue("application/json"));

		var response = await _httpClient.PutAsync(url, content);

		if (!response.IsSuccessStatusCode)
			throw new Exception($"Status Code: {response.StatusCode} - Erro ao chamar API: {url}");
	}

	public async Task Remover(int id)
	{
		string url = $"{Endpoints.IntegradoresDoUsuario.Descricao()}?id={id}";

		var response = await _httpClient.DeleteAsync(url);

		if (!response.IsSuccessStatusCode)
			throw new Exception($"Status Code: {response.StatusCode} - Erro ao chamar API: {url}");
	}
}
