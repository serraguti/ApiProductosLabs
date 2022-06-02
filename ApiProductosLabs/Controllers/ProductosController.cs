using ApiProductosLabs.Models;
using ApiProductosLabs.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProductosLabs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private RepositoryProductos repo;

        public ProductosController(RepositoryProductos repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Producto>> GetProductos()
        {
            return this.repo.GetProductos();
        }

        [HttpGet("{id}")]
        public ActionResult<Producto> FindProducto(int id)
        {
            return this.repo.FindProducto(id);
        }

        [HttpPost]
        public async Task<ActionResult> AddProducto(Producto producto)
        {
            await this.repo.AddProducto(producto.Nombre, producto.Descripcion
                , producto.Precio, producto.Imagen);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProducto(int id)
        {
            await this.repo.DeleteProducto(id);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProducto(Producto producto)
        {
            await this.repo.UpdateProducto(producto.IdProducto, producto.Nombre
                , producto.Descripcion, producto.Precio, producto.Imagen);
            return Ok();
        }
    }
}
