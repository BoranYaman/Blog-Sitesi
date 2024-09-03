using Microsoft.AspNetCore.Mvc;
using HifiBlog.Data.Concrete.EfCore;
using HifiBlog.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System;
using HifiBlog.Models;

using System.Threading.Tasks;
namespace HifiBlog.Controllers
{
    public class BlogController : Controller
    {
        private readonly HifiContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public BlogController(HifiContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }
       
public IActionResult Controllers()
{
    return View();
}
       
     public async Task<IActionResult> Home()
{
    var preliminaryinormations = await _context.preliminaryInormations
    .Where(x => x.IsActive  == "True")
                              .Take(1)
                              .ToListAsync();

            
    var blogs = await _context.Blogs
                             .Where(b => b.IsActive ==  "true")
                              .OrderByDescending(b => b.PublishedOn)
                              .Take(4)
                              .ToListAsync();
                              
     var sliders = await _context.Sliders
                                .Where(s => s.IsActive == "True")
                                .OrderByDescending(s => s.PublishedOn)
                                .Take(5)
                                .ToListAsync();

                                var highlightedBlogs = await _context.Blogs
                                             .Where(b => b.HighlightsValue == "True")
                                             .OrderByDescending(b => b.PublishedOn)
                                              .Take(3)
                                             .ToListAsync();

    var viewModel = new BlogViewModel
    {
        PreliminaryInormations =preliminaryinormations,
       Sliders= sliders,
        Blogs = blogs,
        HighlightedBlogs = highlightedBlogs
    };

    return View(viewModel);
}
   [HttpGet]
        public async Task<IActionResult>PreliminaryInormationDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Predelete = await _context.preliminaryInormations.FindAsync(id);
            if (Predelete == null)
            {
                return NotFound();

            }
            return View(Predelete);
        }
         [HttpPost]
        
          public async Task<IActionResult> PreliminaryInormationDelete([FromForm] int id)
        {
            var Predelete = await _context.preliminaryInormations.FindAsync(id);
            if(Predelete == null)
            {return NotFound();}
            _context.preliminaryInormations.Remove(Predelete);
            await _context.SaveChangesAsync();
            return RedirectToAction("Controllers");
        }
       

public async Task<IActionResult> PreliminaryInormationControllers()
        {
            return View(await _context.preliminaryInormations.ToListAsync());
        }

