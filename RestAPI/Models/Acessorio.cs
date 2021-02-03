
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI.Models
{
    //NOME DA TABELA NO BANCO
    [Table("ACESSORIOS")]
    public class Acessorio {

        //INFORMAR QUE É CHAVE PRIMÁRIA
        [Key()]
        [Column("ACE_IDEN")]
        public long? id { get; set; }
   
        [Column("ACE_NOME")]
        public string nome { get; set; }

        

      
    }
}