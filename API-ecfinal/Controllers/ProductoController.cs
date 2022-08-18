using API_ecfinal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ecfinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : Controller
    {
        private readonly BDEcfinalContext BD;
        public ProductoController(BDEcfinalContext context)
        {
            BD = context;
        }

        //GET:
        [HttpGet("listar")]
        public IEnumerable<Producto> listaDeProductos()
        {
            return BD.Producto.ToList();
        }

        //Post:
        [HttpPost("crear")]
        public IActionResult CrearProducto([FromBody] Producto pProducto)
        {

            if (ModelState.IsValid)
            {
                BD.Producto.Add(pProducto);
                BD.SaveChanges();

                return Ok(pProducto);
            }

            return BadRequest(ModelState);
        }

        //Método PUT:
        [HttpPut("actualizar/{id}")]
        public IActionResult ActualizarProducto([FromBody] Producto pProducto, int id)
        {
            if (pProducto.Id != id)
            {
                return BadRequest();
            }

            BD.Entry(pProducto).State = EntityState.Modified;
            BD.SaveChanges();

            return Ok();
        }

        //Método Eliminar:
        [HttpDelete("eliminar/{id}")]
        public IActionResult EliminarProducto(int id)
        {
            var producto = BD.Producto.FirstOrDefault(u => u.Id == id);
            if (producto == null)
            {
                return NotFound();
            }
            BD.Producto.Remove(producto);
            BD.SaveChanges();

            return Ok(producto);
        }
    }
}
