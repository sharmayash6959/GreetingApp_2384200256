using BusinessLayerBL.Interface;
using ModelLayer.Model;
using RepositoryLayer.Service;
using RepositoryLayer.UserEntity;
using RepositoryLayerRL.Interface;


namespace BusinessLayerBL.Service
{
    public class GreetingBL : IGreetingBL
    {
        

        public string SimpleGreeting(string? firstName = null, string? lastName = null)
        {
            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                return $"Hello, {firstName} {lastName}";
            }
            else if (!string.IsNullOrEmpty(firstName))
            {
                return $"Hello, {firstName}";
            }
            else if (!string.IsNullOrEmpty(lastName))
            {
                return $"Hello, {lastName}";
            }
            else
            {
                return "Hello World";
            } 
        }

        private readonly IGreetingRL _greetingRL;

        public GreetingBL(IGreetingRL greetingRL)
        {
            _greetingRL = greetingRL ?? throw new ArgumentNullException(nameof(greetingRL));
        }

        public GreetingEntity SaveGreeting(RequestModel request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Greeting data cannot be null.");
            }
            
            return _greetingRL.SaveGreeting(request); 
        }

        public string GetGreetingById(int id)
        {
            return _greetingRL.GetGreetingById(id);
        }
    }

}
