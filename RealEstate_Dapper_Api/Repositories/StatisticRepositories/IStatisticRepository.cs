namespace RealEstate_Dapper_Api.Repositories.StatisticRepositories
{
    public interface IStatisticRepository
    {
        int CategoryCount();
        int ActiveCategoryCount();
        int PassiveCategoryCount();
        int ProductCount();
        int ApartmentCount();
        string EmployeeNameByMaximumProductCount();
        string CategoryNameByMaximumProductCount();
        decimal AverageProductPriceByRent();
        decimal AverageProductPriceBySale();
        string CityNameByMaxProductCount();
        int DifferentCityCount();
        decimal LastProductPrice();
        string NewestBuildingYear();
        string OldestBuildingYear();
        int AverageRoomCount();
        int ActiveEmployeeCount();

    }
}