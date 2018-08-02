
namespace workOrderAPI.Models
{
    public class WorkOrder
    {
        public long id { get; set; }
        public string location { get; set; }
        public string address { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string phone { get; set; }
        public string caller { get; set; }
        public int priority { get; set; }
        public string asset_tag { get; set; }
        public string asset_serial_number { get; set; }
        public string asset_model_number { get; set; }
        public string asset_type { get; set; }
        public string warranty_expiration { get; set; }
        public string manufacturer { get; set; }
        public string category { get; set; }
        public string subcategory { get; set; }
        public string nte { get; set; }
        public string functional_status { get; set; }
        public string short_description { get; set; }
        public string work_order_type { get; set; }
        public string insurance_loss_number { get; set; }
        public string parent { get; set; }
        public string child { get; set; }
        public string date_reported { get; set; }

        public WorkOrder(){
            priority = 1;
            asset_model_number = "ATM Replacement - FCTI";
            category = "Electrical";
            subcategory = "Dedicated Power Source Needed - P3";
            functional_status = "To be Dispatched";
            work_order_type =  "Corrective Maintenance";
        }

    }
}