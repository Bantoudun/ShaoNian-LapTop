using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPNetMVC.Models
{
    public class EducationGroup
    {
        public int Index { get; set; }
        public string Title { get; set; }
        public List<Topic> Topics;
        public EducationGroup()
        {
            Topics = new List<Topic>();
        }
    }

    public class Topic
    {
        public string Index { get; set; }
        public string Title { get; set; }
    }

    public class Follow
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public DateTime FollowDate { get; set; }
        public string Content { get; set; }
    }

    public class LunTangTopic
    {
        public string EduArticle { get; set; }
        public List<Follow> Follows;
        public LunTangTopic()
        {
            Follows = new List<Follow>();
        }
    }
}