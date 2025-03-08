using ModelLayer.Model;
using RepositoryLayer.UserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerBL.Interface
{
    public interface IGreetingBL
    {
        public string SimpleGreeting(string firstName, string lastName);
        public GreetingEntity SaveGreeting(RequestModel request);

        public string GetGreetingById(int id);
    }
    
    
}
