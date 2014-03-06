using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Processes
{

    public class ProcessOutputExtractior : BaseProcessOutputExtractior
    {

        public ProcessOutputExtractior()
        {
        }

        public IEnumerable<string> OutputReadLines()
        {

            return myOutputStreamExtractor.ReadLines();

        }

        public IEnumerable<string> OutputReadLines(int MaxOf)
        {

            return myOutputStreamExtractor.ReadLines(MaxOf);

        }

        public void OutputReadInto(ICollection<string> TheExistingCollection)
        {

            myOutputStreamExtractor.ReadInto(TheExistingCollection);

        }

        public void OutputReadInto(ICollection<string> TheExistingCollection, int MaxOf)
        {

            myOutputStreamExtractor.ReadInto(TheExistingCollection, MaxOf);

        }

        public void OutputReadInto(Queue<string> TheExistingCollection)
        {

            myOutputStreamExtractor.ReadInto(TheExistingCollection);

        }

        public void OutputReadInto(Queue<string> TheExistingCollection, int MaxOf = 0)
        {

            myOutputStreamExtractor.ReadInto(TheExistingCollection, MaxOf);

        }

        public void OutputReadInto(Action<string> TheAction)
        {

            myOutputStreamExtractor.ReadInto(TheAction);

        }

        public void OutputReadInto(Action<string> TheAction, int MaxOf = 0)
        {

            myOutputStreamExtractor.ReadInto(TheAction, MaxOf);

        }

        public IEnumerable<string> ErrorReadLines()
        {

            return myErrorStreamExtractor.ReadLines();

        }

        public IEnumerable<string> ErrorReadLines(int MaxOf)
        {

            return myErrorStreamExtractor.ReadLines(MaxOf);

        }

        public void ErrorReadInto(ICollection<string> TheExistingCollection)
        {

            myErrorStreamExtractor.ReadInto(TheExistingCollection);

        }

        public void ErrorReadInto(ICollection<string> TheExistingCollection, int MaxOf)
        {

            myErrorStreamExtractor.ReadInto(TheExistingCollection, MaxOf);

        }

        public void ErrorReadInto(Queue<string> TheExistingCollection)
        {

            myErrorStreamExtractor.ReadInto(TheExistingCollection);

        }

        public void ErrorReadInto(Queue<string> TheExistingCollection, int MaxOf = 0)
        {

            myErrorStreamExtractor.ReadInto(TheExistingCollection, MaxOf);

        }

        public void ErrorReadInto(Action<string> TheAction)
        {

            myErrorStreamExtractor.ReadInto(TheAction);

        }

        public void ErrorReadInto(Action<string> TheAction, int MaxOf = 0)
        {

            myErrorStreamExtractor.ReadInto(TheAction, MaxOf);

        }

    }

}
