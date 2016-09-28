using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
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

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ThemeController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        private IUserService UserService1
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }

        private IAuthenticationManager AuthenticationManager1
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ThemeController(IThemeService ser, IPostService postserv)
        {
            service = ser;
            postService = postserv;
        }

        // GET: Theme
        public ActionResult Index()
        {
            var themes = ThemePOMapper.Map(service.GetAllTheme().ToList());
            return View(themes);
        }

        [HttpPost]
        [HandleError(View = "Error")]
        public ActionResult Details(PostPO post)
        {
            if (post.MainText != null)
            {
                return RedirectToAction("CreatePost", post);
            }
            return View();
        }

        // GET: Theme/Details/5
        [HttpGet]
        public ActionResult Details(int id, PostPO post)
        {
                ViewBag.ThemeId = id;
              //  post.ThemeId = id;
              //  post.UserId = User.Identity.GetUserId();
                if (service.FindById(ViewBag.ThemeId) == null)
                {
                    return RedirectToAction("Index");
                }
                var temp1 = service.GetPosts(service.FindById(ViewBag.ThemeId));
                var posts = PostPOMapper.Map(temp1);
                var temp = service.FindById(id);
                ThemePO theme = new ThemePO() { ThemeId = id, Header = temp.Header, MainText = temp.MainText, Posts = posts };
                return View(theme);
        }

        // GET: Theme/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        { 
            return View("CreateTheme");
        }

        // POST: Theme/Create
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async System.Threading.Tasks.Task<ActionResult> Create(ThemeModel theme)
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
                        return View("Error", new ErrorModel() { ErrorMessge = "Can't create theme." });
                }
                return View("Error", new ErrorModel() { ErrorMessge = "Can't create theme." });
        }


        [HttpGet]
        public ActionResult CreatePost(PostPO post)
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
                return View("Error", new ErrorModel() { ErrorMessge = "Can't create post"});
            }
        }


        // GET: Theme/Delete/5
        public ActionResult Delete(int id)
        {
            string tempid = User.Identity.GetUserId();
            if (User.IsInRole("admin"))
            {
                ViewBag.ThemeId = id;
                ThemePO theme = ThemePOMapper.Map(service.FindById(ViewBag.ThemeId));
                return View("Delete", theme);
            }
            else {
                    return View("Error", new ErrorModel() { ErrorMessge = "You are not admin"});
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
                return View("Error", new ErrorModel() { ErrorMessge = "Can't delete theme"});
            }
        }
    }
}
