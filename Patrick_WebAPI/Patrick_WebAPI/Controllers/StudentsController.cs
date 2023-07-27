using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Patrick_WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentsController : ControllerBase
	{
		[HttpGet]
		//GET: localhost:7185/api/Students
		public ActionResult GetAllStudent()
		{
			string[] studentNames= new string[] { "Ankit", "Amit" ,"Shikhar" , "Anubhav" , "Abhisar"};
			return Ok(studentNames);
		}
	}
}
