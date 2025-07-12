using AdventureWorksGraphQLAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph.Models;
using System.Fabric.Query;

namespace AdventureWorksGraphQLAPI.Data
{
    public class Query
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<List<Product>> GetProducts(AdventureWorks2022Context _dbcontext)
        {
            return await _dbcontext.Products.Include(x => x.ProductSubcategory).Include(x => x.ProductModel)
                                            .Include(x => x.BillOfMaterialComponents)
                                            .Include(x => x.BillOfMaterialProductAssemblies)
                                            .Include(x => x.ProductCostHistories)
                                            .Include(x => x.ProductInventories)
                                            .Include(x => x.ProductListPriceHistories)
                                            .Include(x => x.ProductProductPhotos)
                                            .Include(x => x.ProductReviews)
                                            .ToListAsync();
        }


        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<List<Product>> GetProductById(int id, AdventureWorks2022Context _dbcontext)
        {
            return await _dbcontext.Products.Include(x => x.ProductSubcategory).Include(x => x.ProductModel)
                                            .Include(x => x.BillOfMaterialComponents)
                                            .Include(x => x.BillOfMaterialProductAssemblies)
                                            .Include(x => x.ProductCostHistories)
                                            .Include(x => x.ProductInventories)
                                            .Include(x => x.ProductListPriceHistories)
                                            .Include(x => x.ProductProductPhotos)
                                            .Include(x => x.ProductReviews)
                                            .Where(p => p.ProductId == id).ToListAsync();
        }


        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<List<SalesOrderDetail>> GetSalesOrderById(int id, AdventureWorks2022Context _dbcontext)
        {
            //return await _dbcontext.SalesOrderDetails
            //                        .Include(x => x.SalesOrder)
            //                        .Include(x => x.Product)
            //                        .Include(x => x.Product.ProductSubcategory)
            //                        .Include(x => x.Product.ProductModel)
            //                        .Include(x => x.Product.BillOfMaterialComponents)
            //                        .Include(x => x.Product.BillOfMaterialProductAssemblies)
            //                        .Include(x => x.Product.ProductCostHistories)
            //                        .Include(x => x.Product.ProductInventories)
            //                        .Include(x => x.Product.ProductListPriceHistories)
            //                        .Include(x => x.Product.ProductProductPhotos)
            //                        .Include(x => x.Product.ProductReviews)
            //                        .Include(x => x.Product.ProductVendors)
            //                        .Include(x => x.Product.PurchaseOrderDetails)
            //                        .Include(x => x.SalesOrder.SalesPerson)
            //                        .Include(x => x.SalesOrder.ShipToAddress)
            //                        .Include(x => x.SalesOrder.BillToAddress)
            //                        .Include(x => x.SalesOrder.Customer)
            //                        .Where(p => p.SalesOrderId == id)
            //                        .ToListAsync();

            return await _dbcontext.SalesOrderDetails
                                    .Include(x => x.SalesOrder)
                                    .Include(x => x.Product)
                                    .Include(x => x.Product.ProductReviews)
                                    .Include(x => x.SalesOrder.ShipToAddress)
                                    .Include(x => x.SalesOrder.BillToAddress)
                                    .Where(p => p.SalesOrderId == id)
                                    .ToListAsync();
        }

    }
}
