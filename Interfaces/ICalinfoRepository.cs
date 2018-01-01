using System.Collections.Generic;
using HackOne.Model;

namespace HackOne.Interface 
{
    public interface ICalinfoRepository
    {
        IEnumerable<Shop> GetAll();
        void Add(Shop item);
         void Update(Shop item1);
          Shop View(int item);



    }
}