    [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PreliminaryInormationEdit(int id, PreliminaryInormation model)
        {
            if (id != model.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Blogs.Any(b => b.BlogId == model.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Controllers");
            }
            return View(model);
        }
         [HttpGet]
        public async Task<IActionResult> PreliminaryInormationEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blg = await _context.preliminaryInormations.FirstOrDefaultAsync(b => b.id == id);
            if (blg == null)
            {
                return NotFound();
            }

            return View(blg);
        }

        public IActionResult PreliminaryInormationAdd(){
            return View();
        }


[HttpPost]public async Task<IActionResult> PreliminaryInormationAdd(PreliminaryInormation model)
{
    
        _context.preliminaryInormations.Add(model);
        await _context.SaveChangesAsync();
        return RedirectToAction("Controllers");
   
    
}


        public IActionResult BlogList()
        {
            var viewModel = new BlogViewModel
            {
               Blogs = _context.Blogs.Where(b => b.IsActive=="true").ToList()
            };
            return View(viewModel);
        }

        public IActionResult BlogAdd()
        {
            return View();
        }

    
        [HttpPost]
        public async Task<IActionResult> BlogAdd(Blog model, IFormFile BlogImg)
        {
            if (ModelState.IsValid)
            {
                if (BlogImg != null)
                {
                    // Resim dosyasının kaydedileceği klasör yolu
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(BlogImg.FileName);
                    string extension = Path.GetExtension(BlogImg.FileName);
                    model.BlogImg = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath, "img", "Blogimg", fileName);

                    // Dizin mevcut değilse oluştur
                    if (!Directory.Exists(Path.Combine(wwwRootPath, "img", "Blogimg")))
                    {
                        Directory.CreateDirectory(Path.Combine(wwwRootPath, "img", "Blogimg"));
                    }

                    // Resim dosyasını sunucuya kaydet
                    try
                    {
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await BlogImg.CopyToAsync(fileStream);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Hata mesajını logla veya kullanıcıya bildir
                        ModelState.AddModelError("", "Dosya yükleme sırasında bir hata oluştu: " + ex.Message);
                        return View(model);
                    }
                }
                _context.Blogs.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("BlogList");
            }
            return View(model);
        }
         [HttpGet]
        public async Task<IActionResult>BlogDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var blog = await _context.Blogs.FindAsync(id);
            if (blog == null)
            {
                return NotFound();

            }
            return View(blog);
        }
         [HttpPost]
        
          public async Task<IActionResult> BlogDelete([FromForm] int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if(blog == null)
            {return NotFound();}
            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction("Controllers");
        }
       

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BlogEdit(int id, Blog model)
        {
            if (id != model.BlogId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Blogs.Any(b => b.BlogId == model.BlogId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Controllers");
            }
            return View(model);
        }
         [HttpGet]
        public async Task<IActionResult> BlogEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blg = await _context.Blogs.FirstOrDefaultAsync(b => b.BlogId == id);
            if (blg == null)
            {
                return NotFound();
            }

            return View(blg);
        }

            public IActionResult NewAdd()
            {
                return View();
            }
              public IActionResult SliderAdd()
          {
            return View();
          }
            public async Task <IActionResult> SliderControllers()
          {
          return View(await _context.Sliders.ToListAsync());
         
          }

  [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SliderEdit(int id, Slider model)
        {
            if (id != model.SliderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Sliders.Any(b => b.SliderId == model.SliderId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Controllers");
            }
            return View(model);
        }
           [HttpGet]
        public async Task<IActionResult> SliderEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sld = await _context.Sliders.FirstOrDefaultAsync(b => b.SliderId == id);
            if (sld == null)
            {
                return NotFound();
            }

            return View(sld);
        }


 [HttpGet]
        public async Task<IActionResult>SliderDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var slider = await _context.Sliders.FindAsync(id);
            if (slider == null)
            {
                return NotFound();

            }
            return View(slider);
        }
         [HttpPost]
        
          public async Task<IActionResult> SliderDelete([FromForm] int id)
        {
            var slider = await _context.Sliders.FindAsync(id);
            if(slider == null)
            {return NotFound();}
            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction("Controllers");
        }
       

[HttpPost]
public async Task<IActionResult> SliderAdd(Slider model, IFormFile SliderImg)
{
    if (ModelState.IsValid)
    {
        if (SliderImg != null)
        {
            // Resim dosyasının kaydedileceği klasör yolu
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(SliderImg.FileName);
            string extension = Path.GetExtension(SliderImg.FileName);
            model.SliderImg = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath, "img", "Sliderimg", fileName);

            // Dizin mevcut değilse oluştur
            if (!Directory.Exists(Path.Combine(wwwRootPath, "img", "Sliderimg")))
            {
                Directory.CreateDirectory(Path.Combine(wwwRootPath, "img", "Sliderimg"));
            }

            // Resim dosyasını sunucuya kaydet
            try
            {
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await SliderImg.CopyToAsync(fileStream);
                }
            }
            catch (Exception ex)
            {
                // Hata mesajını logla veya kullanıcıya bildir
                ModelState.AddModelError("", "Dosya yükleme sırasında bir hata oluştu: " + ex.Message);
                return View(model);
            }
        }
        try
        {
            _context.Sliders.Add(model);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            // Veritabanına ekleme sırasında bir hata oluştu
            ModelState.AddModelError("", "Veritabanına ekleme sırasında bir hata oluştu: " + ex.Message);
            return View(model);
        }
        return RedirectToAction("SliderAdd");
    }

    // Model validasyon hatalarını kontrol et
    var errors = ModelState.Values.SelectMany(v => v.Errors);
    foreach (var error in errors)
    {
        Console.WriteLine(error.ErrorMessage);
    }
    return View(model);
}


           public async Task<IActionResult>BlogDetails(int? id)
            {
                return View(await _context.Blogs.FirstOrDefaultAsync(b=> b.BlogId==id));
            }
        public async Task<IActionResult> BlogControllers()
        {
            return View(await _context.Blogs.ToListAsync());
        }
       
    }
}
