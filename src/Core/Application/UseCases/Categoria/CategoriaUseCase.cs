using FoodOrder.Domain.Entities;
using FoodOrder.Domain.Interface;

namespace FoodOrder.Application.UseCases.Produtos
{
    public class CategoriaUseCase : ICategoriaUseCase
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaUseCase(ICategoriaRepository produtoRepository)
        {
            _repository = produtoRepository;
        }

        #region CATEGORIA
        public Task<Categoria> Cadastrar(Categoria categoria)
        {
            return _repository.CadastrarAsync(categoria);
        }

        public Task<Categoria> Atualizar(Categoria categoria)
        {
            return _repository.AtualizarAsync(categoria);
        }

        public Task<Categoria> Deletar(int id)
        {
            return _repository.DeletarAsync(id);
        }

        public Task<Categoria> Consultar(string categoria)
        {
            return _repository.ConsultarAsync(categoria);
        }

        public Task<List<Categoria>> Consultar()
        {
            return _repository.ConsultarCategoriasAsync();
        }
        #endregion
    }
}
