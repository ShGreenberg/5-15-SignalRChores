using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _5_15_SignalRTasks.data
{
    public class ChoresContext : DbContext
    {
        private string _connString;
        public ChoresContext(string connString)
        {
            _connString = connString;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Chore> Chores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connString);
        }
    }
}
