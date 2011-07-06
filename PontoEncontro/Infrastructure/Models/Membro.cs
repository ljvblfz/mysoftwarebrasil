namespace Infrastructure.Models
{
	// data object class Membro generated from Membro
	// alexis [2011-06-13] Created

	using System;

	public partial class Membro 
	{

        public Pessoa pessoaId { get; set; }

        public int membroId { get; set; }

        public string membroNickName { get; set; }

        public DateTime membroUltimoLogin { get; set; }

        public string membroSenha { get; set; }

	} // Membro
}

