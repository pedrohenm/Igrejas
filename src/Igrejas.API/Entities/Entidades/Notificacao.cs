using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entidades
{
    public class Notificacao
    {
        public Notificacao()
        {
            Notificacoes = new List<Notificacao>();
        }

        [NotMapped]
        public string NomePropriedade { get; set; }

        [NotMapped]
        public string MensagemPropriedade { get; set; }

        [NotMapped]
        public List<Notificacao> Notificacoes { get; set; }

        public bool ValidaPropriedadeString(
            string valor, 
            string nomePropriedade)
        {
            if(string.IsNullOrWhiteSpace(valor) ||
                string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notificacoes.Add(new Notificacao
                {
                    MensagemPropriedade = "Campo obrigatório",
                    NomePropriedade = nomePropriedade
                });

                return false;
            }

            return true;
        }

        public bool ValidaPropriedadeInt(
            int valor,
            string nomePropriedade)
        {
            if (valor < 0 ||
                string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notificacoes.Add(new Notificacao
                {
                    MensagemPropriedade = "Campo obrigatório",
                    NomePropriedade = nomePropriedade
                });

                return false;
            }

            return true;
        }
    }
}
