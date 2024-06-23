using MyAcademyChainOfResponsibility.Models;

namespace MyAcademyChainOfResponsibility.ChainOfResponsibility
{
    public abstract class Employee
    {
        protected Employee NextApprover;

        public void SetNextApprover(Employee supervisor)
        {
            this.NextApprover = supervisor;
        }

        public abstract void Process(CustomerProcessViewModel request);


    }
}
