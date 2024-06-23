using MyAcademyChainOfResponsibility.DataAccess.Context;
using MyAcademyChainOfResponsibility.DataAccess.Entities;
using MyAcademyChainOfResponsibility.Models;

namespace MyAcademyChainOfResponsibility.ChainOfResponsibility
{
    public class Clerk : Employee
    {
        private readonly CoFContext _context;

        public Clerk(CoFContext context)
        {
            _context = context;
        }

        public override void Process(CustomerProcessViewModel request)
        {
            if(request.Price <= 50000)
            {
                var customerProcess = new CustomerProcess
                {
                    Name = request.Name,
                    Price = request.Price,
                    EmployeeName = "Esin Çağla Kıral - Gişe Memuru",
                    Description = "Para Çekme İşlemi Başarı ile Gerçekleştirilmiştir, Müşteriye Para Ödenmesi Yapılmıştır."
                };

                _context.Add(customerProcess);
                _context.SaveChanges();
            }
            else if(NextApprover != null)
            {
                var customerProcess = new CustomerProcess
                {
                    Name = request.Name,
                    Price = request.Price,
                    EmployeeName = "Esin Çağla Kıral - Gişe Memuru",
                    Description = "Para Çekme İşlemi Başarısız Olmuştur, Müşteri Bankamızın Müdür Yardımcısına Yönlendirildi."
                };
                _context.Add(customerProcess);
                _context.SaveChanges();

                NextApprover.Process(request);
            }
        }
    }
}
