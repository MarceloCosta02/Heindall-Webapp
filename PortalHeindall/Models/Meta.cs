using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppHeindall.Models
{
	public class Meta
	{
			public int Id { get; set; }

			[Display(Name = "Prioridade")]
			[StringLength(50)]
			public string Prioridade { get; set; }

			[Display(Name = "Projeto")]
			public string Projeto { get; set; }

			[Column(TypeName = "Date")]
			[Display(Name = "Data Inicial")]
			public DateTime Start { get; set; }

			[Column(TypeName = "Date")]
			[Display(Name = "Data Final")]
			public DateTime Finish { get; set; }

			[Display(Name = "Demanda")]
			[StringLength(150, MinimumLength = 3, ErrorMessage = "O campo Demanda deve ter entre 3 e 150 caracteres.")]
			public string Demanda { get; set; }

			[Display(Name = "Pendência")]
			[StringLength(150, MinimumLength = 3, ErrorMessage = "O campo Pendência deve ter entre 3 e 150 caracteres.")]
			public string Pendencia { get; set; }
		


	}
}
