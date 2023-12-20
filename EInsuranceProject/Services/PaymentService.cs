using EInsuranceProject.Exceptions;
using EInsuranceProject.Model;
using EInsuranceProject.Repository;
using System.Linq.Expressions;

namespace EInsuranceProject.Services
{
    public class PaymentService : IPaymentService
    {
        private IEntityRepository<Payment> _repository;   
        public PaymentService(IEntityRepository<Payment> entityRepository)
        {
            _repository = entityRepository;
        }

        public async Task AddPayment(Payment payment)
        {
            await _repository.Insert(payment);
        }

        public async Task<bool> DeletePayment(int id)
        {
            var PaymentToDelete = await _repository.GetById(id);
            if (PaymentToDelete != null)
                return await _repository.Delete(id);
            throw new DataNotFoundExcpetion("No payment Data found");
        }

        public async Task<IEnumerable<Payment>> GetAll(string[] innerTables)
        {
            Expression<Func<Payment, bool>> filterPredicate = e => e.Status == true;
            var payments = await _repository.GetAll(innerTables, filterPredicate);
            if (payments.Count() > 0)
            {
                return payments;
            }
            throw new DataNotFoundExcpetion("No payment data found");
        }

        public async Task<Payment> GetById(int Id)
        {
            var payment = await _repository.GetById(Id);
            if (payment != null)
            {
                return payment;
            }
            throw new DataNotFoundExcpetion("No payment Data found");
        }

        public async Task<bool> UpdatePayment(Payment payment)
        {
            var PaymentToUpdate = await _repository.GetById(payment.PaymentId);
            if (PaymentToUpdate != null)
                return await _repository.Update(payment,payment.PaymentId);
            throw new DataNotFoundExcpetion("No payment Data found");
        }
    }
}
