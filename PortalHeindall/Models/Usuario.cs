namespace AppHeindall.Models;

public class Usuario
{
	public int Id { get; set; }
	public string Cnpj { get; set; }
	public string Nivel { get; set; }
	public string NomeEmpresa { get; set; }
	public string HostBd { get; set; }
	public string UserBd { get; set; }
	public string SenhaBd { get; set; }
	public string PortaBd { get; set; }
	public string SchemaBd { get; set; }

	public virtual ICollection<Integrador> Integradores { get; set; }
}
