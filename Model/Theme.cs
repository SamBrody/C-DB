using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDB.Model
{
    public class Theme
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDTheme { get; set; }
        public string TextTheme { get; set; }

        public virtual ICollection<Question> Questions { get; }
        public virtual ICollection<Test> Tests { get; }
    }
}
