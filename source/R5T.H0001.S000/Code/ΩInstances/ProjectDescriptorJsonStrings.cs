using System;


namespace R5T.H0001.S000
{
    public class ProjectDescriptorJsonStrings : IProjectDescriptorJsonStrings
    {
        #region Infrastructure

        public static IProjectDescriptorJsonStrings Instance { get; } = new ProjectDescriptorJsonStrings();


        private ProjectDescriptorJsonStrings()
        {
        }

        #endregion
    }
}
