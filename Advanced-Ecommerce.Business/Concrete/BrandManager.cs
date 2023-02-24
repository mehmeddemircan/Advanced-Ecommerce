using Advanced_Ecommerce.Business.Abstract;
using Advanced_Ecommerce.Business.Constants;
using Advanced_Ecommerce.Business.Validation.FluentValidation;
using Advanced_Ecommerce.Core.Aspects.Validation;
using Advanced_Ecommerce.Core.Utilities.Responses;
using Advanced_Ecommerce.Core.Utilities.Results;
using Advanced_Ecommerce.DataAccess.Abstract;
using Advanced_Ecommerce.Entities.Concrete;
using Advanced_Ecommerce.Entities.Dtos.Brand;
using Advanced_Ecommerce.Entities.Dtos.Product;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandRepository _brandRepository;
        IProductRepository _productRepository;
        IMapper _mapper; 
        public BrandManager(IBrandRepository brandRepository,IMapper mapper,IProductRepository productRepository)
        {
            _brandRepository = brandRepository;
            _productRepository = productRepository; 
            _mapper = mapper;
        }

        [ValidationAspect(typeof(BrandValidator))]
        public async Task<IDataResult<BrandDto>> AddAsync(BrandAddDto entity)
        {
            var brand = _mapper.Map<Brand>(entity);
            //Todo: CreatedTime and CreatedId düzenlenecek  
            brand.CreatedUserId = 4;
            brand.CreatedDate = DateTime.Now;
      
            var brandAdd = await _brandRepository.AddAsync(brand);
            var brandDto = _mapper.Map<BrandDto>(brandAdd);

            return new SuccessDataResult<BrandDto>(brandDto, Messages.BrandAdded);
        }

        public async Task<IDataResult<bool>> DeleteAsync(int id)
        {
            var isDelete = await _brandRepository.DeleteAsync(id);
            return new SuccessDataResult<bool>(isDelete, Messages.Deleted);
        }

        public async Task<IDataResult<BrandDto>> GetAsync(Expression<Func<Brand, bool>> filter)
        {
            var brand = await _brandRepository.GetAsync(filter);
          
            if (brand != null)
            {

                //nested class veri aktarma 
                var products = await _productRepository.GetListAsync(x => x.BrandId == brand.Id);
                //var productDetailDtos = _mapper.Map<IEnumerable<ProductDetailDto>>(products);

                //brand.Products = productDetailDtos;
                brand.Products = products; 

                //
                var brandDto = _mapper.Map<BrandDto>(brand);
                return new SuccessDataResult<BrandDto>(brandDto, Messages.Listed);
            }
            return new ErrorDataResult<BrandDto>(null, Messages.NotListed);
        }

        public  async Task<IDataResult<IEnumerable<BrandDetailDto>>> GetListAsync(Expression<Func<Brand, bool>> filter = null)
        {
            if (filter == null)
            {

                var response = await _brandRepository.GetListAsync();
                var brandDetailDtos = _mapper.Map<IEnumerable<BrandDetailDto>>(response);

                return new SuccessDataResult<IEnumerable<BrandDetailDto>>(brandDetailDtos, Messages.BrandListed);
            }
            else
            {
                var response = await _brandRepository.GetListAsync(filter);
                var brandDetailDtos = _mapper.Map<IEnumerable<BrandDetailDto>>(response);

                return new SuccessDataResult<IEnumerable<BrandDetailDto>>(brandDetailDtos, Messages.BrandListed);
            }
        }

        public  async Task<IDataResult<BrandUpdateDto>> UpdateAsync(BrandUpdateDto entity)
        {
            var getBrand = await _brandRepository.GetAsync((x => x.Id == entity.Id));
            var brand = _mapper.Map<Brand>(entity);
            brand.CreatedDate = getBrand.CreatedDate;
            brand.CreatedUserId = getBrand.CreatedUserId;
            brand.UpdatedDate = DateTime.Now;
            brand.UpdatedUserId = 4;


            var resultUpdate = await _brandRepository.UpdateAsync(brand);
            var brandUpdateMap = _mapper.Map<BrandUpdateDto>(resultUpdate);

            return new SuccessDataResult<BrandUpdateDto>(brandUpdateMap, Messages.Updated);
        }
    }
}
