using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArmasController : ControllerBase
    {
        
         private readonly DataContext _context;

        public ArmasController(DataContext context)
        {
            
            _context = context;

        }
        
        private static List<Arma> Armas = new List<Arma>()
        {
        new Arma() { Id = 1, Nome = "Adaga", Dano = 25}, 
        new Arma() { Id = 2, Nome = "Cajado", Dano = 20},
        new Arma() { Id = 3, Nome = "Espada", Dano = 15},
        new Arma() { Id = 4, Nome = "Soco", Dano = 5},
        new Arma() { Id = 5, Nome = "Chute", Dano = 5},
        new Arma() { Id = 6, Nome = "Machado", Dano = 50},
        new Arma() { Id = 7, Nome = "Arco", Dano = 10},    
        };
        
         [HttpGet("{id}")] // Buscar pelo id
       public async Task<IActionResult> GetSingle(int id)
       {
            try
            {
                Arma a = await _context.TB_ARMAS.FirstOrDefaultAsync(aBusca => aBusca.Id == id);
                return Ok(a);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
                
            }
        }

        [HttpGet("GetAll")]       
       public async Task<IActionResult> Get()
       {
          try
            {
               List<Arma> lista = await _context.TB_ARMAS.ToListAsync();

               return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
                
            }

       }

      
     [HttpPost]
         
      public async Task<IActionResult> Add(Armas novaArma)
      {
          try
            {
             if  (novaArma.Dano> 70)
             {
                  throw new Exception("o Dano não pode ser maior quer 70");
                
             }
             await _context.TB_ARMAS.AddAsync(novaArma);
             await _context.SaveChangesAsync();
             return Ok(novaArma.Id);

            }
            catch (System.Exception ex)
            {
               return BadRequest(ex.Message);
                
            }

      }

      [HttpPut]
        public async Task<IActionResult> Update(Armas novaArma)
        {
              try
            {
             if  (novaArma.Dano > 70)
             {
                  throw new System.Exception("O Dano não pode ser maior que 70");
                
             }
            _context.TB_ARMAS.Update(novaArma);
            int linhasAfetadas = await _context.SaveChangesAsync();

             return Ok(linhasAfetadas);

            }
            catch (System.Exception ex)
            {
               return BadRequest(ex.Message);
                
            }
         
        }
           
          [HttpDelete] 
            public async Task<IActionResult> Delete(int id)
         {

         try
            {
               Armas aRemover = await _context.TB_PERSONAGENS.FirstOrDefaultAsync(a =>a.Id == id);
              _context.TB_PERSONAGENS.Remove(aRemover);

             int linhasAfetadas = await _context.SaveChangesAsync();

             return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
                
            }
         }




        }
}