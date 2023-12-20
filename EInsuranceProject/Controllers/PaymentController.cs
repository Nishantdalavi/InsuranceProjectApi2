using EInsuranceProject.DTO;
using EInsuranceProject.Model;
using EInsuranceProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EInsuranceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        [HttpGet("GetAllPayments")]
        public async Task<IActionResult> GetPayments()
        {
            string[] innerTable = { "Policies" };
            var Payments = await _paymentService.GetAll(innerTable);
            var PaymentDTOS = new List<PaymentDTO>();
            foreach (var payment in Payments)
            {
                PaymentDTOS.Add(ConvertToPaymentDTO(payment));
            }
            return Ok(PaymentDTOS);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetByID([FromQuery] int Id)
        {

            var Payment = await _paymentService.GetById(Id);
            var PaymentDTO = ConvertToPaymentDTO(Payment);
            return Ok(PaymentDTO);
        }
        [HttpPost("AddPayment")]
        public async Task<IActionResult> AddPayment([FromBody] PaymentDTO paymentDTO)
        {
            var Payment = ConvertToPayment(paymentDTO);
            await _paymentService.AddPayment(Payment);
            return Ok(Payment);
        }
        [HttpPut("UpdatePayment")]
        public async Task<IActionResult> Update([FromBody] PaymentDTO paymentDTO)
        {
            var newPayment = ConvertToPayment(paymentDTO);
            await _paymentService.UpdatePayment(newPayment);
            return Ok("Updated Successfully");
        }
        [HttpDelete("DeletePayment/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _paymentService.DeletePayment(id);

            return Ok("Removed Successfully");


        }
        private Payment ConvertToPayment(PaymentDTO paymentDTO)
        {
            var Payment = new Payment()
            {
                PaymentId = paymentDTO.PaymentId,
                PaymentDate = paymentDTO.PaymentDate,
                PaymentType = paymentDTO.PaymentType,
                Amount = paymentDTO.Amount,
                Tax = paymentDTO.Tax,
                TotalPayment = paymentDTO.TotalPayment,
                Policies = new List<Policy>(),
                Status = paymentDTO.Status,


            };
            return Payment;

        }
        private PaymentDTO ConvertToPaymentDTO(Payment payment)
        {
            var paymentDTO = new PaymentDTO()
            {
                PaymentId=payment.PaymentId,
                PaymentDate=payment.PaymentDate,
                PaymentType=payment.PaymentType,
                Amount=payment.Amount,
                Tax=payment.Tax,
                TotalPayment=payment.TotalPayment,
                PoliciesCount=payment.Policies!=null? payment.Policies.Count():0,
                Status=payment.Status,
               
            };
            return paymentDTO;
        }

    }
}
