using System;

using R5T.T0131;

using R5T.T0238;


namespace R5T.H0001.S000
{
    [ValuesMarker]
    public partial interface IProjectDescriptors : IValuesMarker
    {
        private static readonly Lazy<ProjectDescriptor> zN_001 = new(() =>
            Instances.JsonOperator.Load_FromString<ProjectDescriptor>(
                Instances.ProjectDescriptorJsonStrings.N_001));

        public ProjectDescriptor N_001 => zN_001.Value;
    }
}
