using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteApi.Data;
using TesteApi.Models;

namespace TesteApi.Controllers
{
    [ApiController]
    [Route("v1/produtos")]
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Produto>>> Get([FromServices] DataContext context)
        {
            var produtos = await context.Produtos.Include(x => x.Categoria).ToListAsync();
            return produtos;
        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<ActionResult<Produto>> GetById([FromServices] DataContext context, int id)
        {
            var produto = await context.Produtos.Include(x => x.Categoria)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);
            return produto;
        }

        [HttpPost]
        [Route("")]

        public async Task<ActionResult<Produto>> Post(
            [FromServices] DataContext context,
            [FromBody] Produto produto)
        {
            if (ModelState.IsValid)
            {
                context.Produtos.Add(produto);
                await context.SaveChangesAsync();
                return produto;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        
    }
}