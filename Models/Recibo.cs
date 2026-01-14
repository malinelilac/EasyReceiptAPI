using System;

namespace EasyReceiptAPI.Models;

public class Recibo
{
    public string Cliente { get; set; } = string.Empty;
    public string Servico { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public DateTime Data { get; set; } = DateTime.Now;
}