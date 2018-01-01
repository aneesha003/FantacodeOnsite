using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using HackOne.Interface;
using HackOne.Model;

namespace HackOne.Repositories
{
    public class InventoryRepository:IInventoryRepository
    {

        private string connectionString;
        public InventoryRepository()
        {
            connectionString = @"Server=localhost;Database=CalInfo;Trusted_Connection=true;";
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public IEnumerable<Inventory> GetAll()
        {
            using(IDbConnection dbConnection = GetConnection())
            {
              dbConnection.Open();
              return dbConnection.Query<Inventory>("SELECT * FROM Inventory1");
            }
        }

        public void Add(Inventory item)
        {
            using (IDbConnection dbConnection = GetConnection())
            {
                string sQuery = @"
            INSERT INTO Inventory1 (Item, Description,catagory,shopID,Image)
             VALUES(@Item, @Description, @catagory,@shopID,@Image)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, item);
            }
        }

        public void Update(Inventory item1)
        {
            try{
            using (System.Data.IDbConnection dbConnection = GetConnection())
            {
                string sQuery = @"UPDATE Inventory1 SET
                Item = @Item,
                Description = @description,
                catagory= @Catagory,
                Image=@Image
                WHERE Inventoryid = @Inventoryid
                AND shopid= @shopid";
                  

                
                dbConnection.Open();
                dbConnection.Query(sQuery, item1);
            }
            }
            catch(Exception e){
                return;
            }
        } 


         public Inventory View(int item)
        {
            using (IDbConnection dbConnection = GetConnection())
            {
                string sQuery = "Select * from Inventory1 where Inventoryid = @id ";
                dbConnection.Open();
                List<Inventory> inventorys = dbConnection.Query<Inventory>(sQuery, new { id = item }).ToList();
                
                return inventorys.FirstOrDefault();
            }
}    
    }
}   
    
    
   