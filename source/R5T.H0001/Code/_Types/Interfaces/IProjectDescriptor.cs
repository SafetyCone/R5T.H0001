using System;


namespace R5T.H0001
{
    public interface IProjectDescriptor
    {
        public string Name { get; }
        public string Description { get; }
        public string Type { get; }

        public string FilePath { get; }

        public bool IsPrivate { get; }
    }
}
