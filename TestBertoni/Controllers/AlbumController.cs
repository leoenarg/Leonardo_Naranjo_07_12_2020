using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestBertoni.Helper;
using TestBertoni.Models;

namespace TestBertoni.Controllers
{
    public class AlbumController : Controller
    {
        HttpClientHelper helper = new HttpClientHelper();
        
        public ActionResult Index()
        {
            List<Album> data = helper.GetAlbumsAsync().Result;
            return View(data);
        }

        public ActionResult Photos(int albumId)
        {
            List<Photo> data = helper.GetPhotosAsync(albumId).Result;
            return View(data);
        }

        
        public ActionResult Comments(int postId)
        {
            List<Comment> data = helper.GetCommentsAsync(postId).Result;
            return PartialView("_Comments",data);
        }
    }
}
