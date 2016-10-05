using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.PresentationMapper;
using BLL.DTO;
using MVC.Models;
using BLL.Infrastructure;
using BLL.Interfaces;
using Microsoft.AspNet.Identity.Owin;
using BLL.Intrfaces;
using Microsoft.Owin.Security;
using MVC.PresentationEntity;
using Microsoft.AspNet.Identity;

namespace MVC.Controllers
{
    public class ThemeController : Controller
    {
        IThemeService service;
        IPostService postService;

        public ThemeController(IThemeService ser, IPostService postserv)
        {
            service = ser;
            postService = postserv;
        }

        // GET: Theme
        public ActionResult Index()
        {
            try
            {
                var themes = ThemePOMapper.Map(service.GetAllTheme().ToList());
                return View(themes);
            }
            catch (BLLException)
            {
                return View("Error");
            }
        }
        



        [HttpPost]
        [HandleError(View = "Error")]
        public ActionResult Details(PostPO post)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return RedirectToAction("CreatePost", post);
                }
                return RedirectToAction("Details", "Theme", new { id = post.ThemeId });
            }
            catch (BLLException)
            {
                return View("Error");
            }
        }

        // GET: Theme/Details/5
        [HttpGet]
        public ActionResult Details(int id, PostPO post)
        {
            try
            {
                ViewBag.ThemeId = id;
                if (service.FindById(ViewBag.ThemeId) == null)
                {
                    return RedirectToAction("Index");
                }
                var temp = service.FindById(id);
                var temp1 = service.GetPosts(temp);
                var posts = PostPOMapper.Map(temp1.ToList());

                ThemePO theme = new ThemePO() { ThemeId = id, Header = temp.Header, MainText = temp.MainText, Posts = posts };
                return View(theme);
            }
            catch (BLLException)
            {
                return View("Error");
            }
        }




        [HttpPost]
        [HandleError(View = "Error")]
        public ActionResult Posts(int id)
        {
            try
            {
                ViewBag.ThemeId = id;
                if (service.FindById(ViewBag.ThemeId) == null)
                {
                    return RedirectToAction("Index");
                }
                var temp = service.FindById(id);
                var temp1 = service.GetPosts(temp);
                var posts = PostPOMapper.Map(temp1.ToList());

                ThemePO theme = new ThemePO() { ThemeId = id, Header = temp.Header, MainText = temp.MainText, Posts = posts };
                return PartialView("Posts", theme);
            }
            catch (BLLException)
            {
                return View("Error");
            }
        }

        


        [HttpGet]
        public ActionResult Posts(int id, PostPO post)
        {
            try
            {
                ViewBag.ThemeId = id;
                if (service.FindById(ViewBag.ThemeId) == null)
                {
                    return RedirectToAction("Index");
                }
                var temp = service.FindById(id);
                var temp1 = service.GetPosts(temp);
                var posts = PostPOMapper.Map(temp1.ToList());

                ThemePO theme = new ThemePO() { ThemeId = id, Header = temp.Header, MainText = temp.MainText, Posts = posts };
                return PartialView("Posts", theme);
            }
            catch (BLLException)
            {
                return View("Error");
            }
        }



        // GET: Theme/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            try
            {
                return View("CreateTheme");
            }
            catch (BLLException)
            {
                return View("Error");
            }
        }



        // POST: Theme/Create
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async System.Threading.Tasks.Task<ActionResult> Create(ThemeModel theme)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ThemeDTO themeDto = new ThemeDTO()
                    {
                        Header = theme.Header,
                        MainText = theme.MainText,
                    };

                    OperationDetails operationDetails = await service.Create(themeDto);
                    if (operationDetails.Succedeed)
                        return RedirectToAction("Index");
                    else
                        return View("Error");
                }
                return View("Error");
            }
            catch catch (BLLException)
            {
                return View("Error");
            }
        }




        [HttpGet]
        public ActionResult CreatePost(PostPO post)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PostDTO postDto = new PostDTO()
                    {
                        ThemeId = post.ThemeId,
                        MainText = post.MainText,
                        UserId = User.Identity.GetUserId()
                    };
                    postService.Create(postDto);
                }
                return RedirectToAction("Details", "Theme", new { id = post.ThemeId });
            }
            catch (BLLException)
            {
                return View("Error");
            }
        }




        [HttpPost]
        [Authorize]
        public ActionResult CreatePost(PostModel post)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PostDTO postDto = new PostDTO()
                    {
                        ThemeId = post.ThemeId,
                        MainText = post.MainText,
                        UserId = User.Identity.GetUserId()
                    };
                    postService.Create(postDto);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }




        // GET: Theme/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                string tempid = User.Identity.GetUserId();
                if (User.IsInRole("admin"))
                {
                    ViewBag.ThemeId = id;
                    ThemePO theme = ThemePOMapper.Map(service.FindById(ViewBag.ThemeId));
                    return View("Delete", theme);
                }
                else
                {
                    return View("Error");
                }
            }
            catch (BLLException)
            {
                return View("Error");
            }
        }




        // POST: Theme/Delete/5
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                service.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }




        // GET: Theme/Delete/5
        public ActionResult DeletePost(int id, int themeId)
        {
            try
            {
                string tempid = User.Identity.GetUserId();

                ViewBag.PostId = id;
                PostPO post = PostPOMapper.Map(postService.GetById(id));
                return View("DeletePost", post);
            }
            catch (BLLException)
            {
                return View("Error");
            }
        }





        // POST: Theme/Delete/5
        [HttpPost]
        public ActionResult DeletePost(int id, int themeId, FormCollection collection)
        {
            try
            {
                postService.Delete(id);

                return RedirectToAction("Details", "Theme", new { id = themeId });
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
