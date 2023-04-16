using AppHeindall.Enums;
using AppHeindall.Extensions;
using AppHeindall.Interfaces;
using AppHeindall.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace AppHeindall.Services;

public class UsuarioService : IUsuarioService
{
	protected HttpClient _httpClient;

	public UsuarioService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

    public async Task<IEnumerable<Usuario>> Obter()
    {
        string url = $"{Endpoints.Usuarios.Descricao()}";

        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            throw new Exception($"Status Code: {response.StatusCode} - Erro ao chamar API: {url}");

        var usuarios = JsonConvert.DeserializeObject<IEnumerable<Usuario>>(await response.Content.ReadAsStringAsync());

        return usuarios;
    }

    public async Task<Usuario> ObterPorId(int id)
    {
        string url = $"{Endpoints.UsuariosObterPorId.Descricao()}?id={id}";

        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            throw new Exception($"Status Code: {response.StatusCode} - Erro ao chamar API: {url}");

        var usuario = JsonConvert.DeserializeObject<Usuario>(await response.Content.ReadAsStringAsync());

        return usuario;
    }

    public async Task Criar(Usuario item)
    {
        string url = $"{Endpoints.Usuarios.Descricao()}";

        var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, mediaType: new MediaTypeHeaderValue("application/json"));

        var response = await _httpClient.PostAsync(url, content);

        if (!response.IsSuccessStatusCode)
            throw new Exception($"Status Code: {response.StatusCode} - Erro ao chamar API: {url}");
    }

    public async Task Atualizar(int id, Usuario item)
    {
        string url = $"{Endpoints.Usuarios.Descricao()}";

        var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, mediaType: new MediaTypeHeaderValue("application/json"));

        var response = await _httpClient.PutAsync(url, content);

        if (!response.IsSuccessStatusCode)
            throw new Exception($"Status Code: {response.StatusCode} - Erro ao chamar API: {url}");
    }

    public async Task Remover(int id)
    {
        string url = $"{Endpoints.Usuarios.Descricao()}?id={id}";

        var response = await _httpClient.DeleteAsync(url);

        if (!response.IsSuccessStatusCode)
            throw new Exception($"Status Code: {response.StatusCode} - Erro ao chamar API: {url}");
    }
}
