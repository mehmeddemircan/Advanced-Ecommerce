using Advanced_Ecommerce.Business.Abstract;
using Advanced_Ecommerce.Business.Constants;
using Advanced_Ecommerce.Core.Utilities.Responses;
using Advanced_Ecommerce.Core.Utilities.Results;
using Advanced_Ecommerce.DataAccess.Abstract;
using Advanced_Ecommerce.Entities.Concrete;
using Advanced_Ecommerce.Entities.Dtos.SubCategory;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Business.Concrete
{
    public class SubCategoryManager : ISubCategoryService 
    {
        ISubCategoryRepository _subCategoryRepository;
        ICategoryRepository _categoryRepository;
        IMapper _mapper; 
        public SubCategoryManager(ISubCategoryRepository subCategoryRepository, IMapper mapper, ICategoryRepository categoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<IDataResult<SubCategoryDto>> AddAsync(SubCategoryAddDto entity)
        {
            var subCategory = _mapper.Map<SubCategory>(entity);

            subCategory.CreatedDate = DateTime.Now;
            subCategory.CreatedUserId = 4;

            var subCategoryAdd = await _subCategoryRepository.AddAsync(subCategory);
            var subCategoryDto = _mapper.Map<SubCategoryDto>(subCategoryAdd);

            return new SuccessDataResult<SubCategoryDto>(subCategoryDto, Messages.Added); 
        }

        public async Task<IDataResult<bool>> DeleteAsync(int id)
        {
            var isDelete = await _subCategoryRepository.DeleteAsync(id);

            return new SuccessDataResult<bool>(isDelete, Messages.Deleted); 
        }

        public async Task<IDataResult<SubCategoryDto>> GetAsync(Expression<Func<SubCategory, bool>> filter)
        {

            var subCategory = await _subCategoryRepository.GetAsync(filter);

        
            if (subCategory != null)
            {

                //category gösterme kısmı 
                var category = await _categoryRepository.GetAsync(x => x.Id == subCategory.CategoryId);
                subCategory.Category = category; 
                //-----------

                var subCategoryDto = _mapper.Map<SubCategoryDto>(subCategory);
                return new SuccessDataResult<SubCategoryDto>(subCategoryDto, Messages.Listed);
            }
            return new ErrorDataResult<SubCategoryDto>(null, Messages.NotListed); 
        }

        public async Task<IDataResult<IEnumerable<SubCategoryDetailDto>>> GetListAsync(Expression<Func<SubCategory, bool>> filter = null)
        {
            if (filter==null)
            {
                var subCategory = await _subCategoryRepository.GetListAsync();

                var subCategoryDtos = _mapper.Map<IEnumerable<SubCategoryDetailDto>>(subCategory);
                return new SuccessDataResult<IEnumerable<SubCategoryDetailDto>>(subCategoryDtos, Messages.Listed);
            }
            else
            {
                var subCategory = await _subCategoryRepository.GetListAsync(filter);

                var subCategoryDtos = _mapper.Map<IEnumerable<SubCategoryDetailDto>>(subCategory);
                return new SuccessDataResult<IEnumerable<SubCategoryDetailDto>>(subCategoryDtos, Messages.Listed);
            }
        }

        public Task<IDataResult<SubCategoryUpdateDto>> UpdateAsync(SubCategoryUpdateDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
