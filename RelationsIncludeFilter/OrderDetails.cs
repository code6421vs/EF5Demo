﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace RelationsIncludeFilter
{
    public partial class OrderDetails
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public int? OrdersId { get; set; }

        public virtual Orders Orders { get; set; }
    }
}