using Microsoft.EntityFrameworkCore;
using R.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R.DAL.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Candidate> Сandidates { get; set; }

        public DbSet<Interviewer> Interviewers { get; set; }

        public DbSet<Interview> Interviews { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var candidates = new Candidate[]
            {
                    new Candidate
                    {
                        Id = 1,
                        Name = "Dmytro",
                        Surname = "Melnyk",
                        Stack = ".Net",
                        Level = "Junior Strong"
                    },
                    new Candidate
                    {
                        Id = 2,
                        Name = "Slavko",
                        Surname = "Zozuk",
                        Stack = "Js, React",
                        Level = "Junior"
                    },
                    new Candidate
                    {
                        Id = 3,
                        Name = "Liubomyr",
                        Surname = "Liuklian",
                        Stack = "NodeJs",
                        Level = "Middle"
                    }
            };

            modelBuilder.Entity<Candidate>().HasData(
                    candidates
                );

            var interviewer1 = new Interviewer
            {
                Id = 1,
                Name = "Taras",
                Surname = "Shevchenko",
                Stack = ".Net",
                Level = "TL"
            };

            var interviewer2 = new Interviewer
            {
                Id = 2,
                Name = "Nazar",
                Surname = "Leshnevskiy",
                Stack = "Js",
                Level = "Senior Strong Architector"
            };

            modelBuilder.Entity<Interviewer>().HasData(
                    interviewer1,
                    interviewer2
                );
            modelBuilder.Entity<Interview>().HasData(
                    new Interview
                    {
                        Id = 1,
                        StartDate = DateTime.Parse("25/12/2022 10:30:00"),
                        EndDate = DateTime.Parse("25/12/2022 11:30:00"),
                        InterviewerId = 1,
                        CandidatId = 1
                    },
                    new Interview
                    {
                        Id = 2,
                        StartDate = DateTime.Parse("20/12/2022 12:30:00"),
                        EndDate = DateTime.Parse("20/12/2022 13:30:00"),
                        InterviewerId = 2,
                        CandidatId = 2
                    },
                    new Interview
                    {
                        Id = 3,
                        StartDate = DateTime.Parse("22/12/2022 15:00:00"),
                        EndDate = DateTime.Parse("22/12/2022 16:00:00"),
                        InterviewerId = 2,
                        CandidatId = 3
                    }
                );
        }
    }
}
