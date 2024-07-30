﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.DTOLayer.DTOS.CustomerAccountProcessDTOs
{
    public class SendMoneyForCustomerAccountProcessDTO
    {
        
        public string ProcessType { get; set; }
        public decimal Amount { get; set; }
        public DateTime ProcessDate { get; set; }
        /* public int MyProperty { get; set; }*/
        public int SenderID { get; set; }
        
        public int ReceiverID { get; set; }
        public string ReceiverAccountNumber { get; set; }
        public string Description { get; set; }

    }
}
