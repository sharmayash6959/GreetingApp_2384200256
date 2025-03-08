using BusinessLayerBL.Interface;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Model;
using NLog;



namespace HelloGreetingApplication.Controllers
{

    

    /// <summary>
    /// Class providing API for HelloGreeting
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class HelloGreetingController : ControllerBase
    {

        [HttpGet("Greeting3")]
        public IActionResult SimpleGreeting(string? firstName, string? lastName)
        {
            logger.Info($"Get request received with Firstname: {firstName}, Lastname: {lastName}");

            string message = _greet.SimpleGreeting(firstName, lastName);

            ResponseModel<string> responseModel = new ResponseModel<string>()
            {
                Success = true,
                Message = "Greet Message generated",
                Data = message
            };
            return Ok(responseModel);
        }
        public IGreetingBL _greet;
        
        public HelloGreetingController(ILogger<HelloGreetingController> logger,IGreetingBL greet, IGreetingBL greetingBL)
        {
            _greet = greet;
            _greetingBL = greetingBL;

        }

        [HttpGet]
        [Route("GetHello1")]
        public string GetHello(string firstName, string lastName) => _greet.SimpleGreeting(firstName, lastName);



        /// <summary>
        /// Logs captured by logger instance
        /// </summary>

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Get method to get a Greeting Message
        /// </summary>
        /// <returns>"Hello, World!"</returns>
        [HttpGet]
        [Route("Get method created2")]
        public IActionResult Get()
        {
            logger.Info("Get request recieved");

            ResponseModel<string> responseModel = new ResponseModel<string>();  
            try
            {
                
                responseModel.Success = true;
                responseModel.Message = "Hello to Greeting App API Endpoint";
                responseModel.Data = "Hello, World!";
                return Ok(responseModel);
            }

            catch (Exception ex) 
            {
                responseModel.Success = false;
                responseModel.Message = "Here is an exception";
                responseModel.Data = "Exception occured";
            }
            return BadRequest(responseModel);
        }

        /// <summary>
        /// Save greeting to database for UC4
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns>the data that is provided by user with user id[key]</returns>
        private readonly IGreetingBL _greetingBL;

        

        /// <summary>
        /// Saves a greeting message to the database.
        /// </summary>
        /// <param name="greeting">The greeting data from the client.</param>
        /// <returns>Returns HTTP 200 OK if successful, otherwise BadRequest.</returns>
        [HttpPost("save")]
        public IActionResult SaveGreeting([FromBody] RequestModel request)
        {
            if (request.value == null)
            {
                return BadRequest("Greeting data cannot be null.");
            }

            try
            {
                var savedGreet = _greetingBL.SaveGreeting(request);
                return Ok(new ResponseModel<string>
                {
                    Success = true,
                    Message = "Greeting saved successfully!" ,
                    Data = $"Id : {savedGreet.Id}, Message : { savedGreet.Message}"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "Internal Server Error", Details = ex.Message });
            }
        }

        /// <summary>
        /// Post method to add data
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Post method created")]
        public IActionResult Post(RequestModel requestModel) 
        {
            logger.Info($"POST request recieved with key: {requestModel.key}, value: {requestModel.value}");
            ResponseModel<string> responseModel = new ResponseModel<string>();

            try
            {
                responseModel.Success = true;
                responseModel.Message = "Request recieved successfully";
                responseModel.Data = $"key: {requestModel.key}, Value: {requestModel.value}";
                return Ok(responseModel);

            }
            catch (Exception ex)
            {
                responseModel.Success = false;
                responseModel.Message = "Request failed";
                responseModel.Data = null;
                return BadRequest(responseModel);
            }
        }

        /// <summary>
        /// Put method to update data
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Put method created")]
        public IActionResult Put(RequestModel requestModel) 
        {
            logger.Info($"PUT request recieved. Updating greeting to : {requestModel.key}, {requestModel.value}");

            ResponseModel<string> responseModel = new ResponseModel<string>();
            try 
            {
                responseModel.Success = true;
                responseModel.Message = "Data updated successfully";
                responseModel.Data = $"key: {requestModel.key}, Value: {requestModel.value}";
                return Ok(responseModel);
            }
            catch(Exception ex)
            {
                responseModel.Success = false;
                responseModel.Message = "Request failed";
                responseModel.Data = null;
                return BadRequest(responseModel);
            }
            
        }

        /// <summary>
        /// Patch method to update features
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("Patch method created")]
        public IActionResult Patch(RequestModel requestModel)
        {
            logger.Info($"PATCH request recieved. Modifying greeting with: {requestModel.key}, {requestModel.value}");

            ResponseModel<string> responseModel = new ResponseModel<string>();
            try
            {
                responseModel.Success = true;
                responseModel.Message = "Feature updated successfully";
                responseModel.Data = $"key: {requestModel.key}, Value: {requestModel.value}";
                return Ok(responseModel);
            }
            catch (Exception ex)
            {
                responseModel.Success = false;
                responseModel.Message = "Request failed";
                responseModel.Data = null;
                return BadRequest(responseModel);
            }
        }

        /// <summary>
        /// Delete method to delete data
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete method created")]
        public IActionResult Delete(RequestModel requestModel)
        {
            logger.Info($"DELETE request recieved. Removing greeting for key: {requestModel.key}, value: {requestModel.value}");

            ResponseModel<string> responseModel = new ResponseModel<string>();
            try
            {
                responseModel.Success = true;
                responseModel.Message = "Deleted successfully";
                responseModel.Data = "";
                return Ok(responseModel);
            }
            catch (Exception ex)
            {
                responseModel.Success = false;
                responseModel.Message = "Request failed";
                responseModel.Data = null;
                return BadRequest(responseModel);
            }
        }

        /// <summary>
        /// Get method to get a Greeting Message
        /// </summary>
        /// <returns>"Hello, World!"</returns>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetGreetingById(int id)
        {
            //logger.Info("Get request recieved");

            //ResponseModel<string> responseModel = new ResponseModel<string>();
            //try
            //{

            //    responseModel.Success = true;
            //    responseModel.Message = "Hello to Greeting App API Endpoint";
            //    responseModel.Data = "Hello, World!";
            //    return Ok(responseModel);
            //}

            //catch (Exception ex)
            //{
            //    responseModel.Success = false;
            //    responseModel.Message = "Here is an exception";
            //    responseModel.Data = "Exception occured";
            //}
            return Ok(id);
        }

    }

}
