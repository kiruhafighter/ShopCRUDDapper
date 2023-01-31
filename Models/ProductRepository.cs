using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace ShopCRUDDapper.Models
{
    public class ProductRepository
    {
        private string connectionString;
        public ProductRepository()
        {
            connectionString = "Server=(LocalDB)\\MSSQLLocalDB;Database=DapperCRUDShop;Trusted_Connection=True;TrustServerCertificate=True";
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        public void Add(Product prod)
        {
            using(IDbConnection dbConnection = Connection)
            {
                string sQuery = @"INSERT INTO Products (Name,Quantity,Price) VALUES(@Name,@Quantity,@Price)";
                dbConnection.Open();
                dbConnection.Execute(sQuery,prod);
            }
        }

        public IEnumerable<Product> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Select * FROM Products";
                dbConnection.Open();
                return dbConnection.Query<Product>(sQuery);
            }
        }


        public Product GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Select * FROM Products Where Id = @Id";
                dbConnection.Open();
                return dbConnection.QueryFirstOrDefault<Product>(sQuery, new { Id = id});
            }
        }

        public void Delete (int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"DELETE FROM Products Where Id=@Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery,new { Id=id });
            }
        }

        public void Update(Product prod)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"UPDATE Products SET Name=@Name,Quantity=@Quantity,Price=@Price Where Id=@Id";
                dbConnection.Open();
                dbConnection.Query(sQuery,prod);
            }
        }
    }
}
