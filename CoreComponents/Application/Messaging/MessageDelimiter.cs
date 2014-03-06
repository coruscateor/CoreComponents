using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Application.Messaging
{
    public class MessageDelimiter : IMessageLine
    {

        string myMessage;

        public MessageDelimiter(string DelimitingText, int Repetitions)
        {

            SetDelimitingText(DelimitingText, Repetitions);

        }

        public void SetDelimitingText(string DelimitingText, int Repetitions)
        {

            StringBuilder SB = new StringBuilder();

            for (int i = 1; i < Repetitions; i++)
            {

                SB.Append(DelimitingText);

            }

            myMessage = SB.ToString();

        }

        public override string ToString()
        {

            return myMessage;

        }

    }
}
