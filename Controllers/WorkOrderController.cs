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
                        _context.WorkOrderItems.Add(new WorkOrder{Name = "WorkOrder1"});
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
                
                return CreatedAtRoute("GetWorkOrder", new WorkOrder{Id = workOrder.Id}, workOrder);
            }

            //update a work order
            [HttpPut("{id}")]
            public IActionResult Update(long id, WorkOrder workOrder){
                var work = _context.WorkOrderItems.Find(id);
                if(work == null){
                    return NotFound();
                }

                work.Description = workOrder.Description;
                work.Name = workOrder.Name;


                _context.WorkOrderItems.Update(work);
                _context.SaveChanges();
                return NoContent();
            }


            //deletes a work order
            [HttpDelete("{id}")]
            public IActionResult Delete(long id){
                var work = _context.WorkOrderItems.Find(id);
                if(work == null){
                    return NotFound();
                }

                _context.WorkOrderItems.Remove(work);
                _context.SaveChanges();
                return NoContent();
            }

    }
}