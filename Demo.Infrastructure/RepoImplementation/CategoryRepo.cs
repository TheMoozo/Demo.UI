using Dapper;
using Demo.Application.Repos;
using Demo.Core.DbModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Infrastructure.RepoImplementation
{
    public class CategoryRepo : ICategoryRepository
    {
        public IConfiguration Configuration { get; }
        public CategoryRepo(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public async Task<int> Add(Category entity)
        {
            
            var parm = new DynamicParameters();
            parm.Add("@CategoryName", entity.CategoryName);
            parm.Add("@CategoryNameArabic", entity.CategoryNameArabic);
            parm.Add("@ShowArabicName", entity.ShowArabicName);
            parm.Add("@CreatedDate", DateTime.Now);
            parm.Add("@UpdateDate", DateTime.Now);
            parm.Add("@Description", entity.Description);

            using (var connection = new SqlConnection(Configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var affectedrows = await connection.ExecuteAsync("spw_Category_Insert", parm, null, null, CommandType.StoredProcedure);
                return affectedrows;
            }
        }

        public async Task<int> Delete(int Id)
        {
            var parm = new DynamicParameters();
            parm.Add("@CategoryId", Id);

            using (var connection = new SqlConnection(Configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var affectedrows = await connection.ExecuteAsync("spw_Category_Delete", parm, null, null, CommandType.StoredProcedure);
                return affectedrows;
            }
        }

        public async Task<Category> Get(int Id)
        {
            var parm = new DynamicParameters();
            parm.Add("@CategoryId", Id);

            using (var connection = new SqlConnection(Configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Category>("spw_Category_GetById", parm, null, null, CommandType.StoredProcedure);
                return result.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            using (var connection = new SqlConnection(Configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Category>("spw_Category_GetAll", null, null, null, CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<int> Update(Category entity)
        {
            entity.UpdateDate = DateTime.Now;
            using (var connection = new SqlConnection(Configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var affectedrows = await connection.ExecuteAsync("spw_Category_Update", entity, null, null, CommandType.StoredProcedure);
                return affectedrows;
            }
        }
    }
}
