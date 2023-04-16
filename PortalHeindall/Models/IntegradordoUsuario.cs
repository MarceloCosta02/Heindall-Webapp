namespace AppHeindall.Models;

public class IntegradorDoUsuario
{
	public int Id { get; set; }
	public int UsuarioId { get; set; }
	public int IntegradorId { get; set; }
	public Usuario Usuario { get; set; }
	public Integrador Integrador { get; set; }
}
