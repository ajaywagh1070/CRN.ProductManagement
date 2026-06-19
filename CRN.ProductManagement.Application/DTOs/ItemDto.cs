using System;
using System.Collections.Generic;
using System.Text;

namespace CRN.ProductManagement.Application.DTOs
{
    public class ItemDto
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
