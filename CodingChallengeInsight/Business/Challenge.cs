using System;
namespace CodingChallengeInsight.Business
{
    public class Challenge
    {
        public Challenge()
        {

        }


        /// <summary>
        /// getScore: Get the scores of the groups from the given input
        /// </summary>
        /// <returns></returns>
        public int getScore(String input)
        {
            // Example of input : {{{},{},{{}}}}
            //Assumptions for this algorithm:
            //1)The number of braces ({}) are pairs, so they all open and close.
            //2) Then the first "{" found means we have 1 group at least
            Char[] charArray = input.ToCharArray();
            int groupCount = 0;
            int total = 0;
            for (int x = 0; x <= charArray.Length - 1; x++)
            {
                //Checking if it's the first element of the array
                if (x == 0)
                {
                    //It's the first element of the array, therefore there's no
                    //prior element
                    if (charArray[x] == '{')
                    {
                        groupCount++;
                        total += groupCount;

                    }

                    
                }
                else
                {
                    //Second position of the array and on
                    if ((charArray[x] == '{') && (charArray[x - 1] != ','))
                    {
                        groupCount++;
                        total += groupCount;
                    }
                    if ((charArray[x] == '{') && (charArray[x - 1] == ','))
                    {
                        total += groupCount;
                    }

                    //cases with <>
                    //Not to count
                    //1) < > garbage
                    //everything coming after "!" is cancelled,  with "!!"
                    //that cancels the cancellation, then it counts

                    if (charArray[x] == '<')
                    {
                        //Checking if the index is not out of the boundaries
                        if ((x - 2) > 0)
                        {
                            if ((charArray[x - 2] == ',') || charArray[x - 2] == '{')
                            {
                                int u = 0;
                            }
                        }
                    }



                    

                }
            }

            return total;
        }
    }
}
