using Microsoft.EntityFrameworkCore;

namespace workOrderAPI.Models
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