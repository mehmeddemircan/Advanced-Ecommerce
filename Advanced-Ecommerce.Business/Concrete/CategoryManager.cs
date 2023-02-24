using Advanced_Ecommerce.Business.Abstract;
using Advanced_Ecommerce.Business.Constants;
using Advanced_Ecommerce.Core.Utilities.Responses;
using Advanced_Ecommerce.Core.Utilities.Results;
using Advanced_Ecommerce.DataAccess.Abstract;
using Advanced_Ecommerce.Entities.Concrete;
using Advanced_Ecommerce.Entities.Dtos.Category;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryRepository _categoryRepository;
        ISubCategoryRepository _subCategoryRepository;
        IMapper _mapper; 
        public CategoryManager(ICategoryRepository categoryRepository, IMapper mapper, ISubCategoryRepository subCategoryRepository)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _subCategoryRepository = subCategoryRepository;
        }
        public async Task<IDataResult<CategoryDto>> AddAsync(CategoryAddDto entity)
        {
            var category = _mapper.Map<Category>(entity);

            category.CreatedUserId = 4; 
            category.CreatedDate = DateTime.Now;

            var categoryAdd = await _categoryRepository.AddAsync(category);
            var categoryDto = _mapper.Map<CategoryDto>(categoryAdd);

            return new SuccessDataResult<CategoryDto>(categoryDto, Messages.Added); 
        }

        public async Task<IDataResult<bool>> DeleteAsync(int id)
        {
            var isDelete = await _categoryRepository.DeleteAsync(id); 
            return new SuccessDataResult<bool>(isDelete, Messages.Deleted);
        }

        public async Task<IDataResult<CategoryDto>> GetAsync(Expression<Func<Category, bool>> filter)
        {
            var category = await _categoryRepository.GetAsync(filter);

            if (category != null)
            {

                //subCategory gösterme kısmı 
                var subCategories = await _subCategoryRepository.GetListAsync(x => x.CategoryId == category.Id);
                
                category.SubCategories = subCategories;
                //-----

                var categoryDto = _mapper.Map<CategoryDto>(category);


                return new SuccessDataResult<CategoryDto>(categoryDto, Messages.Listed); 
            }
            return new ErrorDataResult<CategoryDto>(null, Messages.NotListed); 
        }

        public async Task<IDataResult<IEnumerable<CategoryDetailDto>>> GetListAsync(Expression<Func<Category, bool>> filter = null)
        {
            if (filter== null)
            {
                var categories = await _categoryRepository.GetListAsync(); 
                var categoriesDetailDto = _mapper.Map<IEnumerable<CategoryDetailDto>>(categories);

                return new SuccessDataResult<IEnumerable<CategoryDetailDto>>(categoriesDetailDto, Messages.Listed); 
            }
            else
            {
                var categories = await _categoryRepository.GetListAsync(filter);
                var categoriesDetailDto = _mapper.Map<IEnumerable<CategoryDetailDto>>(categories);

                return new SuccessDataResult<IEnumerable<CategoryDetailDto>>(categoriesDetailDto, Messages.Listed);
            }
        }

        public Task<IDataResult<CategoryUpdateDto>> UpdateAsync(CategoryUpdateDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
