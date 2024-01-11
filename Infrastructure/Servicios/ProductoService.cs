using Microsoft.EntityFrameworkCore;
using pruebaTecnicaEdynamicsLog.Domain.DTOs;
using pruebaTecnicaEdynamicsLog.Domain.Entities.Productos;
using pruebaTecnicaEdynamicsLog.Domain.Interfaces;

namespace pruebaTecnicaEdynamicsLog.Infrastructure.Servicios
{
    public class ProductoService : IProductService
    {
        private readonly DbContextProductos _context;

        public ProductoService(DbContextProductos context)
        {
            _context = context;
        }

        public async Task<bool> AddProducto(AddProductoDto obj)
        {
            try
            {
                _context.Productos.Add(new Producto()
                {
                    Id = Guid.NewGuid(),
                    Name = obj.name,
                    Descripcion = obj.descripcion
                });
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ez)
            {
                return false;
            }
        }

        public async Task<bool> DeleteProducto(Guid id)
        {
            try
            {
                var productoTmp = await _context.Productos.FirstOrDefaultAsync(x => x.Id == id);
                if (productoTmp != null)
                {
                    _context.Productos.Remove(productoTmp);
                    await _context.SaveChangesAsync();
                    return true;

                }
                return false;
            }
            catch (Exception ez)
            {
                return false;
            }
        }

        public async Task<Producto> EditProducto(EditProductoDto obj)
        {
            try
            {
                var productoTmp = await _context.Productos.FirstOrDefaultAsync(x => x.Id == obj.id);
                if (productoTmp != null)
                {
                    productoTmp.Name = obj.name;
                    productoTmp.Descripcion = obj.descripcion;
                    await _context.SaveChangesAsync();
                    return productoTmp;

                }
                return null;
            }
            catch (Exception ez)
            {
                return null;
            }
        }

        public async Task<List<Producto>> GetProductos()
        {
            //esto se puede paginar
            return _context.Productos.ToList();
        }
    }
}
