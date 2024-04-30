using System;


namespace R5T.H0001.DB01
{
    public static class Instances
    {
        public static IConnectionStrings ConnectionStrings => H0001.ConnectionStrings.Instance;
    }
}