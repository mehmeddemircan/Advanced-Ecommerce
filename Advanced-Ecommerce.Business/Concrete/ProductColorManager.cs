using Advanced_Ecommerce.Business.Abstract;
using Advanced_Ecommerce.Business.Constants;
using Advanced_Ecommerce.Core.Utilities.Responses;
using Advanced_Ecommerce.Core.Utilities.Results;
using Advanced_Ecommerce.DataAccess.Abstract;
using Advanced_Ecommerce.Entities.Concrete;
using Advanced_Ecommerce.Entities.Dtos.Color;
using Advanced_Ecommerce.Entities.Dtos.Product;
using Advanced_Ecommerce.Entities.Dtos.ProductColor;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Business.Concrete
{
    public class ProductColorManager : IProductColorService
    {
        IProductColorRepository _productColorRepository;
        IColorRepository _colorRepository; 
        IMapper _mapper; 
        public ProductColorManager(IProductColorRepository productColorRepository, IMapper mapper, IColorRepository colorRepository)
        {
            _productColorRepository = productColorRepository;
            _mapper = mapper;
            _colorRepository = colorRepository;
        }
        public async Task<IDataResult<ProductColorDto>> AddColorToProduct(ProductColorAddDto productColorAddDto)
        {
            var productColor = _mapper.Map<ProductColor>(productColorAddDto);
            //Todo: CreatedTime and CreatedId düzenlenecek  
            productColor.CreatedUserId = 4;
            productColor.CreatedDate = DateTime.Now;

            var productColorAdd = await _productColorRepository.AddAsync(productColor);
            var productColorDto = _mapper.Map<ProductColorDto>(productColorAdd);

            return new SuccessDataResult<ProductColorDto>(productColorDto, Messages.BrandAdded);
        }

        public async Task<IDataResult<bool>> DeleteProductColorAsync(int id)
        {
            var isDelete = await _productColorRepository.DeleteAsync(id);
            return new SuccessDataResult<bool>(isDelete, Messages.Deleted);
        }

        public async Task<IDataResult<IEnumerable<ProductColorDto>>> GetProductColorListAsync(Expression<Func<ProductColor, bool>> filter = null)
        {
            if (filter == null)
            {

                var response = await _productColorRepository.GetListAsync();
                var productColorDtos = _mapper.Map<IEnumerable<ProductColorDto>>(response);

                return new SuccessDataResult<IEnumerable<ProductColorDto>>(productColorDtos, Messages.BrandListed);
            }
            else
            {
                var response = await _productColorRepository.GetListAsync(filter);

              



                var productColorDtos = _mapper.Map<IEnumerable<ProductColorDto>>(response);

                return new SuccessDataResult<IEnumerable<ProductColorDto>>(productColorDtos, Messages.BrandListed);
            }
        }
    }
}
