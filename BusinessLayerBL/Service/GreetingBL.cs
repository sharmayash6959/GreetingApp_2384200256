using BusinessLayerBL.Interface;


namespace BusinessLayerBL.Service
{
    public class GreetingBL : IGreetingBL
    {
        public GreetingBL()
        {
        }

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
        
    }
    
}
