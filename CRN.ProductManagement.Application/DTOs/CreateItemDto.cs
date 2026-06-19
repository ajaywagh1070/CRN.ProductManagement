using System;
using System.Collections.Generic;
using System.Text;

namespace CRN.ProductManagement.Application.DTOs
{
    public class CreateItemDto
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
