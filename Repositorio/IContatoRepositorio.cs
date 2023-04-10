using CadastroDeContatos.Models;

namespace CadastroDeContatos.Repositorio
{
    public interface IContatoRepositorio
    {
        List<ContatoModel> GetAll();

        ContatoModel Adicionar(ContatoModel contato);

        ContatoModel GetSingleContact(int id);

        ContatoModel UpdateContact(ContatoModel contato);

        bool Delete(int id);
    }
}
