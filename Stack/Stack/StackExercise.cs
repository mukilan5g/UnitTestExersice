using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Stack
{
    public class StackExercise 
    {
        string[] elements;
        int state;

        public StackExercise()
        {
            elements = new string[10];
            state = -1;
        }

        public void Push(string name)
        {
            try
            {
                if (name != null)
                {

                    if (IsEmpty() == true)
                    {
                        state = state + 1;
                    }
                    elements[state] = name;
                    state++;
                }
            }
            catch (IndexOutOfRangeException e)
            {
                throw e;
            }
        }

        public string Pop()
        {
            try
            {
                string pop = elements[state - 1];
                state = state - 2;
                return pop;

            }
            catch (IndexOutOfRangeException e)
            {
                throw e;
            }
        }

        public string Top()
        {
            try
            {
                return elements[state-1];
            }
            catch (IndexOutOfRangeException e)
            {
                throw e;
            }
        }

        public bool IsEmpty()
        {
            if (state == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
