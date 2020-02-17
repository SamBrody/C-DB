using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDB.Model
{
    public class Test
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDTest { get; set; }
        public virtual ICollection<Question> Questions { get; }

        public int IDTheme { get; set; }
        public virtual Theme Theme { get; set; }
    }
}
