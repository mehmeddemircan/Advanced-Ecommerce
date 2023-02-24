using Advanced_Ecommerce.Business.Abstract;
using Advanced_Ecommerce.Business.Constants;
using Advanced_Ecommerce.Core.Utilities.Responses;
using Advanced_Ecommerce.Core.Utilities.Results;
using Advanced_Ecommerce.DataAccess.Abstract;
using Advanced_Ecommerce.Entities.Concrete;
using Advanced_Ecommerce.Entities.Dtos.Brand;
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
    public class ProductManager : IProductService
    {
        IProductRepository _productRepository;
        IBrandRepository _brandRepository;
        IProductColorRepository _productColorRepository;
        IColorRepository _colorRepository;
        IModelRepository _modelRepository;
        ISubCategoryRepository _subCategoryRepository;
        IMapper _mapper; 
        public ProductManager(IProductRepository productRepository, IMapper mapper, IBrandRepository brandRepository, IProductColorRepository productColorRepository, IColorRepository colorRepository, IModelRepository modelRepository,ISubCategoryRepository subCategoryRepository)
        {
            _productRepository = productRepository;
            _brandRepository = brandRepository;
            _mapper = mapper;
            _productColorRepository = productColorRepository;
            _colorRepository = colorRepository;
            _modelRepository = modelRepository;
            _subCategoryRepository = subCategoryRepository;
        }

        public async Task<IDataResult<ProductDto>> AddAsync(ProductAddDto entity)
        {
            var product = _mapper.Map<Product>(entity);
            //Todo: CreatedTime and CreatedId düzenlenecek  
            product.CreatedUserId = 4;
            product.CreatedDate = DateTime.Now;

            var productAdd = await _productRepository.AddAsync(product);
            var productDto = _mapper.Map<ProductDto>(productAdd);

            return new SuccessDataResult<ProductDto>(productDto, Messages.BrandAdded);
        }

       

        public async Task<IDataResult<bool>> DeleteAsync(int id)
        {
            var isDelete = await _productRepository.DeleteAsync(id);
            return new SuccessDataResult<bool>(isDelete, Messages.Deleted);  
        }

        public async Task<IDataResult<ProductDto>> GetAsync(Expression<Func<Product, bool>> filter)
        {
            var product = await _productRepository.GetAsync(filter);
            if (product != null)
            {


                // brand gösterme kısmı 
                var brand = await _brandRepository.GetAsync(x => x.Id == product.BrandId);
               
                product.Brand = brand;

                //productColor gosterme kısmı 
                var productColors = await _productColorRepository.GetListAsync(x => x.ProductId == product.Id);
                // product colors daki coloru gösterme kısmı 
                foreach (var item in productColors)
                {
                    var color = await _colorRepository.GetAsync(x => x.Id == item.ColorId);
                    item.Color = color;
                }
                product.ProductColors = productColors;

                //model gösterme kısmı 
                var model = await _modelRepository.GetAsync(x => x.Id == product.ModelId);
                product.Model = model;

                //category gösterme kısmı 
                //var category = await _categoryRepository.GetAsync(x => x.Id == product.CategoryId);
                //product.Category = category;

                //subcategory gösterme kısmı 
                var subCategory = await _subCategoryRepository.GetAsync(x => x.Id == product.SubCategoryId);
                product.SubCategory = subCategory; 


                var productDto= _mapper.Map<ProductDto>(product);

        


                return new SuccessDataResult<ProductDto>(productDto, Messages.Listed);
            }
            return new ErrorDataResult<ProductDto>(null, Messages.NotListed);
        }

      

        public async Task<IDataResult<IEnumerable<ProductDetailDto>>> GetListAsync(Expression<Func<Product, bool>> filter = null)
        {
            if (filter == null)
            {

                var response = await _productRepository.GetListAsync();

                var productDetailDtos = _mapper.Map<IEnumerable<ProductDetailDto>>(response);

                return new SuccessDataResult<IEnumerable<ProductDetailDto>>(productDetailDtos, Messages.BrandListed);
            }
            else
            {
                var response = await _productRepository.GetListAsync(filter);
                var productDetailDtos = _mapper.Map<IEnumerable<ProductDetailDto>>(response);

                return new SuccessDataResult<IEnumerable<ProductDetailDto>>(productDetailDtos, Messages.BrandListed);
            }
        }

  



        //Todo: Update yapılacak 
        //Todo : Coka cok ilişkiler yapılacak şimdi 
        public Task<IDataResult<ProductUpdateDto>> UpdateAsync(ProductUpdateDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
