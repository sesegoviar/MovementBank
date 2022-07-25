using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.ApplicationCore.DTOs.Movement
{
    public class ReporteResponse
    {
        public DateTime Date { get; set; }
        public string Client { get; set; }
        public string NumberAccount { get; set; }

        public string TypeAccount {get;set;}

        public double SaldoInicial { get; set; }
        public string State { get; set; }

        public double Movimiento { get; set; }

        public double SaldoDisponible { get; set; }

    }
}
