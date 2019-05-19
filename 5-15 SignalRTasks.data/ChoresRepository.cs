using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace _5_15_SignalRTasks.data
{
    public class ChoresRepository
    {
        private string _connString;
        public ChoresRepository(string connString)
        {
            _connString = connString;
        }

        public void AddChore(string name)
        {
            Chore chore = new Chore{Name = name, Status = Status.NotStarted};
            using(var ctx = new ChoresContext(_connString))
            {
                ctx.Chores.Add(chore);
                ctx.SaveChanges();
            }
        }

        public IEnumerable<Chore> GetChores()
        {
            using(var ctx = new ChoresContext(_connString))
            {
                return ctx.Chores.Include(c => c.User).ToList();
            }
        }

        public void ChangeStatus(Chore chore)
        {
            using(var ctx = new ChoresContext(_connString))
            {
                ctx.Database.ExecuteSqlCommand("UPDATE Chores SET Status = @status, UserId = @userid WHERE id = @id",
                        new SqlParameter("@status", chore.Status), new SqlParameter("@id", chore.Id),
                    new SqlParameter("@userid", GetUserByEmail(chore.User.Email).Id));
                ctx.SaveChanges();
            }
        }

        private User GetUserByEmail(string email)
        {
            using(var ctx = new ChoresContext(_connString))
            {
                return ctx.Users.FirstOrDefault(u => u.Email == email);
            }
        }
    }
}
