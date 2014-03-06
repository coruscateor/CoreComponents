using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Text;

namespace CoreComponents.Data.SQL
{

    public class SQLCondition
    {

        protected SQLColumn myColumn;
        protected object myValue;
        protected ANSI_StandardOperators myOperator;
        protected StringBuilder mySB = new StringBuilder();

        public SQLCondition()
        {
        }

        public SQLColumn Column
        {

            get
            {

                return myColumn;

            }
            set
            {

                myColumn = value;

            }

        }

        public object Value
        {

            get
            {

                return myValue;

            }
            set
            {

                myValue = value;

            }

        }

        public ANSI_StandardOperators Operator
        {

            get
            {

                return myOperator;

            }
            set
            {

                myOperator = value;

            }

        }

        public override string ToString()
        {

            TextEntity.Clear(mySB);

            mySB.Append(myColumn.Resolve());

            TextEntity.AddSpace(mySB);

            switch (myOperator)
            {

                case ANSI_StandardOperators.Equals:

                    mySB.Append(ANSI_ConstStandardOperators.Equals);

                    break;
                case ANSI_StandardOperators.NotEquals:

                    mySB.Append(ANSI_ConstStandardOperators.NotEquals); 
                    
                    break;
                case ANSI_StandardOperators.GreaterThan:

                    mySB.Append(ANSI_ConstStandardOperators.GreaterThan); 
                    
                    break;
                case ANSI_StandardOperators.LessThan:

                    mySB.Append(ANSI_ConstStandardOperators.LessThan);

                    break;
                case ANSI_StandardOperators.GreaterThanOrEqualTo:

                    mySB.Append(ANSI_ConstStandardOperators.GreaterThanOrEqualTo);

                    break;
                case ANSI_StandardOperators.LessThanOrEqualTo:

                    mySB.Append(ANSI_ConstStandardOperators.LessThanOrEqualTo);
                    
                    break;
                case ANSI_StandardOperators.BETWEEN:

                    mySB.Append(ANSI_ConstStandardOperators.BETWEEN);
                    
                    break;
                case ANSI_StandardOperators.LIKE:

                    mySB.Append(ANSI_ConstStandardOperators.LIKE);
                    
                    break;
                case ANSI_StandardOperators.IN:

                    mySB.Append(ANSI_ConstStandardOperators.IN);
                    
                    break;

            }

            TextEntity.AddSpace(mySB);

            mySB.Append(myValue.ToString());

            return mySB.ToString();

        }

    }

}
