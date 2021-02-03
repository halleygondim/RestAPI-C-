
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI.Models
{
    //NOME DA TABELA NO BANCO
    [Table("VEICULOS")]
    public class Veiculo {

        //INFORMAR QUE É CHAVE PRIMÁRIA
        [Key()]
        [Column("VEI_IDEN")]
        public long? id { get; set; }
   
        [Column("VEI_PLACA")]
        public string placa { get; set; }

        //RELACIONAMENTO UM 
        //VIRTUAL = LAZY LOAD
        [ForeignKey("VEI_PRO_IDEN")]
        public virtual Proprietario proprietario { get; set; }

        

    }
}