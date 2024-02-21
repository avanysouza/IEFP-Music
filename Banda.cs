using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEFPMusic
{
    internal class Banda
    {

        public string Nome;
        private List<Musica> musicas = new List<Musica>();

        public string NomeBanda()
        {
            return Nome;
        }

        public bool adicionarMusica(Musica musica)
        {
            bool valor = false;

            if (!musicas.Contains(musica))
            {
                valor = true;
                musicas.Add(musica);
            }
            else
            {
                valor = false;
            }

            return valor;
        }

       



    }
}
