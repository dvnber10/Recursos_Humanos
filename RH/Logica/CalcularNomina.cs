using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RH.Logica
{
    public class CalcularNomina
    {
        public CalcularNomina (){

        }
        public decimal? calcular(int? cantidadH , decimal? aumento,decimal? descuento){
            decimal? total = cantidadH * 8000 + aumento - descuento;
            return total;
        }
    }
}