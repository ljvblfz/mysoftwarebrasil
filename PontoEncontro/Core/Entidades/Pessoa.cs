using System;
using System.Collections.Generic;

namespace Core
{
    [Serializable]
    public class Pessoa
    {


        public Pessoa()
        {
        }

        public Pessoa(Sexo Sexoid, Olho Olhosid, Cabelo Cabelosid, Etinia Etiniaid, Perfil Perfilid, Estadocivil Estadocivilid, Endereco Enderecoid, int Pessoaid, string Pessoaname, DateTime Pessoanascimento, string Pessoaprofissao, string Pessoaemail, string Pessoamsn)
        {
            this.Sexoid = Sexoid;
            this.Olhosid = Olhosid;
            this.Cabelosid = Cabelosid;
            this.Etiniaid = Etiniaid;
            this.Perfilid = Perfilid;
            this.Estadocivilid = Estadocivilid;
            this.Enderecoid = Enderecoid;
            this.Pessoaid = Pessoaid;
            this.Pessoaname = Pessoaname;
            this.Pessoanascimento = Pessoanascimento;
            this.Pessoaprofissao = Pessoaprofissao;
            this.Pessoaemail = Pessoaemail;
            this.Pessoamsn = Pessoamsn;
        }

        public virtual Sexo Sexoid { get; set; }
        public virtual Olho Olhosid { get; set; }
        public virtual Cabelo Cabelosid { get; set; }
        public virtual Etinia Etiniaid { get; set; }
        public virtual Perfil Perfilid { get; set; }
        public virtual Estadocivil Estadocivilid { get; set; }
        public virtual Endereco Enderecoid { get; set; }
        public virtual int Pessoaid { get; set; }
        public virtual string Pessoaname { get; set; }
        public virtual DateTime Pessoanascimento { get; set; }
        public virtual string Pessoaprofissao { get; set; }
        public virtual string Pessoaemail { get; set; }
        public virtual string Pessoamsn { get; set; }
        public virtual IList<Membro> MembroList { get; set; }
        public virtual IList<Inretessepessoa> InretessepessoaList { get; set; }

    }
}
