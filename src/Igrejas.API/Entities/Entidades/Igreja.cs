namespace Entities.Entidades
{
    public class Igreja :
        Notificacao
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string DescricaoHistorica { get; set; }
        public byte[] Imagem { get; set; }
        public byte[] Logo { get; set; }

        public Igreja(
            Guid id, 
            string nome, 
            string telefone1, 
            string telefone2, 
            string descricaoHistorica, 
            byte[] imagem, 
            byte[] logo)
        {
            Id = id;
            Nome = nome;
            Telefone1 = telefone1;
            Telefone2 = telefone2;
            DescricaoHistorica = descricaoHistorica;
            Imagem = imagem;
            Logo = logo;
        }
    }
}
