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
    public class CalinfoRepository : ICalinfoRepository
    {

        private string connectionString;
        public CalinfoRepository()
        {
            connectionString = @"Server=localhost;Database=CalInfo;Trusted_Connection=true;";
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public IEnumerable<Shop> GetAll()
        {
            using (IDbConnection dbConnection = GetConnection())
            {
                dbConnection.Open();
                return dbConnection.Query<Shop>("SELECT * FROM shop");
            }
        }

        public void Add(Shop item)
        {
            try
            {
                using (IDbConnection dbConnection = GetConnection())
                {
                    string sQuery = @"
                    INSERT INTO shop (Name, Description,location,Latitude,Longitude,Image)
                    VALUES(@Name, @description, @Location,@Latitude,@Longitude,@Image)";
                    dbConnection.Open();
                    dbConnection.Execute(sQuery, item);
                }
            }
            catch (Exception e)
            {
                return;
            }
        }

        public void Update(Shop item1)
        {
            using (System.Data.IDbConnection dbConnection = GetConnection())
            {
                string sQuery = @"UPDATE shop SET
                Name = @Name,
                Description = @description,
                location = @Location,
                Latitude = @Latitude,
                Longitude= @Longitude,
                Image=@Image
                WHERE Infoid = @id";


                dbConnection.Open();
                dbConnection.Query(sQuery, item1);
            }
        }


        public Shop View(int item)
        {
            using (IDbConnection dbConnection = GetConnection())
            {
                string sQuery = "Select * from shop where Infoid = @id ";
                dbConnection.Open();
                List<Shop> Calinfos = dbConnection.Query<Shop>(sQuery, new { id = item }).ToList();

                return Calinfos.FirstOrDefault();
            }
        }
    }
}


