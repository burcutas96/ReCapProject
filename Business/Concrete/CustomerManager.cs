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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            ValidationTool.Validate(new CustomerValidator(), customer);

            customer.Id = 0;
            _customerDal.Add(customer);
            return new SuccesResult(Messages.CustomerAdded);

        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccesResult(Messages.CustomerDeleted);
        }

        public IDataResult<Customer> Get(Customer customer)
        {
            return new SuccesDataResult<Customer>(_customerDal.Get(c => c.Id == customer.Id));
        }

        public IDataResult<List<Customer>> GetAll()
        {
            if (DateTime.Now.Hour == 13)
            {
                return new ErrorDataResult<List<Customer>>(Messages.MaintenanceTime);
            }
            else
            {
                return new SuccesDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CustomersListed);
            }
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccesDataResult<Customer>(_customerDal.Get(c => c.Id == id));
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccesResult(Messages.CustomerUpdated);
        }
    }
}
