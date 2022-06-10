using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
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

        public IResult Add(Color color)
        {
            ValidationTool.Validate(new ColorValidator(), color);

            color.Id = 0;
            _colorDal.Add(color);
            return new SuccesResult(Messages.ColorAdded);

        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccesResult(Messages.ColorDeleted);
        }

        public IDataResult<Color> Get(Color color)
        {
            return new SuccesDataResult<Color>(_colorDal.Get(c => c.Id == color.Id));
        }

        public IDataResult<List<Color>> GetAll()
        {
            if (DateTime.Now.Hour == 19)
            {
                return new ErrorDataResult<List<Color>>(Messages.MaintenanceTime);
            }
            else
            {
                return new SuccesDataResult<List<Color>>(_colorDal.GetAll(), Messages.ColorsListed);
            }

        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccesDataResult<Color>(_colorDal.Get(c => c.Id == id));
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccesResult(Messages.CarUpdated);
        }
    }
}
