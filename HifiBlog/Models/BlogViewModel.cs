using HifiBlog.Entity;
namespace HifiBlog.Models{
public class BlogViewModel
{
    public List<Blog>? Blogs { get; set; }
    public List<PreliminaryInormation>? PreliminaryInormations { get; set; }
    public List<Blog> HighlightedBlogs { get; set; }
    public List <Slider>? Sliders { get; set; }

}
}