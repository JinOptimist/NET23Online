using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Linq.Expressions;
using WebNet23Online.Data.DataModels;
using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories.Interfaces.DelightBistro;

namespace WebNet23Online.Data.Repositories
{
    public class FoodItemRepository : BaseRepository<FoodItemData>, IFoodItemRepository
    {
        public FoodItemRepository(WebContext context) : base(context) { }

        public List<FoodItemData> GetAllIncludeMenuAndIngredients()
        {
            var allFoods = _dbSet
                .Include(x => x.MenuData)
                .Include(x => x.IngredientsList);

            return allFoods.ToList();
        }

        public bool IsNameFree(string name)
        {
            return !_dbSet.Any(x => x.Name == name);
        }

        public FoodItemData? GetByIdIncludeMenuAndIngredientsLinks(int id)
        {
            var foodItemInclude = _dbSet
                .Include(x => x.MenuData)
                .Include(x => x.IngredientsList)
                .Include(fi => fi.FoodItemIngredientDatas) // Links
                .FirstOrDefault(x => x.Id == id);
            return foodItemInclude;
        }

        public List<FoodItemStatsDataModel> GetFoodItemStats()
        {
            var sql = @"SELECT 
            FI.[Name] as FoodItemName,
            COUNT (I.Id) as IngredientCount,
            FI.Price as FoodItemPrice,
            ISNULL (SUM(I.Price*FIID.QuantityOfIngredients/1000),0) as TotalPriceIngredient,
            FI.Price - ISNULL (SUM(I.Price*FIID.QuantityOfIngredients/1000),0) as Profit
            FROM FoodItemIngredientDatas as FIID
            LEFT JOIN FoodItems FI ON FIID.FoodItemDataId = FI.Id
            LEFT JOIN Ingredients I ON FIID.IngredientDataId = I.Id
            GROUP BY FI.[Name], FI.Id, FI.Price";

            var results = _context
                .Database
                .SqlQueryRaw<FoodItemStatsDataModel>(sql)
                .ToList();

            return results;
        }

        //private IQueryable<FoodItemData> GetQuerySource()
        //{
        //    var foodItemIncludeMenuIngredientsAndCreator = _dbSet
        //        .Include(f => f.MenuData)
        //        .Include(f => f.IngredientsList)
        //        .Include(f => f.Creator);

        //    return foodItemIncludeMenuIngredientsAndCreator;
        //}

        public List<FoodItemData> GetSortedAndFilteredFoodItemData(
            IQueryable<FoodItemData> querySource,
            string? sortBy,
            string? direction,
            string? filterBy = null,
            string? filterValue = null,
            string? filterType = null)
        {
            if (string.IsNullOrEmpty(sortBy))
            {
                return querySource.ToList();
            }

            // item
            var parameter = Expression.Parameter(typeof(FoodItemData), "item");

            var sortProperty = GetIncludedProperty(parameter, sortBy);
            var sortPropertyType = sortProperty.Type;

            var lambdaForOrder = Expression.Lambda(sortProperty, parameter);

            var methodName = direction is null
                || direction == "asc"
                ? "OrderBy"
                : "OrderByDescending";

            var orderByMethod = typeof(Queryable)
                .GetMethods()
                .First(x => x.Name == methodName
                    && x.GetParameters().Count() == 2)
                .MakeGenericMethod(typeof(FoodItemData), sortPropertyType);

            var sortedSource =
                (IQueryable<FoodItemData>)orderByMethod
                .Invoke(null, [querySource, lambdaForOrder])!;


            if (string.IsNullOrEmpty(filterBy) || string.IsNullOrEmpty(filterType) || string.IsNullOrEmpty(filterValue))
            {
                return sortedSource.ToList();
            }

            var filterProperty = GetIncludedProperty(parameter, filterBy);
            var filterPropType = filterProperty.Type;
            var convertedFilterValue = Convert.ChangeType(filterValue, filterPropType);
            var constFilterValue = Expression.Constant(convertedFilterValue);

            Expression filterExpression = filterType.ToLower() switch
            {
                "more" => Expression.GreaterThan(filterProperty, constFilterValue),
                "less" => Expression.LessThan(filterProperty, constFilterValue),
                "eq" => Expression.Equal(filterProperty, constFilterValue),
                _ => throw new Exception($"Unkonw filter type: {filterType}"),

            };

            var lambdaForWhere = Expression.Lambda(filterExpression, parameter);

            var whereMethod = typeof(Queryable)
               .GetMethods()
               .First(x => x.Name == "Where")
               .MakeGenericMethod(typeof(FoodItemData));

            var filteredAndSortedSource =
                (IQueryable<FoodItemData>)whereMethod.Invoke(null, [sortedSource, lambdaForWhere])!;


            return filteredAndSortedSource.ToList();
        }

        private MemberExpression GetIncludedProperty(Expression expression, string propertyPath)
        {
            // [MenuType, Name]
            var propeties = propertyPath.Split('.');
            var currentExpression = expression;

            // item.MenuType.Name
            foreach (var property in propeties)
            {
                var propInfo = currentExpression.Type.GetProperty(property);

                if (propInfo == null)
                {
                    throw new Exception($"Property {property} not found");
                }
                currentExpression = Expression.Property(currentExpression, propInfo);
            }

            //MenuType.Name
            return (MemberExpression)currentExpression;
        }
            }
}

