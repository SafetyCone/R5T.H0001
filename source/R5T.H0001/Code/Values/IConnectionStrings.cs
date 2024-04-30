using System;

using R5T.T0131;


namespace R5T.H0001
{
    [ValuesMarker]
    public partial interface IConnectionStrings : IValuesMarker
    {
        /// <summary>
        /// <para><value>"Server=(localdb)\\MSSQLLocalDB;Database=R5T.H0001.DB01;Trusted_Connection=True;MultipleActiveResultSets=true"</value></para>
        /// </summary>
        public string DB01 => "Server=(localdb)\\MSSQLLocalDB;Database=R5T.H0001.DB01;Trusted_Connection=True;MultipleActiveResultSets=true";

        /// <inheritdoc cref="DB01"/>
        public string Local_Development => this.DB01;
    }
}
