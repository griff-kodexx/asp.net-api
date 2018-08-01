using Microsoft.EntityFrameworkCore;

namespace workOrderApi.Models
{
    public class WorkOrderContext : DbContext
    {
        public WorkOrderContext(DbContextOptions<WorkOrderContext> options)
            : base(options)
        {
        }

        public DbSet<WorkOrder> WorkOrderItems { get; set; }
    }
}