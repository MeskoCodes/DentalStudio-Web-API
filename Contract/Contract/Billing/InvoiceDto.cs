﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Contract.Billing
{
    internal class InvoiceDto
    {
        public int InvoiceId { get; set; }
        public int PatientId { get; set; }
        public DateTime IssuedDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = string.Empty;
    }

    internal class InvoiceCreateDto
    {
        public int PatientId { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = string.Empty;
    }

    internal class InvoiceUpdateDto
    {
        public int InvoiceId { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}