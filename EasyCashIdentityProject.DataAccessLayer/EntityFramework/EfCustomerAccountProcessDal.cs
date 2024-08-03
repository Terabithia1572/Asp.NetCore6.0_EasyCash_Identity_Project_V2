
using EasyCashIdentityProject.DataAccessLayer.Abstract;
using EasyCashIdentityProject.DataAccessLayer.Concrete;
using EasyCashIdentityProject.DataAccessLayer.Repositories;
using EasyCashIdentityProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.DataAccessLayer.EntityFramework
{
    public class EfCustomerAccountProcessDal : GenericRepository<CustomerAccountProccess>, ICustomerAccountProcessDal
    {
        public List<CustomerAccountProccess> MyLastProcess(int id)
        {
            var context = new Context();
            var values=context.CustomerAccountProccesses.Where(x=>x.ReceiverID==id||x.SenderID==id)
                .ToList();
            return values;
        }
    }
}
