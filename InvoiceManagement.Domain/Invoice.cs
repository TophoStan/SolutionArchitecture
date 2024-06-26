using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagement.Domain;

public class Invoice 
{
    public string InvoiceNumber { get; set; }
    public DateTime InvoiceDate { get; set; }
    public string Status { get; set; }
    public string OrderNumber { get; set; }
    public string SupplierName { get; set; }
    public string UserName { get; set; }

}
