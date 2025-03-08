using RepositoryLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model;
using RepositoryLayer.UserEntity;

namespace RepositoryLayerRL.Interface
{
    public interface IGreetingRL
    {
        public GreetingEntity SaveGreeting(RequestModel request);

        public string GetGreetingById(int id);
    }
}
