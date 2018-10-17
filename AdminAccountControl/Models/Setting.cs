using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminAccountControl.Models
{
    public class Setting
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RusTitles.Required)]
        [Display(Name = RusTitles.AdminEmail)]
        public string AdminEmail { get; set; }

        [Required(ErrorMessage = RusTitles.Required)]
        [Display(Name = RusTitles.RobotEmail)]
        public string RobotEmail { get; set; }

        [Required(ErrorMessage = RusTitles.Required)]
        [Display(Name = RusTitles.MailServer)]
        public string MailServer { get; set; }

        [Required(ErrorMessage = RusTitles.Required)]
        [Display(Name = RusTitles.MailAddress)]
        public string MailAddress { get; set; }

        public bool Description { get; set; }
        public bool IsInStock { get; set; }
        public bool Attachment { get; set; }

        public void Map(Setting setting)
        {
            AdminEmail = setting.AdminEmail;
            RobotEmail = setting.RobotEmail;
            MailServer = setting.MailServer;
            MailAddress = setting.MailAddress;

            Description = setting.Description;
            IsInStock = setting.IsInStock;
            Attachment = setting.Attachment;
        }
    }
}