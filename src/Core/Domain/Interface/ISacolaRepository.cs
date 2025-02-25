using FoodOrder.Domain.Entities;

namespace FoodOrder.Domain.Ports
{
    public interface ISacolaRepository
    {
        Task<Sacola> Cadastrar(Sacola sacola);
        Task<Sacola> ResgatarUltimaSacola();
    }
}

