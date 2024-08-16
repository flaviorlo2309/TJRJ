using Domain.Dto;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interfaces
{
    public interface ITpVendaLivroRepository
    {
        Task<IEnumerable<LivroTpVenda>> GetAllVendas();        
        Task<LivroTpVenda> GetVendasById(int id);
        Task<IEnumerable<LivroTpVenda>> GetTpVendasByLivroId(int id);
        Task<bool> UpDateVendas(LivroTpVenda dados);
        Task<bool> AddDadosVendas(LivroTpVendaDto dados);
        Task<bool> DeleteVendasId(int id);

    }
}
