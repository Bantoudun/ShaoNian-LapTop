using ASPNetMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ASPNetMVC.Controllers
{
    public class ApiBaseController : ApiController
    {
        protected string ModuleName = string.Empty;
        [HttpGet]
        public virtual IHttpActionResult GetSubjects()
        {
            try
            {
                string[] lines = null;
                List<EducationGroup> subjects = new List<EducationGroup>();
                string path = string.Format("{0}App_Data\\{1}\\{2}index.txt", HttpRuntime.AppDomainAppPath, ModuleName, ModuleName);
                if (File.Exists(path))
                    lines = File.ReadAllLines(path, System.Text.Encoding.Default);
                if (lines != null)
                {
                    EducationGroup currentGroup = null;
                    foreach (string item in lines)
                    {
                        if (string.IsNullOrEmpty(item)) continue;
                        int seperatorIndex = item.IndexOf("/");
                        if (seperatorIndex > 0)
                        {
                            if (currentGroup == null)
                            {
                                EducationGroup educationGroup = new EducationGroup();
                                educationGroup.Index = subjects.Count + 1;
                                subjects.Add(educationGroup);
                                currentGroup = educationGroup;
                            }
                            if (currentGroup != null)
                            {
                                Topic topic = new Topic();
                                topic.Index = item.Substring(seperatorIndex + 1, item.Length - seperatorIndex - 1);
                                topic.Title = item.Substring(0, seperatorIndex);
                                currentGroup.Topics.Add(topic);
                            }
                        }
                        else
                        {
                            EducationGroup educationGroup = new EducationGroup();
                            educationGroup.Index = subjects.Count + 1;
                            educationGroup.Title = item;
                            subjects.Add(educationGroup);
                            currentGroup = educationGroup;
                        }
                    }
                }
                else
                {
                    EducationGroup educationGroup = new EducationGroup();
                    educationGroup.Index = subjects.Count + 1;
                    educationGroup.Title = "No available!";
                    subjects.Add(educationGroup);
                }
                return Ok(subjects);
            }
            catch(Exception)
            {
                return NotFound();
            }
        }

        protected string GetTopicContent(int id)
        {
            string topicContent = string.Empty;
            string path = string.Format("{0}App_Data\\{1}\\{2}{3}.html", System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath, ModuleName, ModuleName, id.ToString());
            if (File.Exists(path))
                topicContent = File.ReadAllText(path, System.Text.Encoding.Default);
            return topicContent;
        }

        [HttpGet]
        public virtual IHttpActionResult GetTopic(int id)
        {
            return Ok(GetTopicContent(id));
        }
    }
}