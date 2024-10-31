﻿namespace OrderManagement.Domain;

public class Order
{
    public int Id { get; set; }
    public required string CustomerName { get; set; }
    public required DateOnly OrderDate { get; set; }
    public required decimal TotalAmount { get; set; }
    public required CurrencyOrder Currency { get; set; }
    public required StatusOrder Status { get; set; }
    public required int Priority { get; set; }
    public required decimal TotalAmountBaseCurrency { get; set; }
}