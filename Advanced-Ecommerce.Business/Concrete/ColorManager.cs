using Advanced_Ecommerce.Business.Abstract;
using Advanced_Ecommerce.Business.Constants;
using Advanced_Ecommerce.Business.Validation.FluentValidation;
using Advanced_Ecommerce.Core.Aspects.Validation;
using Advanced_Ecommerce.Core.Utilities.Responses;
using Advanced_Ecommerce.Core.Utilities.Results;
using Advanced_Ecommerce.DataAccess.Abstract;
using Advanced_Ecommerce.Entities.Concrete;
using Advanced_Ecommerce.Entities.Dtos.Color;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorRepository _colorRepository;
        IMapper _mapper; 

        public ColorManager(IColorRepository colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public async Task<IDataResult<ColorDto>> AddAsync(ColorAddDto entity)
        {
            var color = _mapper.Map<Color>(entity);

            color.CreatedUserId = 4;
            color.CreatedDate = DateTime.Now;

            var colorAdd = await _colorRepository.AddAsync(color);

            var colorDto = _mapper.Map<ColorDto>(colorAdd); 

            return new SuccessDataResult<ColorDto>(colorDto,Messages.BrandAdded);
            
        }

        public Task<IDataResult<bool>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<ColorDto>> GetAsync(Expression<Func<Brand, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<IEnumerable<ColorDetailDto>>> GetListAsync(Expression<Func<Color, bool>> filter = null)
        {
            if (filter == null)
            {

                var response = await _colorRepository.GetListAsync();
                var colorDetailDtos = _mapper.Map<IEnumerable<ColorDetailDto>>(response);

                return new SuccessDataResult<IEnumerable<ColorDetailDto>>(colorDetailDtos, Messages.BrandListed);
            }
            else
            {
                var response = await _colorRepository.GetListAsync(filter);
                var colorDetailDtos = _mapper.Map<IEnumerable<ColorDetailDto>>(response);


                return new SuccessDataResult<IEnumerable<ColorDetailDto>>(colorDetailDtos, Messages.BrandListed);
            }
        }

        public Task<IDataResult<ColorUpdateDto>> UpdateAsync(ColorUpdateDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
