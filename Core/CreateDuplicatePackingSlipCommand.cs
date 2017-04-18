using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Model;

namespace Core.Impl
{
    public class CreateDuplicatePackingSlipCommand:IPaymentProcessingCommand
    {
        public CreateDuplicatePackingSlipCommand(Product product)
        {
            Product = product;
        }

        public Product Product { get; private set; }
    }
}
