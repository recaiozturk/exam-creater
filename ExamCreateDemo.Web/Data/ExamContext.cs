using ExamCreateDemo.Web.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamCreateDemo.Web.Data
{
    public class ExamContext:DbContext
    {
        public ExamContext(DbContextOptions<ExamContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Exam> Exams { get; set; }
    }
}
