using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series.Classes
{
    public class SerieRepository : IRepository<Serie>
    {
        List<Serie> listaSeries = new List<Serie>();

        public void LimparDados()
        {
            listaSeries.Clear();
        }
        public void Atualiza(int id, Serie entidade)
        {
            listaSeries[id] = entidade;
        }

        public void Exclui(int id)
        {
            //marca no item status Excluido
            listaSeries[id].Excluir();
        }

        public void Insere(Serie entidade)
        {
            listaSeries.Add(entidade);
        }

        public List<Serie> Lista()
        {
            return this.listaSeries;
        }

        public int ProximoId()
        {
            return listaSeries.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return listaSeries[id];
        }

    }
}