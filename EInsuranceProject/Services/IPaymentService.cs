using EInsuranceProject.Model;

namespace EInsuranceProject.Services
{
    public interface IPaymentService
    {
        public Task<IEnumerable<Payment>> GetAll(string[] innerTables);
        public Task<Payment> GetById(int Id);
        public Task AddPayment(Payment payment);
        public Task<bool> UpdatePayment(Payment payment);
        public Task<bool> DeletePayment(int id);
    }
}
