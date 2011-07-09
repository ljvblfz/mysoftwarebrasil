//

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using Infrastructure;
using System;

namespace Infrastructure.Models
{
    public class Anuncio
    {
        #region properties

        [ScaffoldColumn(false)]
        public int anuncioId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Globalizator), ErrorMessageResourceName = "AnuncioanuncioValorHoraRequired")]
        public float anuncioValorHora { get; set; }

        [Required(ErrorMessageResourceType = typeof(Globalizator), ErrorMessageResourceName = "AnuncioanucioProficionalRequired")]
        public bool anucioProficional { get; set; }

        [StringLength(255, ErrorMessageResourceType = typeof(Globalizator), ErrorMessageResourceName = "AnuncioanuncioTituloStringLength")]
        [Required(ErrorMessageResourceType = typeof(Globalizator), ErrorMessageResourceName = "AnuncioanuncioTituloRequired")]
        public string anuncioTitulo { get; set; }

        [StringLength(255, ErrorMessageResourceType = typeof(Globalizator), ErrorMessageResourceName = "AnuncioanuncioTextoStringLength")]
        [Required(ErrorMessageResourceType = typeof(Globalizator), ErrorMessageResourceName = "AnuncioanuncioTextoRequired")]
        public string anuncioTexto { get; set; }

        [ScaffoldColumn(false)]
        [Required(ErrorMessageResourceType = typeof(Globalizator), ErrorMessageResourceName = "AnunciomembroIdRequired")]
        public int membroId { get; set; }

        [ScaffoldColumn(false)]
        public Membro membro { get; set; }

        #endregion

        #region constructors

        public Anuncio()
        {
        }

        public Anuncio(dynamic entity)
        {
            this.anuncioId = entity.anuncioId;
            this.anuncioValorHora = entity.anuncioValorHora;
            this.anucioProficional = entity.anucioProficional;
            this.anuncioTitulo = entity.anuncioTitulo;
            this.anuncioTexto = entity.anuncioTexto;
            this.membroId = entity.membroId;
            if (entity.membro != null)
                this.membro = new Membro(entity.membro);
        }

        #endregion
    }
}
