using System;
using CodingChallengeInsight.Business;
using Microsoft.AspNetCore.Mvc;

namespace CodingChallengeInsight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private Challenge _challenge;

        public ValuesController(Challenge challenge)
        {
            _challenge = challenge;
        }

        [HttpGet]
        public String Get()
        {
            return "Please enter /api/values/getScore/'your input' to play";

        }


        // GET api/values
        [HttpGet("getScore/{input}")]
        public String GetScore(String input)
        {
 
            return "The Total score is "+_challenge.getScore(input).ToString();
        }

        // GET api/values/5
        [HttpGet("readXML_A")]
        public String GetXML_A()
        {
            return _challenge.readXML_A();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
