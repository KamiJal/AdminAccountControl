using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminAccountControl.Models
{
    public class ApplianceViewModel : IDisposable
    {
        private readonly ApplicationDbContext _context;

        public int Id { get; set; }

        [Required(ErrorMessage = RusTitles.Required)]
        [Display(Name = RusTitles.Title)]
        public string Title { get; set; }

        [Required(ErrorMessage = RusTitles.Required)]
        [Display(Name = RusTitles.Price)]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = RusTitles.Required)]
        [Display(Name = RusTitles.CreatedDate)]
        [DataType(DataType.DateTime)]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = RusTitles.Description)]
        public string Description { get; set; }

        [Display(Name = RusTitles.IsInStock)]
        public bool? IsInStock { get; set; }

        [Display(Name = RusTitles.Attachment)]
        public string Attachment { get; set; }

        public bool DescriptionEnabled { get; set; }
        public bool IsInStockEnabled { get; set; }
        public bool AttachmentEnabled { get; set; }

        public ApplianceViewModel() { }

        public ApplianceViewModel(int id)
        {
            _context = new ApplicationDbContext();

            if (id != 0)
            {
                var appliance = _context.Appliances.Single(q => q.Id == id);
                this.Map(appliance);
            }

            LoadRestrictions();
        }

        public void LoadRestrictions()
        {
            var setting = _context.Settings.Single();
            DescriptionEnabled = setting.Description;
            IsInStockEnabled = setting.IsInStock;
            AttachmentEnabled = setting.Attachment;
        }

        public void Map(Appliance appliance)
        {
            Id = appliance.Id;
            Title = appliance.Title;
            Price = appliance.Price;
            CreatedDate = appliance.CreatedDate;
            Description = appliance.Description;
            IsInStock = appliance.IsInStock;
            Attachment = appliance.Attachment;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}