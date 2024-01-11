using pruebaTecnicaEdynamicsLog.Domain.DTOs;
using pruebaTecnicaEdynamicsLog.Domain.Entities.Productos;

namespace pruebaTecnicaEdynamicsLog.Domain.Interfaces
{
    public interface IProductService
    {
        Task<List<Producto>> GetProductos();
        Task<bool> AddProducto(AddProductoDto obj);
        Task<bool> DeleteProducto(Guid id);
        Task<Producto> EditProducto(EditProductoDto obj);
    }
}
