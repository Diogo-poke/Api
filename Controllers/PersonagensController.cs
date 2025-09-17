using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RpgApi.Data;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonagensController : ControllerBase
    {
        
       private readonly DataContext _context;

        public PersonagensController(DataContext context)
        {
            
        _context = context;

        }

       
       [HttpGet("{id}")] // Buscar pelo id

       public async Task<IActionResult> GetSingle(int id)
       {
            try
            {
                Personagem p = await _context.TB_PERSONAGENS
                .FirstOrDefaultAsync(pBusca => pBusca.id);

                return Ok(p);
            }
            catch (System.Exception)
            {
                return BadRequest(ex.Message);
                
            }
              

        }

        [HttpGet("GetALL")] 
      
       public async Task<IActionResult> Get()
       {
          try
            {
               List<Personagem> lista = await_context.TB_PERSONAGENS;

               return Ok(lista);
            }
            catch (System.Exception)
            {
                return BadRequest(ex.Message);
                
            }

       }

      
      [HttpPost]
         
      public async Task<IActionResult> Add(Personagem novoPersonagem)
      {
          try
            {
             if  (novoPersonagem.PontosVida > 100)
             {
                  throw new Exception("Pontos de vida não pode ser maior do que 100");
                
             }
             await _context.TB_PERSONAGENS.AddAsync(novoPersonagem);
             await _context.SaveChangesAsync();
             return OK(novoPersonagem.id)

            }
            catch (System.Exception)
            {
               return BadRequest(ex.Message);
                
            }

      }

      [HttpPut]
        public async Task<IActionResult> Update(Personagem nonvoPersonagem)
        {
              try
            {
             if  (novoPersonagem.PontosVida > 100)
             {
                  throw new System.Exception("Pontos de vida não pode ser maior do que 100");
                
             }
            _context.TB_PERSONAGENS.Update(novoPersonagem);
            int linhasAfetadas = await _context.SaveChangesAsync();

             return OK(linhasAfetadas);

            }
            catch (System.Exception)
            {
               return BadRequest(ex.Message);
                
            }
         
        }
           
          [HttpDelete] 
            public async Task<IActionResult> Delete(int id)
         {

         try
            {
               Personagem pRemover = await _context.TB_PERSONAGENS.FirstOrDefaultAsync(p => p.id == id);
              _context.TB_PERSONAGENS.Remove(pRemover);

             int linhasAfetadas = await _context.SaveChangesAsync();

             return OK(linhasAfetadas);
            }

            catch (System.Exception)
            {
                return BadRequest(ex.Message);
                
            }



         }


    }
}