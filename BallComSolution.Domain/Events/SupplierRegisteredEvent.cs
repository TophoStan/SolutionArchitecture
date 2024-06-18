﻿namespace SupplierManagement.Domain.Events;

public class SupplierRegisteredEvent
{
    public string SupplierName { get; set; }
    public string ContactName { get; set; }
    public string ContactEmail { get; set; }
    public string ContactPhone { get; set; }
    public string Address { get; set; }
}
