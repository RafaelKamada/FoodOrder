using Domain.Entities;

namespace Domain.Ports
{
    public interface ISacolaRepository
    {
        Task<Sacola> Cadastrar(Sacola sacola);
        Task<Sacola> ResgatarUltimaSacola();
    }
}

