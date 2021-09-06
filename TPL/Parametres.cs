using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPL
{
    class Parametres
    {
        public int Sentenses { get; set; }
        public int Symbols { get; set; }
        public int Words { get; set; }
        public int QuestionMarks { get; set; }
        public int Exclamations { get; set; }

        //Task task = Task.Run(() => );
        public void FindSent(string str)
        {
            int count = 0;
            if (str.Contains(' '))
            {
                count++;
            }
        }
        //public void FindSymb(string str)
        //{
        //    int count = 0;
        //    if ()
        //    {
        //        count++;
        //    }
        //}
        public void FindWords(string str)
        {
            string trimmed_text = str.Trim();
            string[] split_text = trimmed_text.Split(' ');
            int space_count = 0;
            string new_text = "";
            foreach (string av in split_text)
            {
                if (av == "")
                {
                    space_count++;
                }
                else
                {
                    new_text = new_text + av + ",";
                }
            }
            new_text = new_text.TrimEnd(',');
            split_text = new_text.Split(',');
        }
        public void FindQuestMarks(string str)
        {
            int count = 0;
            if (str.Contains('?'))
            {
                count++;
            }
        }
        public void FindExclam(string str)
        {
            int count = 0;
            if (str.Contains('!'))
            {
                count++;
            }
        }
    }
}
