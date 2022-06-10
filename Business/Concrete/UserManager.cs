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
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            ValidationTool.Validate(new UserValidator(), user);

            user.Id = 0;
            _userDal.Add(user);
            return new SuccesResult(Messages.UserAdded);


        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccesResult(Messages.UserDeleted);
        }

        public IDataResult<User> Get(User user)
        {
            return new SuccesDataResult<User>(_userDal.Get(u => u.Id == user.Id));
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccesDataResult<List<User>>(_userDal.GetAll(), Messages.UsersListed);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccesDataResult<User>(_userDal.Get(u => u.Id == id));
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccesResult(Messages.UserUpdated);
        }
    }
}
