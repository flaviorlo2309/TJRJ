using Domain.Dto;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interfaces
{
    public interface ILivroAssuntoRepository
    {
        Task<bool> AddDadosLivroAssunto(int codLivro, int codAssunto);
        Task<LivroAssunto> GetAssuntoByIdLivro(int codLivro);
        Task<bool> UpdateBYIdLivro(LivroAssunto dados);
    }
}
