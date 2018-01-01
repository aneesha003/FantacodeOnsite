using System.Collections.Generic;
using HackOne;
using HackOne.Model;
using HackOne.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HackOne
{
    [Route("api/[controller]")]
    public class CalinfoController : Controller
    {

        private readonly CalinfoRepository calinfoRepository;

        public CalinfoController()
        {
            calinfoRepository = new CalinfoRepository();
        }

        [HttpGet]
         public IEnumerable<Shop> Get() => calinfoRepository.GetAll();


        // POST api/todo
        [HttpPost]
        public void Post([FromBody]Shop calinfo)
        {
            if (ModelState.IsValid)
                calinfoRepository.Add(calinfo);
        }

        // PUT api/todo/5
        [HttpPut]
        public void Put([FromBody]Shop calinfo)
        {
            if (ModelState.IsValid)
                calinfoRepository.Update(calinfo);
        }

        //* GET api/values/5
        [HttpGet("{id}")]
       public Shop ViewbyID(int id)
        {  
            
            if(ModelState.IsValid)
            {
                return calinfoRepository.View(id);

            }
            else return null;            
        } 
         

    
       
    }

  
}
