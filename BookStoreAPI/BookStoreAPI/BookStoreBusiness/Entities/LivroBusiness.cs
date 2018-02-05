using BookStoreAPI.BookStoreBusiness.Interfaces;
using BookStoreAPI.Results.DBResults;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreAPI.BookStoreBusiness.Entities
{
    internal class LivroBusiness : DBBusiness<Livro>, ILivroBusinesss
    {
        private static LivroBusiness _instance;

        private LivroBusiness() { }

        public static LivroBusiness instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LivroBusiness();
                }
                return _instance;
            }
        }

        public override async Task<Livro> ListById(string query, params object[] args)
        {
            Livro result = await base.ListById(query, args);
            //result.EDITORA = await EditoraBusiness.instance.ListEditoraByParam(Querys.SELECT_EDITORA_BY_AUTOR, result.ID);
            //result.AUTORES = await LivroBusiness.instance.ListLivroByParam(Querys.SELECT_LIVRO_BY_AUTOR, result.ID);
            return result;
        }

        public Task<List<Livro>> ListLivroByParam(string query, params object[] args)
        {
            return ListAll(query, args);
        }
    }
}