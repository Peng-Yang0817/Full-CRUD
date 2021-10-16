using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CURDLearn1016.Models.Extended
{
    [MetadataType(typeof(MyDataTableMetadate))]
    public class MyDataTable
    {
    }
    public class MyDataTableMetadate
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "PlZ Provide Name")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "PlZ Provide Sex")]
        public string Sex { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "PlZ Provide Age")]
        public string Age { get; set; }
    }
}