using Demo.Application.Interfaces;
using Demo.Core.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Application.Repos
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        //Custom Function If needed 
    }
}
