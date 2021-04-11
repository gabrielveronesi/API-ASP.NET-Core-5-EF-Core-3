using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteApi.Data;
using TesteApi.Models;

namespace TesteApi.Controllers
{
    [ApiController]
    [Route("v1/categorias")]
    public class CategoriaController : ControllerBase
    {
        [HttpGet]
        [Route("/listar-categorias")]

        public async Task<ActionResult<List<Categoria>>> Get([FromServices] DataContext context)
        {
            //não fiz a injeção
            var categorias = await context.Categorias.ToListAsync();
            return categorias;
        }

        [HttpPost]
        [Route("/nova-categoria")]

        public async Task<ActionResult<Categoria>> Post(
            [FromServices] DataContext context,
            [FromBody] Categoria categoria)
            {
                if (ModelState.IsValid)
                {
                    context.Categorias.Add(categoria);
                    await context.SaveChangesAsync();
                    return categoria;
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
        
    }
}