
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI.Models
{
    //NOME DA TABELA NO BANCO
    [Table("ACESSORIOS_VEICULOS")]
    public class AcessorioVeiculo {

        //INFORMAR QUE É CHAVE PRIMÁRIA
        [Key()]
        [Column("AVE_IDEN")]
        public long? id { get; set; }

        [ForeignKey("AVE_ACE_IDEN")]
        public virtual Acessorio acessorio { get; set; }

        //RELACIONAMENTO UM 
        //VIRTUAL = LAZY LOAD
        [ForeignKey("AVE_VEI_IDEN")]
        public virtual Veiculo veiculo { get; set; }

      
    }
}