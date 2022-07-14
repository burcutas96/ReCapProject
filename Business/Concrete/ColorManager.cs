using Business.Abstract;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcern.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }


        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {

            color.Id = 0;
            _colorDal.Add(color);
            return new SuccesResult(ColorMessages.ColorAdded);

        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccesResult(ColorMessages.ColorDeleted);
        }

        public IDataResult<Color> Get(Color color)
        {
            return new SuccesDataResult<Color>(_colorDal.Get(c => c.Id == color.Id));
        }

        public IDataResult<List<Color>> GetAll()
        {
            if (DateTime.Now.Hour == 19)
            {
                return new ErrorDataResult<List<Color>>(AppMessages.MaintenanceTime);
            }
            else
            {
                return new SuccesDataResult<List<Color>>(_colorDal.GetAll(), ColorMessages.ColorsListed);
            }

        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccesDataResult<Color>(_colorDal.Get(c => c.Id == id));
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccesResult(ColorMessages.ColorUpdated);
        }
    }
}
