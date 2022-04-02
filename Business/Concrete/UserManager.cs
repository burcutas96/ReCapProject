using Business.Abstract;
using Business.Constants;
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
            if(user.FirstName.Length > 2 && user.LastName.Length > 2)
            {
                user.Id = 0;
                _userDal.Add(user);
                return new SuccesResult(Messages.UserAdded);
            }
            else
            {
                return new ErrorResult(Messages.UserNameİnvalid);
            }
            
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
            return new SuccesDataResult<List<User>>(_userDal.GetAll(),Messages.UsersListed);
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
