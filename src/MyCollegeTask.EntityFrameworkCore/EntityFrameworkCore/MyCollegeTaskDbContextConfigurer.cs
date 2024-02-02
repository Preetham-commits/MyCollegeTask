using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MyCollegeTask.EntityFrameworkCore
{
    public static class MyCollegeTaskDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MyCollegeTaskDbContext> builder, string connectionString)
        {
            builder.UseNpgsql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<MyCollegeTaskDbContext> builder, DbConnection connection)
        {
            builder.UseNpgsql(connection);
        }
    }
}
