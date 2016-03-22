using ASPNetMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ASPNetMVC.Controllers
{
    public class ApiLuntangController : ApiBaseController
    {
        public ApiLuntangController()
        {
            this.ModuleName = "Luntang";
        }

        private List<Follow> GetFollows(int id)
        {
            List<Follow> follows = new List<Follow>();
            Follow follow1 = new Follow();
            follow1.UserId = 1 + id;
            follow1.UserName = "John";
            follow1.Content = "follow1";
            follows.Add(follow1);
            Follow follow2 = new Follow();
            follow2.UserId = 2 + id;
            follow2.UserName = "Peter";
            follow2.Content = "follow2";
            follows.Add(follow2);
            Follow follow3 = new Follow();
            follow3.UserId = 3 + id;
            follow3.UserName = "Andrew";
            follow3.Content = "follow3";
            follows.Add(follow3);
            return follows;
        }

        [HttpGet]
        public override IHttpActionResult GetTopic(int id)
        {
            string topicContent = base.GetTopicContent(id);
            LunTangTopic lunTangTopic = new LunTangTopic();
            lunTangTopic.EduArticle = topicContent;
            lunTangTopic.Follows = GetFollows(id);
            return Ok(lunTangTopic);
        }
    }
}