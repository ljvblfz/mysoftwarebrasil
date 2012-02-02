using System;
using System.Collections.Generic;

namespace PontoEncontro.Domain
{
    [Serializable]
    public class Perfil
    {


        public Perfil()
        {
        }

        public Perfil(Sexo Idsexo, Olho Idolho, Cabelo Idcabelo, Etinia Idetinia, Estadocivil Idestadocivil, Endereco Idendereco, int Idperfil)
        {
            this.Idsexo = Idsexo;
            this.Idolho = Idolho;
            this.Idcabelo = Idcabelo;
            this.Idetinia = Idetinia;
            this.Idestadocivil = Idestadocivil;
            this.Idendereco = Idendereco;
            this.Idperfil = Idperfil;
        }

        public virtual Sexo Idsexo { get; set; }
        public virtual Olho Idolho { get; set; }
        public virtual Cabelo Idcabelo { get; set; }
        public virtual Etinia Idetinia { get; set; }
        public virtual Estadocivil Idestadocivil { get; set; }
        public virtual Endereco Idendereco { get; set; }
        public virtual int Idperfil { get; set; }
        public virtual IList<Pessoa> PessoaList { get; set; }
        public virtual IList<Pessoa> IdperfilList { get; set; }
        public virtual IList<Interesse> InteresseList { get; set; }
        public virtual IList<Interesse> IdtipointeresseList { get; set; }
        public virtual IList<Contato> ContatoList { get; set; }

    }
}
