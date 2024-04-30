using System;


namespace R5T.H0001.S000
{
    public static class Instances
    {
        public static IConnectionStrings ConnectionStrings => H0001.ConnectionStrings.Instance;
        public static IFilePaths FilePaths => S000.FilePaths.Instance;
        public static L0066.IGuidOperator GuidOperator => L0066.GuidOperator.Instance;
        public static L0072.IJsonOperator JsonOperator => L0072.JsonOperator.Instance;
        public static IOperator Operator => S000.Operator.Instance;
        public static IProjectDescriptorJsonStrings ProjectDescriptorJsonStrings => S000.ProjectDescriptorJsonStrings.Instance;
        public static IProjectDescriptors ProjectDescriptors => S000.ProjectDescriptors.Instance;
        public static IProjectFilePaths ProjectFilePaths => S000.ProjectFilePaths.Instance;
    }
}