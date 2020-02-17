using CSharpDB.Model;
using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDB.Context
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    class DBCContext : DbContext
    {
        public DBCContext(): base("CsharpPrjDB")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<TestResults> TestResultss { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<QuestionList> QuestionLists { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<RelationFirstHalf> RelationFirstHalves { get; set; }
        public DbSet<RelationSecondHalf> RelationSecondHalves { get; set; }
        public DbSet<InputAnswer> InputAnswers { get; set; }
        public DbSet<ChooseAnswer> ChooseAnswers { get; set; }
    }
}
