namespace AppHeindall.Models;

public class Integrador
{
	public int Id { get; set; }
	public string IntegradorNome { get; set; }
	public string IntegradorGrupo { get; set; }
	public string IntegradorEndpoint { get; set; }
	public string IntegradorPublicKey { get; set; }
	public string IntegradorPrivateKey { get; set; }

	public int GrupoId { get; set; }
	public virtual Grupo Grupo { get; set; }
}
