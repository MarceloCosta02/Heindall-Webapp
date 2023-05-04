using AppHeindall.Enums;
using AppHeindall.Extensions;
using AppHeindall.Interfaces;
using AppHeindall.Models;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using System.Net.Http.Headers;
using AppHeindall.Models.Requests;

namespace AppHeindall.Services;

public class ImportacaoService : IImportacaoService
{
	protected HttpClient _httpClient;

	public ImportacaoService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public async Task ImportacaoRextur()
	{
		string url = $"{Endpoints.ImportacaoRextur.Descricao()}";
		var dateNow = DateTime.Now.ToString("yyyyMMdd");

		var content = new StringContent(JsonConvert.SerializeObject(new ImportacaoRexturRequest(dateNow)), Encoding.UTF8, mediaType: new MediaTypeHeaderValue("application/json"));

		var response = await _httpClient.PostAsync(url, content);

		if (!response.IsSuccessStatusCode)
			throw new Exception($"Status Code: {response.StatusCode} - Erro ao chamar API: {url}");
	}	
}
