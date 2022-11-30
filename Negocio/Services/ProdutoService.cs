using Persistencia.Data;
using Entidades.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Negocio.Services.Exceptions;
using System.Threading.Tasks;

namespace Negocio.Services
{
    public class ProdutoService
    {
        private readonly SalesWebMvcContext _context;

        public ProdutoService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Produto>> FindAllAsync() 
        {
            return await _context.Produto.ToListAsync();
        }

        public async Task InsertAsync(Produto obj) 
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Produto> FindByIdAsync(int id) 
        {
            return await _context.Produto.Include(obj => obj.Categoria).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id) 
        {
            try
            {
                var obj = await _context.Produto.FindAsync(id);
                _context.Produto.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException("Can't delete seller because he/she has sales - " + e.Message);
            }
            
        }

        public async Task UpdateAsync(Produto obj) 
        {
            bool hasAny = await _context.Produto.AnyAsync(x => x.Id == obj.Id);

            if (!hasAny) 
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e) 
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
