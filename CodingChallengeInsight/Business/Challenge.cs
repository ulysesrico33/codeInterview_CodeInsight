using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace CodingChallengeInsight.Business
{
    public class Challenge
    {
        public Challenge()
        {

        }


        private XmlDocument xmldoc = new XmlDocument();
        private const String strXmlPath= "File/XmlProduct.xml";

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
            int groupCount=0;
            int total =0;
            bool garbage = false;
            int exclamationCounter = 0;
            List<String> Contentgarbage= new List<String>();

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
                    //Checking if garbage is ahead
                    if ((x + 1) <= charArray.Length - 1)
                    {
                        if ((charArray[x] == '{')&&(charArray[x + 1] == '<'))
                            garbage = true;
                    }
                        //Second position of the array and on
                    if ((charArray[x] == '{') && (charArray[x - 1] != ','))
                    {
                        groupCount++;
                        if(garbage==false)
                            total += groupCount;
                    }
                    if ((charArray[x] == '{') && (charArray[x - 1] == ','))
                    {
                        if(garbage==false)
                            total += groupCount;


                    }

                    //cases with <GARBAGE>
                    //Not to count
                    //1) < > garbage
                    //everything coming after "!" is cancelled,  with "!!"
                    //that cancels the cancellation, then it counts

                    if (charArray[x] == '<')
                    {
                        //Checking if the index is not out of the boundaries
                        //This check is just if the garbage is important to be breaken down
                        if ((x - 2) >= 0)
                        {
                            //Checking if the <garbage> is inside a {group} 
                            if ((charArray[x - 2] == ',') || charArray[x - 2] == '{')
                                garbage = true;

                            continue;

                        }
                    }

                    //If {<garbage>} is this way, it has to be seen
                    if (garbage)
                    {
                        

                        Contentgarbage.Add(charArray[x].ToString());

                        //Once the garbage is ended
                        if (charArray[x] == '>')
                        {
                            foreach(var item in Contentgarbage)
                            {
                                if (item == "!")
                                    exclamationCounter++;
                            }

                            if ((exclamationCounter == 2)||(exclamationCounter==0))
                            {
                                total += groupCount;
                            }

                            Contentgarbage.Clear();
                            exclamationCounter = 0;
                            garbage = false;
                           
                        }


                    }

                }
            }

            return total;
        }


        /// <summary>
        /// Read an XML file by iteration with a for(x...)
        /// </summary>
        /// <returns></returns>
        public string readXML_IterateEachNode()
        {
            try
            {
                
                XmlNodeList xmlNode;
                FileStream fs = new FileStream(strXmlPath, FileMode.Open, FileAccess.Read);
                xmldoc.Load(fs);
                xmlNode = xmldoc.GetElementsByTagName("Product");
                String str = "";
                for (int i = 0; i <= xmlNode.Count - 1; i++)
                {
                    
                    str +="|"+ xmlNode[i].ChildNodes.Item(0).InnerText.Trim() + "," +
                          xmlNode[i].ChildNodes.Item(1).InnerText.Trim() + " ," +
                          xmlNode[i].ChildNodes.Item(2).InnerText.Trim();

                }

                return str;
            }
            catch (Exception e)
            {
                return "ERROR: "+e.ToString();
            }

            
        }

        /// <summary>
        /// Read an XML by Using XMLDocument and PathXML
        /// </summary>
        /// <returns></returns>
        public String readXML_UsingPathXML()
        {
            
            xmldoc.Load(strXmlPath);
            XmlNodeList nodeList = xmldoc.DocumentElement.SelectNodes("/Table/Product");
            string proID = "", proName = "", price = "",str="";
            foreach (XmlNode node in nodeList)
            {
                proID = node.SelectSingleNode("Product_id").InnerText;
                proName = node.SelectSingleNode("Product_name").InnerText;
                price = node.SelectSingleNode("Product_price").InnerText;
                str = str + "\n"+proID + " " + proName + " " + price;
            }

            return str;
        }
    }
}
