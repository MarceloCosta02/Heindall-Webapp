namespace AppHeindall.Models.Requests;

public class ImportacaoRexturRequest
{
	public string RequestDate { get; private set; }

	public ImportacaoRexturRequest(string requestDate)
	{
		RequestDate = requestDate;

	}
}
