using Advanced_Ecommerce.Core.Utilities.Responses;
using Advanced_Ecommerce.DataAccess.Abstract;
using Advanced_Ecommerce.DataAccess.Concrete.Contexts;
using Advanced_Ecommerce.DataAccess.EntityFramework;
using Advanced_Ecommerce.Entities.Concrete;
using Advanced_Ecommerce.Entities.Dtos.Product;
using Advanced_Ecommerce.Entities.Dtos.ProductColor;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.DataAccess.Concrete.EntityFramework
{
    public class ProductRepository : EfBaseRepository<Product, ApplicationDbContext>, IProductRepository
    {
        IMapper _mapper;
        public ProductRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ProductDto> AddColorToProduct(ProductColorAddDto productColorAddDto)
        {
            using (var context = new ApplicationDbContext() )
            {
                var productColor = _mapper.Map<ProductColor>(productColorAddDto);

                var productColorAdd =  await context.Set<ProductColor>().AddAsync(productColor);
                await context.SaveChangesAsync();

                var productDto = _mapper.Map<ProductDto>(productColorAdd);
                return productDto; 

            }
        }



        //public Task<IDataResult<ProductDto>> AddColorToProduct(ProductColorAddDto productColorAddDto)
        //{
        //    using (var context = new ApplicationDbContext())
        //    {
        //        var productColor = _mapper.Map<ProductColor>(productColorAddDto);
        //        //Todo: CreatedTime and CreatedId düzenlenecek  


        //        var brandAdd = await _brandRepository.AddAsync(brand);
        //        var brandDto = _mapper.Map<BrandDto>(brandAdd);
        //    }
        //}
    }
}
