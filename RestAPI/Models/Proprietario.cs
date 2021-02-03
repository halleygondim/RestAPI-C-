
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RestAPI.Models
{
    [Table("PROPRIETARIOS")]
    public class Proprietario { 

        [Key()]
        [Column("PRO_IDEN")]
        public long? id { get; set; }
   
        [Column("PRO_NOME")]
        public string nome { get; set; }

        [Column("PRO_CPF")]
        public string cpf { get; set; }

        //NÃO APARECER NA REQUISIÇÃO
        [JsonIgnore]
        public virtual List<Veiculo> veiculos { get; set; }




    }
}