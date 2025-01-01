using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Add a Category")]
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        [Display(Name = "Visualization order")]
        [Range(1,10, ErrorMessage = "Value need to be between 1 to 10")]
        public int? Order { get; set; }
    }
}
