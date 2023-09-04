using Hr.LeaveManagement.Domain;
using Hr.LeaveManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.LeaveManagement.Persistence.DatabaseContext
{
    public class HrDatabaseContext : DbContext
    {
        //private readonly IUserService _userService;

        public HrDatabaseContext(DbContextOptions<HrDatabaseContext> options) : base(options)
        {
            //this._userService = userService;
        }

        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }


        // make sure all configurations are added 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HrDatabaseContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        // modify the datetime or create a new datetime anytime an entity is added or created
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.DateModified = DateTime.Now;
                

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;

                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
