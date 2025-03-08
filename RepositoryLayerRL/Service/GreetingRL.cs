
using RepositoryLayerRL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model;
using RepositoryLayer.UserEntity;
using RepositoryLayer.Context;


namespace RepositoryLayer.Service
{
    public class GreetingRL : IGreetingRL
    {
        private readonly AppDbContext _dbContext;

        public GreetingRL(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string GetGreetingById(int id)
        {
            var greeting = _dbContext.AllGreetings.FirstOrDefault(g => g.Id == id);
            if (greeting == null)
            {
                return "Greeting not found"; // or handle accordingly if you want to return a different response or throw an exception
            }
            return greeting.Message;
        }

        public GreetingEntity SaveGreeting(RequestModel request)
        {
            var greeting = new GreetingEntity {Message = request.value};
            _dbContext.Add(greeting);
            _dbContext.SaveChanges();
            return greeting;
        }
    }

}
