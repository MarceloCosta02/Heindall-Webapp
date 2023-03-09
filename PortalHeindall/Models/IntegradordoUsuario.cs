namespace PortalHeindall.Models
{
	public class IntegradordoUsuario
	{
		public int Id { get; set; }
		public int UsuarioId { get; set; }
		public int IntegradorId { get; set; }
		public Usuario Usuario { get; set; }
		public Integrador Integrador { get; set; }
	}
}
