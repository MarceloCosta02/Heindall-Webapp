namespace AppHeindall.Models;

public class Integrador
{
	public int Id { get; set; }
	public int IntegradorId { get; set; }
	public string IntegradorNome { get; set; }
	public string GrupoUser { get; set; }
	public string GrupoPassword { get; set; }
	public int GrupoPort { get; set; }
	public string PublicKey { get; set; }
	public string PrivateKey { get; set; }

	public int GrupoId { get; set; }
	public virtual Grupo Grupo { get; set; }
	public virtual ICollection<Usuario> Usuarios { get; set; }
}
