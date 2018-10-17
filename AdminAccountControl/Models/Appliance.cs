using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.ApplicationInsights.WindowsServer.TelemetryChannel.Implementation;

namespace AdminAccountControl.Models
{
    public class Appliance
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RusTitles.Required)]
        [Display(Name = RusTitles.Title)]
        public string Title { get; set; }

        [Required(ErrorMessage = RusTitles.Required)]
        [Display(Name = RusTitles.Price)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = RusTitles.Required)]
        [Display(Name = RusTitles.CreatedDate)]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }

        [Display(Name = RusTitles.Description)]
        public string Description { get; set; }

        [Display(Name = RusTitles.IsInStock)]
        public bool? IsInStock { get; set; }

        [Display(Name = RusTitles.Attachment)]
        public string Attachment { get; set; }


        public void Map(Appliance appliance)
        {
            Title = appliance.Title;
            Price = appliance.Price;
            CreatedDate = appliance.CreatedDate;

            if(appliance.Description != null)
                Description = appliance.Description;

            if (appliance.IsInStock.HasValue)
                IsInStock = appliance.IsInStock;

            if (appliance.Attachment != null)
                Attachment = appliance.Attachment;
        }
    }
}