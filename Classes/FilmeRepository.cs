using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series.Classes
{
    public class FilmeRepository : IRepository<Filme>
    {

        //observação como esta implementando uma interface nao e possivel trocar o nome dos metodos aqui na classe 
        //base de dados em memoria
        List<Filme> ListaFilmes = new List<Filme>();
        public void Atualiza(int id, Filme entidade)
        {
            if (id >= 0)
                this.ListaFilmes[id] = entidade;
            else
                Console.WriteLine("Erro ao Atualizar Dados");
        }

        public void Exclui(int id)
        {
            this.ListaFilmes[id].Excluir();
        }

        public void Insere(Filme entidade)
        {
            if (entidade != null)
                this.ListaFilmes.Add(entidade);

            //Console.WriteLine(entidade);
        }
        public void LimparDados()
        {
            this.ListaFilmes.Clear();
        }
        public List<Filme> Lista()
        {
            return this.ListaFilmes;
        }

        public int ProximoId()
        {
            return this.ListaFilmes.Count;
        }

        public Filme RetornaPorId(int id)
        {
            return this.ListaFilmes[id];
        }
    }
}