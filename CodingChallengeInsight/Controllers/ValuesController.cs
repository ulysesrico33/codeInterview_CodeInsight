using System;
using System.Collections.Generic;
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
        [HttpGet("readXML/{option}")]
        public String GetXML_A(int option)
        {
            String res;
            
            List<String> lst= new List<String>();
            if (option == 1)
                res = _challenge.readXML_IterateEachNode();
            else if(option==2)
                res = _challenge.readXML_UsingPathXML();
            else
                res = _challenge.readLINQ();
            
            return res;
        }

        
        

        
        
    }
}
