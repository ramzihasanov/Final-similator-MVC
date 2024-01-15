using FinalExc.Business.Services.Interfaces;
using FinalExp.Core.Entities;
using FinalExp.Core.Repositories;
using FinalExc.Business.Helpers;

namespace FinalExc.Business.Services.Implementes
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogrep;

        public BlogService(IBlogRepository blogrep)
        {
            this._blogrep = blogrep;
        }
        public async Task Create(Blog blog)
        {
            if (blog.image != null)
            {
                if (blog.image.Length > 1048576) throw new Exception();

            }
            if (blog.image.ContentType != "image/png" && blog.image.ContentType != "image/jpeg")
            {
                throw new Exception();
            }
            string path = "C:\\Users\\hesen\\OneDrive\\İş masası\\pustokclas\\WebApplication6\\wwwroot\\";
            string url = Helper.GetFileName(path, "upload", blog.image);
            blog.imageurl = url;
            _blogrep.Create(blog);
            await _blogrep.CommitAsync();
        }



        public async void DeleteAsync(int id)
        {
            var Wontedblog = await _blogrep.GetById(x => x.Id == id && x.Isdeleted == false);
            if (Wontedblog == null) throw new Exception();
            Wontedblog.Isdeleted = true;
            await _blogrep.CommitAsync();
        }

        public async Task<Blog> GetAsync(int id)
        {
            var Wontedblog = await _blogrep.GetById(x => x.Id == id && x.Isdeleted == false);
            if (Wontedblog == null) throw new Exception();
            return Wontedblog;
        }

        public async Task<List<Blog>> GetBlogs()
        {
            return await _blogrep.GetAll();

        }

        public async Task Update(Blog blog)
        {
            Blog exitesblog = await _blogrep.GetById(x => x.Id == blog.Id);
            if (exitesblog == null) throw new Exception();

            if (blog.image != null)
            {
                if (blog.image != null)
                {
                    string folderPath = "manage";
                    string pathh = "C:\\Users\\hesen\\OneDrive\\İş masası\\pustokclas\\WebApplication6\\wwwroot\\";
                    string delpath = Path.Combine(pathh, folderPath, exitesblog.imageurl);
                    if (File.Exists(delpath))
                    {
                        File.Delete(delpath);
                    }
                    if (blog.image.Length > 1048576) throw new Exception();
                    if (blog.image.ContentType != "image/png" && blog.image.ContentType != "image/jpeg")
                    {
                        throw new Exception();
                    }
                }
                string path = "C:\\Users\\hesen\\OneDrive\\İş masası\\pustokclas\\WebApplication6\\wwwroot\\";
                string url = Helper.GetFileName(path, "upload", blog.image);
                blog.imageurl = url;

                exitesblog.image = blog.image;
                exitesblog.Description = blog.Description;
                exitesblog.Title = blog.Title;


                await _blogrep.CommitAsync();

            }
        }
    }
}
