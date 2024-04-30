using System;


namespace R5T.H0001.S000
{
    public class Operator : IOperator
    {
        #region Infrastructure

        public static IOperator Instance { get; } = new Operator();


        private Operator()
        {
        }

        #endregion
    }
}
