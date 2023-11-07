using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RH.Data
{
    public class Contexto
    {
        public string Conexion { get; }

        public Contexto(string valor){
            Conexion =valor;
        }
    }
}