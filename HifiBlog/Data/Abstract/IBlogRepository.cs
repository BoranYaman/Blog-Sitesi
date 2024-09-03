using System.Reflection.Metadata;
using HifiBlog.Entity;

namespace HifiBlog.Data.Abstract
{
    public interface IBlogRepository
    {
        IQueryable<Blog> Blogs{ get; }
        void BlogList(Blog blog);
    }
}