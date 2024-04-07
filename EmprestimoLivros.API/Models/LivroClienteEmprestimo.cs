﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmprestimoLivros.API.Models;

[Table("Livro_Cliente_Emprestimo")]
public partial class LivroClienteEmprestimo
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    public int LceIdCliente { get; set; }

    public int LceIdLivro { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LceDataEmprestimo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LceDataEntrega { get; set; }

    [StringLength(10)]
    public string LceEntregue { get; set; }

    [ForeignKey("LceIdCliente")]
    [InverseProperty("LivroClienteEmprestimos")]
    public virtual Cliente LceIdClienteNavigation { get; set; }

    [ForeignKey("LceIdLivro")]
    [InverseProperty("LivroClienteEmprestimos")]
    public virtual Livro LceIdLivroNavigation { get; set; }
}