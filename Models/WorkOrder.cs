namespace workOrderApi.Models
{
    public class WorkOrder
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}