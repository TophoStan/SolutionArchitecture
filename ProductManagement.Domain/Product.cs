﻿namespace ProductManagement.Domain;

public class Product
{
    public string? ProductId { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public int Price { get; set; }
    public int StockQuantity { get; set; }
    public string Category { get; set; }

    // to string
    public override string ToString()
    {
        return $"ProductId: {ProductId}, ProductName: {ProductName}, ProductDescription: {ProductDescription}, Price: {Price}, StockQuantity: {StockQuantity}, Category: {Category}";
    }
}
