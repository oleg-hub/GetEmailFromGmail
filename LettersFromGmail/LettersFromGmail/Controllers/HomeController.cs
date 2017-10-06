using LettersFromGmail.Entity;
using LettersFromGmail.Models;
using LettersFromGmail.ViewModels;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Web.Mvc;
using System.Xml;

namespace LettersFromGmail.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           return View();
        }

        public ActionResult LettersList(ViewModels.IndexViewModel IndexViewModel)
        {
            WebClient objclient = new WebClient();
            string response = null;
            XmlDocument xdoc = new XmlDocument();
           List<LettersListViewModel> emailsList = new List<LettersListViewModel>();

            objclient.Credentials = new NetworkCredential(IndexViewModel.Login, IndexViewModel.Password);
            response = Encoding.UTF8.GetString(objclient.DownloadData("https://mail.google.com/mail/feed/atom"));  //"https://www.googleapis.com/gmail/v1/users/"+ IndexViewModel.Login +"/labels"
            response = response.Replace("<feed version=\"0.3\" xmlns=\"http://purl.org/atom/ns#\">", "<feed>");
            xdoc.LoadXml(response);

            foreach (XmlNode node1 in xdoc.SelectNodes("feed/entry"))
            {
                LettersListViewModel email = new LettersListViewModel
                { 
                From = node1.SelectSingleNode("author/email").InnerText,
                Title = node1.SelectSingleNode("title").InnerText,
                Summary = node1.SelectSingleNode("summary").InnerText
                };
                emailsList.Add(email);
            }
            return View(emailsList);
        }
    }
}