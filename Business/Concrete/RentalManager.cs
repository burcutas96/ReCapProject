using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcern.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }


        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {

            var result = _rentalDal.GetAll(r => r.CarId == rental.CarId && (r.ReturnDate == null || r.ReturnDate > DateTime.Now)).Any();

            if (result)
            {
                return new ErrorResult(Messages.Rentalİnvalid);
            }
            else
            {
                _rentalDal.Add(rental);
                return new SuccesResult(Messages.RentalAdded);
            }
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccesResult(Messages.RentalDeleted);
        }

        public IDataResult<Rental> Get(Rental rental)
        {
            return new SuccesDataResult<Rental>(_rentalDal.Get(r => r.Id == rental.Id));
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccesDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccesDataResult<Rental>(_rentalDal.Get(r => r.Id == id));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccesResult(Messages.RentalUpdated);
        }
    }
}
