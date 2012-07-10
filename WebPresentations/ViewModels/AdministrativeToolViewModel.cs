using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace WebPresentations.ViewModels
{
    public class AdministrativeToolViewModel
    {
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public bool IsApproved { get; set; }
        public string Role { get; set; }
        public bool IsOnline { get; set; }
        public DateTime LastActivityDate { get; set; }
        public IEnumerable<String> RolesList { get; set; }
    }
}