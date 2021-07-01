using System;

namespace DIO.Series.Classes
{
    public class Filme : EntidadeBase
    {

        private Genero Genero { get; set; }

        private string Titulo { get; set; }
        private string Descricao { get; set; }

        private int Ano { get; set; }
        private bool excluido;

        //

        public Filme(int id, string titulo, string descricao, int ano, Genero genero)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.excluido = false;
            this.Genero = genero;
        }

        public bool Excluir()
        {
            return this.excluido = true;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public bool retornaExecluido()
        {
            return this.excluido;
        }
        public int retornaId()
        {
            return this.Id;
        }



        public override string ToString()
        {
            // Environment.NewLine; para quebra linha
            string retorno = "";
            retorno += "Genero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Inicio: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.excluido + Environment.NewLine;

            return retorno;
        }

    }
}