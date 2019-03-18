using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrganizaTrilha.Views
{
    public class Palestras
    {
        private string nome;
        private int tempo;
        private bool alocado;
        TimeSpan hr_inicio;

        public Palestras(int tempo, string nome, TimeSpan hr_inicio)
        {
            this.nome = nome;
            this.tempo = tempo;
            this.alocado = false;
            this.hr_inicio = hr_inicio;

        }
        public int Tempo { get => tempo; set => tempo = value; }
        public string Nome { get => nome; set => nome = value; }
        public bool Alocada { get => alocado; set => alocado = value; }
        public TimeSpan Hr_inicio { get => hr_inicio; set => hr_inicio = value; }

    }
}