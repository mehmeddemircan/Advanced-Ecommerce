using Advanced_Ecommerce.Business.Abstract;
using Advanced_Ecommerce.Business.Constants;
using Advanced_Ecommerce.Business.Validation.FluentValidation;
using Advanced_Ecommerce.Core.Aspects.Validation;
using Advanced_Ecommerce.Core.Utilities.Responses;
using Advanced_Ecommerce.Core.Utilities.Results;
using Advanced_Ecommerce.DataAccess.Abstract;
using Advanced_Ecommerce.Entities.Concrete;
using Advanced_Ecommerce.Entities.Dtos.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Business.Concrete
{
    public class ModelManager : IModelService 
    {
        IModelRepository _modelRepository;
        IProductRepository _productRepository;
        IMapper _mapper; 
        public ModelManager(IModelRepository modelRepository, IMapper mapper, IProductRepository productRepository)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        [ValidationAspect(typeof(ModelValidator))]
        public async Task<IDataResult<ModelDto>> AddAsync(ModelAddDto entity)
        {
           var model = _mapper.Map<Model>(entity);

            model.CreatedUserId = 4;
            model.CreatedDate = DateTime.Now;

            var modelAdd = await _modelRepository.AddAsync(model);

            var modelDto = _mapper.Map<ModelDto>(modelAdd);
            return new SuccessDataResult<ModelDto>(modelDto, Messages.Added); 
        }

        public async Task<IDataResult<bool>> DeleteAsync(int id)
        {
            var isDelete = await _modelRepository.DeleteAsync(id);
            return new SuccessDataResult<bool>(isDelete, Messages.Deleted); 
        }

        public async Task<IDataResult<ModelDto>> GetAsync(Expression<Func<Model, bool>> filter)
        {
            var model = await _modelRepository.GetAsync(filter);

            if (model != null)
            {

                //nested class veri aktarma 
                var products = await _productRepository.GetListAsync(x => x.ModelId == model.Id);
                //var productDetailDtos = _mapper.Map<IEnumerable<ProductDetailDto>>(products);

                //brand.Products = productDetailDtos;
                model.Products = products;

                //
                var modelDto = _mapper.Map<ModelDto>(model);
                return new SuccessDataResult<ModelDto>(modelDto, Messages.Listed);
            }
            return new ErrorDataResult<ModelDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<IEnumerable<ModelDetailDto>>> GetListAsync(Expression<Func<Model, bool>> filter = null)
        {
            if (filter == null)
            {

                var response = await _modelRepository.GetListAsync();
                var modelDetailDtos = _mapper.Map<IEnumerable<ModelDetailDto>>(response);

                return new SuccessDataResult<IEnumerable<ModelDetailDto>>(modelDetailDtos, Messages.BrandListed);
            }
            else
            {
                var response = await _modelRepository.GetListAsync(filter);
                var modelDetailDtos = _mapper.Map<IEnumerable<ModelDetailDto>>(response);

                return new SuccessDataResult<IEnumerable<ModelDetailDto>>(modelDetailDtos, Messages.BrandListed);
            }
        }

        public Task<IDataResult<ModelUpdateDto>> UpdateAsync(ModelUpdateDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
