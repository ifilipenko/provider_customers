using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace ProviderCustomers.Models.Domain
{
    public class Site
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Description { get; set; }
        public int Rating { get; set; }
        public DateTime LastEdited { get; set; }
        public HostingPlan Plan { get; set; }
        public byte[] Logo { get; set; }
        public string LogoType { get; set; }

        public void SetLogo(HttpPostedFileBase file)
        {
            if (file == null || file.ContentLength <= 0) 
                return;

            Logo = new byte[file.ContentLength];
            file.InputStream.Read(Logo, 0, file.ContentLength);
            LogoType = Path.GetExtension(file.FileName);
            if (!string.IsNullOrWhiteSpace(LogoType) && LogoType.StartsWith("."))
            {
                LogoType = LogoType.Remove(0, 1);
            }
        }
    }
}