using Online__Learning_Platform.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Online__Learning_Platform.Helper
{
    internal static class Helpers
    {

        public static async Task AddEntity<T>(LearningPlatformDbContext DbContext, T Object) where T : class
        {
            await DbContext.AddAsync<T>(Object);

            await DbContext.SaveChangesAsync();
        }

        public static async Task AddRangeEntities<T>(LearningPlatformDbContext DbContext , IEnumerable<T> entities) where T : class
        {
            await DbContext.AddRangeAsync(entities);
            await DbContext.SaveChangesAsync();
        }

    }
}
