using System.Collections.Generic;
using HackOne.Model;

namespace HackOne.Interface 
{
    public interface IInventoryRepository
    {
     IEnumerable<Inventory> GetAll();
     void Add(Inventory item);
     void Update(Inventory item1);
     Inventory View(int item);



    }
}