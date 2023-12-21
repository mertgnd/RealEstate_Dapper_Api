using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.StatisticRepositories
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly Context _context;

        public StatisticRepository(Context context)
        {
            _context = context;
        }

        public int ActiveCategoryCount()
        {
            string query = "Select Count(*) From Category where CategoryStatus=1";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            };
        }

        public int ActiveEmployeeCount()
        {
            string query = "Select Count(*) From Employee where Status=1";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            };
        }

        public int ApartmentCount()
        {
            string query = "Select Count(*) from Product where ProductCategory=3";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            };
        }

        public decimal AverageProductPriceByRent()
        {
            string query = "Select Avg(Price) from Product where Type='Rent'";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            };
        }

        public decimal AverageProductPriceBySale()
        {
            string query = "Select Avg(Price) from Product where Type='Sale'";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            };
        }

        public int AverageRoomCount()
        {
            string query = "Select Avg(RoomCount) from ProductDetails";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            };
        }

        public int CategoryCount()
        {
            string query = "Select Count(*) from Category";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            };
        }

        public string CategoryNameByMaximumProductCount()
        {
            string query = "Select top(1) CategoryName,Count(*) from Product inner join " +
                "Category on Product.ProductCategory=Category.CategoryID group by CategoryName " +
                "order by Count(*) Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            };
        }

        public string CityNameByMaxProductCount()
        {
            string query = "Select Top(1) City,COUNT(*) as 'post_count' from Product group by " +
                "City order by post_count Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            };
        }

        public int DifferentCityCount()
        {
            string query = "Select Count(Distinct(City)) from Product";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            };
        }

        public string EmployeeNameByMaximumProductCount()
        {
            string query = "Select Name,COUNT(*) as 'post_count' From Product inner join Employee on Product.EmployeeID=Employee.EmployeeID group by Name order by post_count Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            };
        }

        public decimal LastProductPrice()
        {
            string query = "Select Top(1) Price from Product order by ProductID Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<decimal>(query);
                return values;
            };
        }

        public string NewestBuildingYear()
        {
            string query = "Select Top(1) BuildYear from ProductDetails order by BuildYear Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            };
        }

        public string OldestBuildingYear()
        {
            string query = "Select Top(1) BuildYear from ProductDetails order by BuildYear Asc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            };
        }

        public int PassiveCategoryCount()
        {
            string query = "Select count(*) from category where CategoryStatus=0";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            };
        }

        public int ProductCount()
        {
            string query = "Select Count(*) from Product";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            };
        }
    }
}
