
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

        public GreetingEntity SaveGreeting(RequestModel request)
        {
            var greeting = new GreetingEntity {Message = request.value};
            _dbContext.Add(greeting);
            _dbContext.SaveChanges();
            return greeting;
        }
    }

}
