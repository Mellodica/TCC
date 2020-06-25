using ControleFinanceiro.Data;
using ControleFinanceiro.Models.Infra;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ControleFinanceiro.Servico.Erros;

namespace ControleFinanceiro.Servico
{
    public class InfraServicos
    {
        private ControlePessoalContext _context;

        public InfraServicos(ControlePessoalContext context)
        {
            _context = context;
        }

        public IQueryable<UsuarioApp> PegarUsuarioPorNome()
        {
            return _context.Usuarios.OrderBy(b => b.UserName);
        }

        public async Task<UsuarioApp> PegarUsuarioPorId(int id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(user => user.UsuarioId == id);
        }

        public async Task UpdateAsync(UsuarioApp user)
        {
            bool hasAny = await _context.Usuarios.AnyAsync(x => x.UsuarioId == user.UsuarioId);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(user);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public async Task<UsuarioApp> DeletarUsuarioPorId(int id)
        {
            UsuarioApp usuario = await PegarUsuarioPorId(id);
            _context.Users.Remove(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }
    }
}
