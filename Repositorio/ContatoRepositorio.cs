using CadastroDeContatos.Data;
using CadastroDeContatos.Models;

namespace CadastroDeContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {

        private readonly BancoContext _bancoContext;

        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ContatoModel GetSingleContact(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(ValueDbId => ValueDbId.Id == id);
        }

        public List<ContatoModel> GetAll()
        {
            return _bancoContext.Contatos.ToList();
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }

        public ContatoModel UpdateContact(ContatoModel contato)
        {
            ContatoModel contatoDb = GetSingleContact(contato.Id);

            if (contatoDb == null) throw new System.Exception("Houve um erro na atualização");

            contatoDb.Name = contato.Name;
            contatoDb.Email = contato.Email;
            contatoDb.Celular = contato.Celular;

            _bancoContext.Contatos.Update(contatoDb);
            _bancoContext.SaveChanges();

            return contatoDb;

        }

        public bool Delete(int id)
        {
            ContatoModel contatoDb = GetSingleContact(id);

            if (contatoDb == null) throw new System.Exception("Houve um erro ao deletar");

            _bancoContext.Contatos.Remove(contatoDb);
            _bancoContext.SaveChanges();

            return true;

        }
    }
}
