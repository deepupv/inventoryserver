using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryServer
{
    public class InventoryService : Inventory.InventoryBase
    {
        private readonly ILogger<InventoryService> _logger;
        public InventoryService(ILogger<InventoryService> logger)
        {
            _logger = logger;
        }

        

        public override Task<UpdateReply> UpdateInventory(Order req, ServerCallContext context)
        {
            return Task.FromResult(new UpdateReply
            {
                Message = "Updated inventory for  " + req?.Items?.Count + " products"
            });

        }
    }
}
