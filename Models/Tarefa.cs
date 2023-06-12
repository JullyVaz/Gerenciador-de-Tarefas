using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiTarefas.Models
{
    
    public class Tarefa
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo 'Tarefa a realizar' é obrigatório.")]
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo 'Data' é obrigatório.")]
        [DataType(DataType.Date, ErrorMessage = "O campo 'Data' deve estar no formato 'yyyy-MM-dd'.")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O campo 'Status' é obrigatório.")]
        [EnumDataType(typeof(EnumStatusTarefa), ErrorMessage = "O campo 'Status' deve ser um valor válido.")]
        public EnumStatusTarefa Status { get; set; }
    }
}
    