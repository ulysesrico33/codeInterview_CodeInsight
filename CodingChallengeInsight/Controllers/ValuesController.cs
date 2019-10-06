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

        [HttpGet("solve27/{input}")]
        public String solveProblem27(String input)
        {
            /*
             * PROBLEM
             * 
            Given a string of round, curly, and square open and closing brackets,
            return whether the brackets are balanced(well-formed).

            For example, given the string "([])[]({})", you should return true.
            Given the string "([)]" or "((()", you should return false.
            */

            String res = "";
            try
            {
                /*States for symbols:
                 * 0:Not read yet
                 * 1:Open
                 * 2:Closed
                 * */

                int RoundBracklet = 0, SquareBracklet = 0, Brace = 0;
                   

                char[] charInput = input.ToCharArray();

                for (int i=0;i<= charInput.Length-1;i++)
                {
                    switch (charInput[i])
                    {
                        case '(':

                            RoundBracklet = 1;
                            break;
                        case '[':

                            SquareBracklet = 1;
                            break;
                        case '{':

                            Brace = 1;
                            break;

                         //Start closing cases
                        case ')':
                            if (charInput[i - 1] == '(')
                            {
                                RoundBracklet = 2;

                            }
                            else if (RoundBracklet==1)
                               {

                                if (Brace==2||SquareBracklet==2)
                                    RoundBracklet = 2;
                                

                                }
                              break;
                          
                        case ']':

                            if (charInput[i - 1] == '[')
                            {
                                SquareBracklet = 2;
                                

                            }else if(SquareBracklet==1)
                            {
                                if (RoundBracklet==2||Brace==2)
                                    SquareBracklet = 2;

                            }

                            break;
                        case '}':

                            if (charInput[i - 1] == '{')
                            {
                                Brace = 2;
                                

                            }
                            else if (Brace==1)
                            {
                                if (RoundBracklet==2||SquareBracklet==2)
                                    Brace = 2;
                                    
                            }
                            break;

                    }

                }


                if (RoundBracklet == 2 || SquareBracklet == 2 || Brace == 2)
                    res = "TRUE";
                else
                    res = "FALSE";

            }
            catch(Exception e)
            {

                res="This failed: " + e.ToString();
            }

            return res;

        }

        
        

        
        
    }
}
