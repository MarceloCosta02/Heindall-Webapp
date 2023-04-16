using AppHeindall.Enums;
using AppHeindall.Extensions;
using AppHeindall.Interfaces;
using AppHeindall.Models;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using System.Net.Http.Headers;

namespace AppHeindall.Services;

public class GrupoService : IGrupoService
{
	protected HttpClient _httpClient;

	public GrupoService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public async Task<IEnumerable<Grupo>> Obter()
	{
		string url = $"{Endpoints.Grupos.Descricao()}";

		var response = await _httpClient.GetAsync(url);

		if (!response.IsSuccessStatusCode)
            throw new Exception($"Status Code: {response.StatusCode} - Erro ao chamar API: {url}");

        var grupos = JsonConvert.DeserializeObject<IEnumerable<Grupo>>(await response.Content.ReadAsStringAsync());

		return grupos;
	}

	public async Task<Grupo> ObterPorId(int id)
	{
		string url = $"{Endpoints.GruposObterPorId.Descricao()}?id={id}";

		var response = await _httpClient.GetAsync(url);

		if (!response.IsSuccessStatusCode)
			throw new Exception($"Status Code: {response.StatusCode} - Erro ao chamar API: {url}");

		var grupo = JsonConvert.DeserializeObject<Grupo>(await response.Content.ReadAsStringAsync());

		return grupo;
	}

	public async Task Criar(Grupo item)
	{
		string url = $"{Endpoints.Grupos.Descricao()}";

        var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, mediaType: new MediaTypeHeaderValue("application/json"));

        var response = await _httpClient.PostAsync(url, content);

        if (!response.IsSuccessStatusCode)
            throw new Exception($"Status Code: {response.StatusCode} - Erro ao chamar API: {url}");
    }

	public async Task Atualizar(int id, Grupo item)
	{
        string url = $"{Endpoints.Grupos.Descricao()}";

        var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, mediaType: new MediaTypeHeaderValue("application/json"));

        var response = await _httpClient.PutAsync(url, content);

        if (!response.IsSuccessStatusCode)
            throw new Exception($"Status Code: {response.StatusCode} - Erro ao chamar API: {url}");
    }

	public async Task Remover(int id)
	{
        string url = $"{Endpoints.Grupos.Descricao()}?id={id}";

        var response = await _httpClient.DeleteAsync(url);

        if (!response.IsSuccessStatusCode)
            throw new Exception($"Status Code: {response.StatusCode} - Erro ao chamar API: {url}");
    }
}
