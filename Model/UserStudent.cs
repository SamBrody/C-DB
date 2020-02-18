using CSharpDB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpProjCore.Model
{
    public class UserStudent:UserProfile
    {
        public int IDGroup { get; set; }
        public virtual Group Group { get; set; }
    }
}
