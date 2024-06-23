using MyAcademyChainOfResponsibility.DataAccess.Context;
using MyAcademyChainOfResponsibility.DataAccess.Entities;
using MyAcademyChainOfResponsibility.Models;

namespace MyAcademyChainOfResponsibility.ChainOfResponsibility
{
    public class RegionalManager : Employee
    {
        private readonly CoFContext _context;

        public RegionalManager(CoFContext context)
        {
            _context = context;
        }

        public override void Process(CustomerProcessViewModel request)
        {

            if (request.Price <= 500000)
            {
                var customerProcess = new CustomerProcess
                {
                    Name = request.Name,
                    Price = request.Price,
                    EmployeeName = "Mert Arslanoğlu - Bölge Müdürü",
                    Description = "Para Çekme İşlemi Başarı ile Gerçekleştirilmiştir, Müşteriye Para Ödenmesi Yapılmıştır."
                };

                _context.Add(customerProcess);
                _context.SaveChanges();
            }
            else
            {
                var customerProcess = new CustomerProcess
                {
                    Name = request.Name,
                    Price = request.Price,
                    EmployeeName = "Mert Arslanoğlu - Bölge Müdürü",
                    Description = "Para Çekme İşlemi Başarısız Olmuştur, Müşteriye Ödenecek Para Limiti Aşıldı."
                };

                _context.Add(customerProcess);
                _context.SaveChanges();
            }
        }
    }
}
