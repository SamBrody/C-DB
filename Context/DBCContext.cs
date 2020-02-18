using CSharpDB.Model;
using CSharpProjCore.Model;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;

namespace CSharpDB.Context
{
    class DBCContext : DbContext
    {
        //Объявление сущностей
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<TestResults> TestResultss { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<RelationFirstHalf> RelationFirstHalves { get; set; }
        public DbSet<RelationSecondHalf> RelationSecondHalves { get; set; }
        public DbSet<InputAnswer> InputAnswers { get; set; }
        public DbSet<ChooseAnswer> ChooseAnswers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserStudent> UserStudents { get; set; }

        //Конструктор контекста, где создается БД
        public DBCContext()
        {
            Database.EnsureCreated();
        }

        //Настройка строки подключения к БД
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(@"server=localhost;database=CSharpProj;user=root;password=Sam19brody96117$emyon");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Описание связей и ключей таблиц (fluent api)
            //Описание связей для сущности UserProfile
            modelBuilder.Entity<UserProfile>().HasMany(p => p.TestResults).WithOne(b => b.UserProfile).HasForeignKey(p => p.IDUserProfile).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<UserProfile>().HasOne<User>(p => p.User).WithOne(b => b.UserProfile).HasForeignKey<UserProfile>(p => p.IDUser).OnDelete(DeleteBehavior.Cascade);

            //Описание связей для сущности UserStudents
            modelBuilder.Entity<UserStudent>().HasOne(p => p.Group).WithMany(b => b.UserStudents).HasForeignKey(p => p.IDGroup).OnDelete(DeleteBehavior.Cascade);

            //Описание связей для сущности User
            modelBuilder.Entity<User>().HasOne(p => p.Role).WithMany(b => b.Users).HasForeignKey(p => p.IDRole).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>().HasOne<UserProfile>(p => p.UserProfile).WithOne(b => b.User).HasForeignKey<UserProfile>(p => p.IDUser).OnDelete(DeleteBehavior.Cascade);

            //Описание связей для сущности Theme
            modelBuilder.Entity<Theme>().HasMany(p => p.Questions).WithOne(b => b.Theme).HasForeignKey(p => p.IDTheme).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Theme>().HasMany(p => p.Tests).WithOne(b => b.Theme).HasForeignKey(p => p.IDTheme).OnDelete(DeleteBehavior.Cascade);

            //Описание связей для сущности TestResults
            modelBuilder.Entity<TestResults>().HasOne(p => p.UserProfile).WithMany(b => b.TestResults).HasForeignKey(p => p.IDUserProfile).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<TestResults>().HasOne(p => p.Grade).WithMany(b => b.TestResults).HasForeignKey(p => p.IDGrade).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<TestResults>().HasOne(p => p.Test).WithMany(b => b.TestResults).HasForeignKey(p => p.IDTest).OnDelete(DeleteBehavior.Cascade);

            //Описание связей для сущности Test
            modelBuilder.Entity<Test>().HasOne(p => p.Theme).WithMany(b => b.Tests).HasForeignKey(p => p.IDTheme).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Test>().HasMany(p => p.Questions).WithOne(b => b.Test).HasForeignKey(p => p.IDTest).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Test>().HasMany(p => p.TestResults).WithOne(b => b.Test).HasForeignKey(p => p.IDTest).OnDelete(DeleteBehavior.Cascade);

            //Описание связей для сущности Role
            modelBuilder.Entity<Role>().HasMany(p => p.Users).WithOne(b => b.Role).HasForeignKey(p => p.IDRole).OnDelete(DeleteBehavior.Cascade);

            //Описание связей для сущности RelationSecondHalf
            modelBuilder.Entity<RelationSecondHalf>().HasOne<RelationFirstHalf>(p => p.RelationFirstHalf).WithOne(b => b.RelationSecondHalf).HasForeignKey<RelationSecondHalf>(p => p.IDRelationFirstHalf).OnDelete(DeleteBehavior.Cascade);

            //Описание связей для сущности RelationFirstHalf
            modelBuilder.Entity<RelationFirstHalf>().HasOne<RelationSecondHalf>(p => p.RelationSecondHalf).WithOne(b => b.RelationFirstHalf).HasForeignKey<RelationSecondHalf>(p => p.IDRelationFirstHalf).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RelationFirstHalf>().HasOne(p => p.Question).WithMany(b => b.RelationFirstHalfs).HasForeignKey(p => p.IDQuestion).OnDelete(DeleteBehavior.Cascade);

            //Описание связей для сущности QuestionType
            modelBuilder.Entity<QuestionType>().HasMany(p => p.Questions).WithOne(b => b.QuestionType).HasForeignKey(p => p.IDQType).OnDelete(DeleteBehavior.Cascade);

            //Описание связей для сущности Question
            modelBuilder.Entity<Question>().HasMany(p => p.ChooseAnswers).WithOne(b => b.Question).HasForeignKey(p => p.IDQuestion).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Question>().HasMany(p => p.RelationFirstHalfs).WithOne(b => b.Question).HasForeignKey(p => p.IDQuestion).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Question>().HasMany(p => p.InputAnswers).WithOne(b => b.Question).HasForeignKey(p => p.IDQuestion).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Question>().HasOne(p => p.QuestionType).WithMany(b => b.Questions).HasForeignKey(p => p.IDQType).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Question>().HasOne(p => p.Theme).WithMany(b => b.Questions).HasForeignKey(p => p.IDTheme).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Question>().HasOne(p => p.Test).WithMany(b => b.Questions).HasForeignKey(p => p.IDTest).OnDelete(DeleteBehavior.Cascade);

            //Описание связей для сущности InputAnswer
            modelBuilder.Entity<InputAnswer>().HasOne(p => p.Question).WithMany(b => b.InputAnswers).HasForeignKey(p => p.IDQuestion).OnDelete(DeleteBehavior.Cascade);

            //Описание связей для сущности Group
            modelBuilder.Entity<Group>().HasMany(p => p.UserStudents).WithOne(b => b.Group).HasForeignKey(p => p.IDGroup).OnDelete(DeleteBehavior.Cascade);

            //Описание связей для сущности Grade
            modelBuilder.Entity<Grade>().HasMany(p => p.TestResults).WithOne(b => b.Grade).HasForeignKey(p => p.IDGrade).OnDelete(DeleteBehavior.Cascade);

            //Описание связей для сущности ChooseAnswer
            modelBuilder.Entity<ChooseAnswer>().HasOne(p => p.Question).WithMany(b => b.ChooseAnswers).HasForeignKey(p => p.IDQuestion).OnDelete(DeleteBehavior.Cascade);

            //Начальные данные при создании БД
            modelBuilder.Entity<Role>().HasData(
                new Role[]
                {
                    new Role{IDRole=1, RoleName="teacher" },
                    new Role{IDRole=2, RoleName="student" },
                    new Role{IDRole=3, RoleName="guest" }
                });

            modelBuilder.Entity<User>().HasData(
                new User[]
                {
                    new User {IDUser=1,IDRole=1,Login="defTeacher", Password="17def02teacher2020"},
                    new User {IDUser=2,IDRole=1,Login="defTeacher", Password="17def02teacher2020"}
                });

            modelBuilder.Entity<UserProfile>().HasData(
                new UserProfile[]
                {
                    new UserProfile {IDUser=1,FirstName="teacher_f", LastName="teacher_l"}
                });

            modelBuilder.Entity<UserStudent>().HasData(
                new UserStudent[]
                {
                    new UserStudent {IDUser=2,FirstName="teacher_f", LastName="teacher_l", IDGroup=1}
                });

            modelBuilder.Entity<Group>().HasData(
                new Group[]
                {
                    new Group { IDGroup=1, GroupName="aaa" }
                });
        }
    }
}
