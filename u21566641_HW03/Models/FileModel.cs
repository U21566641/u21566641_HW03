using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace u21566641_HW03.Models
{
    public class FileModel
    {
        [Display (Name ="File Name")]
        public String FileName { get; set; }

    }
}