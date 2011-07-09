 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using Infrastructure;
using System;
using System.ComponentModel;
 
namespace Infrastructure.Models
{
    public class Membro                                                                                              
    {
        #region properties

        [ScaffoldColumn(false)]
		[Required(ErrorMessageResourceType = typeof(Globalizator), ErrorMessageResourceName = "MembropessoaIdRequired")]
		public int pessoaId { get; set; }
 
		public Pessoa pessoa { get; set; }
 
		[ScaffoldColumn(false)]
		public int membroId { get; set; }
 
		[DisplayName("Login")]        [StringLength(255, ErrorMessageResourceType = typeof(Globalizator), ErrorMessageResourceName = "MembromembroNickNameStringLength")]		[Required(ErrorMessageResourceType = typeof(Globalizator), ErrorMessageResourceName = "MembromembroNickNameRequired")]
		public string membroNickName { get; set; }
 
        [ScaffoldColumn(false)]
		[Required(ErrorMessageResourceType = typeof(Globalizator), ErrorMessageResourceName = "MembromembroUltimoLoginRequired")]
		public DateTime membroUltimoLogin { get; set; }
        
        [DisplayName("Senha")]
        [DataType(DataType.Password)]
		[StringLength(50, ErrorMessageResourceType = typeof(Globalizator), ErrorMessageResourceName = "MembromembroSenhaStringLength")]		[Required(ErrorMessageResourceType = typeof(Globalizator), ErrorMessageResourceName = "MembromembroSenhaRequired")]
		public string membroSenha { get; set; }
 
        #endregion
 
        #region constructors
 
		public Membro()
		{
		}
		
		public Membro(dynamic entity)
		{
		this.pessoaId = entity.pessoaId;
		if (entity.pessoa != null)
			this.pessoa = new Pessoa(entity.pessoa);
		this.membroId = entity.membroId;
		this.membroNickName = entity.membroNickName;
		this.membroUltimoLogin = entity.membroUltimoLogin;
		this.membroSenha = entity.membroSenha;
		}
	
		#endregion
	}
}


