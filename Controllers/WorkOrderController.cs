using Microsoft.AspNetCore.Mvc;
using workOrderAPI.Models;
using System.Collections.Generic;
using System.Linq;
namespace workOrderAPI.Controllers{
    

    //ASP.NET is case insensitive. maps controller name minus the suffix. i.e workorder
    [Route("api/[controller]")]
    [ApiController]
        public class WorkOrderController : ControllerBase{
            private readonly WorkOrderContext _context;

            public WorkOrderController(WorkOrderContext context){
                _context = context;

                if(_context.WorkOrderItems.Count() == 0){
                        _context.WorkOrderItems.Add(new WorkOrder{short_description = "sample workOrder1"});
                        _context.SaveChanges();       
                }
            }

            //Get all work orders
            [HttpGet]
            public ActionResult<List<WorkOrder>> GetAll(){
                return _context.WorkOrderItems.ToList();
            }

            // Get a single workOrder
            [HttpGet("{id}", Name = "GetWorkOrder")]
            public ActionResult<WorkOrder> GetById(long id){
                var workOrder = _context.WorkOrderItems.Find(id);
                if(workOrder == null){
                    return NotFound();
                }
                return workOrder;
            }

            //create a work order
            [HttpPost]
            public IActionResult Create(WorkOrder workOrder){
                _context.WorkOrderItems.Add(workOrder);
                _context.SaveChanges();
                
                return CreatedAtRoute("GetWorkOrder", new WorkOrder{id = workOrder.id}, workOrder);
            }

            //update a work order
            [HttpPut("{id}")]
            public IActionResult Update(long id, WorkOrder workOrder){
                var work = _context.WorkOrderItems.Find(id);
                if(work == null){
                    return NotFound();
                }

                work.location = workOrder.location;
                work.address = workOrder.address;
                work.address2 = workOrder.address2;
                work.city = workOrder.city;
                work.state = workOrder.state;
                work.zip = workOrder.zip;
                work.phone = workOrder.phone;
                work.caller = workOrder.caller;
                work.priority = workOrder.priority;
                work.asset_tag = workOrder.asset_tag;
                work.asset_serial_number = workOrder.asset_serial_number;
                work.asset_model_number = workOrder.asset_model_number;
                work.asset_type = workOrder.asset_type;
                work.warranty_expiration = workOrder.warranty_expiration;
                work.manufacturer = workOrder.manufacturer;
                work.category = workOrder.category;
                work.subcategory = workOrder.subcategory;
                work.nte = workOrder.nte;
                work.functional_status = workOrder.functional_status;
                work.short_description = workOrder.short_description;
                work.work_order_type = workOrder.work_order_type;
                work.insurance_loss_number = workOrder.insurance_loss_number;
                work.parent = workOrder.parent;
                work.child = workOrder.child;
                work.date_reported = workOrder.date_reported;


                _context.WorkOrderItems.Update(work);
                _context.SaveChanges();
                return NoContent();
            }
  

    }
}