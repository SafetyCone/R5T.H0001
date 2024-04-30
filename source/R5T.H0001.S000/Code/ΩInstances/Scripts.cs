using System;


namespace R5T.H0001.S000
{
    public class Scripts : IScripts
    {
        #region Infrastructure

        public static IScripts Instance { get; } = new Scripts();


        private Scripts()
        {
        }

        #endregion
    }
}
