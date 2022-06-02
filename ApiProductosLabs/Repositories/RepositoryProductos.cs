using ApiProductosLabs.Data;
using ApiProductosLabs.Models;

namespace ApiProductosLabs.Repositories
{
    public class RepositoryProductos
    {
        private ProductosContext context;

        public RepositoryProductos(ProductosContext context)
        {
            this.context = context;
        }

        public List<Producto> GetProductos()
        {
            return this.context.Productos.ToList();
        }

        public Producto FindProducto(int id)
        {
            return this.context.Productos.FirstOrDefault(x => x.IdProducto == id);
        }

        public int GetMaxIdProducto()
        {
            if (this.context.Productos.Count() == 0)
            {
                return 1;
            }
            else
            {
                return this.context.Productos.Max(x => x.IdProducto) + 1;
            }
        }
        
        public async Task AddProducto(string nombre, string descripcion, int precio, string imagen)
        {
            Producto producto = new Producto()
            {
                Nombre = nombre,
                IdProducto = this.GetMaxIdProducto(),
                Descripcion = descripcion,
                Precio = precio,
                Imagen = imagen
            };
            await this.context.Productos.AddAsync(producto);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateProducto(int id, string nombre, string descripcion
            , int precio, string imagen)
        {
            Producto producto = this.FindProducto(id);
            producto.Nombre = nombre;
            producto.Descripcion = descripcion;
            producto.Precio = precio;
            producto.Imagen = imagen;
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteProducto(int id)
        {
            Producto producto = this.FindProducto(id);
            this.context.Productos.Remove(producto);
            await this.context.SaveChangesAsync();
        }
    }
}
