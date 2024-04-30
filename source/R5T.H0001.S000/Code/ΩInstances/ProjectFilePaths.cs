using System;


namespace R5T.H0001.S000
{
    public class ProjectFilePaths : IProjectFilePaths
    {
        #region Infrastructure

        public static IProjectFilePaths Instance { get; } = new ProjectFilePaths();


        private ProjectFilePaths()
        {
        }

        #endregion
    }
}
