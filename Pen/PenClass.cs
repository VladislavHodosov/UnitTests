using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pen
{
    public class PenClass
    {

        // how much ink in the pen
        private int inkContainerValue = 1000;

        // the size of the letters, which are written by pen
        private double sizeLetter = 1.0;

        // color of pen
        private String color = "BLUE";

        public PenClass(int inkContainerValue)
        {
            this.inkContainerValue = inkContainerValue;
        }

        public PenClass(int inkContainerValue, double sizeLetter)
        {
            this.inkContainerValue = inkContainerValue;
            this.sizeLetter = sizeLetter;
        }

        public PenClass(int inkContainerValue, double sizeLetter, String color)
        {
            this.inkContainerValue = inkContainerValue;
            this.sizeLetter = sizeLetter;
            this.color = color;
        }

        public String write(String word)
        {
            if (!isWork())
            {
                return "";
            }
            //Bug4
            //should fix
            //if(word.Contains(" "))
            //{                
            //    var countsOfSpaces = word.Length - word.Replace(" ", "").Length;
            //    inkContainerValue = inkContainerValue + countsOfSpaces;
            //}            
            double sizeOfWord = word.Length * sizeLetter;
            if (sizeOfWord <= inkContainerValue)
            {
                inkContainerValue = Convert.ToInt32(inkContainerValue - sizeOfWord);
                return word;
                String partOfWord = word.Substring(0, inkContainerValue);
            }
            else
            {
                //bug2,3
                ////should fix
                //var partOfWord = (inkContainerValue - sizeLetter) < 0
                //? ""
                //: word.Substring(0, (int)(inkContainerValue/sizeLetter));
                String partOfWord = word.Substring(0, inkContainerValue);
                inkContainerValue = 0;
                return partOfWord;
            }
        }

        public String getColor()
        {
            return "BLUE";
            //Bug1
            //should fix
            //return color;
        }

        public Boolean isWork()
        {
            return inkContainerValue > 0;
        }
        public void doSomethingElse()
        {
            StreamWriter fileOutput = new StreamWriter("1.txt", false);
            fileOutput.WriteLine(color);
            Console.WriteLine(color);
            fileOutput.Close();
        }
    }

}