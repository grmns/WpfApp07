﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public bool Active { get; set; }

        public Customer Customer { get; set; }
        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
