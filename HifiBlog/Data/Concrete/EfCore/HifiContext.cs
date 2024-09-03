
using HifiBlog.Entity;
using Microsoft.EntityFrameworkCore;
namespace HifiBlog.Data.Concrete.EfCore
{
    public class HifiContext:DbContext
    {
        
        public HifiContext(DbContextOptions<HifiContext> options):base(options){

        }
       public DbSet <Blog> Blogs => Set<Blog>();
       public DbSet <Slider> Sliders => Set<Slider>();
       public DbSet <PreliminaryInormation> preliminaryInormations=> Set<PreliminaryInormation>();
    }
}