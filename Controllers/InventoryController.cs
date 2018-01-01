using System.Collections.Generic;
using HackOne;
using HackOne.Model;
using HackOne.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace  HackOne
{
    [Route("api/[controller]")]
    public class InventoryController : Controller
    {

        
        private readonly InventoryRepository inventoryRepository;

        public InventoryController()
        {
            inventoryRepository = new InventoryRepository();
        }

        [HttpGet]
         public IEnumerable<Inventory> Get() => inventoryRepository.GetAll();


        // POST api/Inventory
        [HttpPost]
        public void Post([FromBody]Inventory inventory)
        {
            if (ModelState.IsValid)
                inventoryRepository.Add(inventory);
        }

        // PUT api/Inventory/5
        [HttpPut]
        public void Put([FromBody]Inventory inventory)
        {
            if (ModelState.IsValid)
                inventoryRepository.Update(inventory);
        }

        //GET api/values/5
     // [HttpGet("{id}")]
       //public Shop ViewbyID(int id)
        //{  
            
            //if(ModelState.IsValid)
           // {
               // return inventoryRepository.View(id);

           // }
          // else return null;            
       // }

    
       
    }

  
}

