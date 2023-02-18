using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_deloitte
{   
    internal class NumOrText
    {
        private int num;
        private string text;
        private bool numerical;

        public NumOrText(int num)
        {
            this.num = num;
            this.numerical = true;
            this.text = "";
        }

        public NumOrText(string text)
        {
            this.text = text;
            this.numerical = false;
            this.num = 0;
        }

        public void setNum(int num)
        { 
            if(numerical)
                this.num = num;
        }
        public void setText(string text) 
        {
            if(!numerical)
                this.text = text;
        }

        public bool isNumerical()
        {
            return numerical;
        }

        public int getNum()
        {
            return num;
        }

        public string getText()
        {
            return text;
        }
    }
}
