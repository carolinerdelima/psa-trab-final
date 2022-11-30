using Entidades.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entidades.Models
{
    public class ProdutosRegistro
    {
        public int Id { get; set; }

        public DateTime Date  { get; set; }
        
        public ProdutoStatus Status { get; set; }
        
        public Produto Produto { get; set; }

        public ProdutosRegistro() { }
        public ProdutosRegistro(int id, DateTime date, double amount, ProdutoStatus status, Produto produto)
        {
            Id = id;
            Date = date;
            Status = status;
            Produto = produto;
        }
    }
}
