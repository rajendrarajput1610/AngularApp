using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AngularApp.Models
{
    public class Links
    {
        public int Id { get; set; }
        
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }

        [StringLength(50)]
        public string LinkName { get; set; }

        [StringLength(50)]
        public string LinkValue { get; set; }

        public bool LinkStatus { get; set; }

        public List<Links> Children { get; set; }

        public Links()
        {
            Children = new List<Links>();
        }
    }
}