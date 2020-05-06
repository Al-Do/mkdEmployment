namespace Repository
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Repository;
    using Repository.Maps;

    public partial class ApplicationContext : DbContext
    {
        public ApplicationContext()
            : base("name=MKDContext")
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<JobPosting> JobPostings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CompanyMap());
            modelBuilder.Configurations.Add(new JobPostingMap());
        }
    }
}
