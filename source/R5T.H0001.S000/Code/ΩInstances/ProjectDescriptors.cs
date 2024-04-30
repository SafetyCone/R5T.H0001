using System;


namespace R5T.H0001.S000
{
    public class ProjectDescriptors : IProjectDescriptors
    {
        #region Infrastructure

        public static IProjectDescriptors Instance { get; } = new ProjectDescriptors();


        private ProjectDescriptors()
        {
        }

        #endregion
    }
}
