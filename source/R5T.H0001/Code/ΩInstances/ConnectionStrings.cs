using System;


namespace R5T.H0001
{
    public class ConnectionStrings : IConnectionStrings
    {
        #region Infrastructure

        public static IConnectionStrings Instance { get; } = new ConnectionStrings();


        private ConnectionStrings()
        {
        }

        #endregion
    }
}
