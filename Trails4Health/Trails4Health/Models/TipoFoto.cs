﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    //UPDATE BASE DE DADOS!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    public class TipoFoto
    {
        public int TipoFotoId { get; set; }

        [Required(ErrorMessage = "Please enter Trail Name")]
        [StringLength(maximumLength: 60, MinimumLength = 3)]
        public string Nome { get; set; }

        
        [StringLength(maximumLength: 1000, MinimumLength = 5)]
        public string Descricao { get; set; }

        public int FotoId { get; set; }
        public Foto Foto { get; set; }


    }
}

