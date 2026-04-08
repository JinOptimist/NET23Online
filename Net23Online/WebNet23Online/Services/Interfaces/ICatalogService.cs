using WebNet23Online.Models.Steam;

namespace WebNet23Online.Services.Interfaces
{
    public interface ICatalogService
    {
        //CatalogViewModel GetCatalog();
        CatalogViewModel GetCatalog(CatalogFilterViewModel filter = null);
    }
}
