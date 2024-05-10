using System;
using System.ComponentModel.DataAnnotations;

using R5T.T0249;


namespace R5T.H0001.Entities
{
	[EntityMarker]
	public class Project : IEntityMarker,
		IProjectDescriptor
	{
		[Key]
		public int ID { get; set; }

        // Will be an alternate key.
        public Guid Identity { get; set; }

		// Will be an alternate key.
		public int? ProjectFilePathID { get; set; }
		public ProjectFilePath ProjectFilePath { get; set; }
		string IProjectDescriptor.FilePath => this.ProjectFilePath.Value;

		public string Name { get; set; }
        public string Description { get; set; }
		public string Type { get; set; } // Use a string for now.
		
		public string GitHubRepositoryUrl { get; set; }
		public bool IsPrivate { get; set; }
		
		public int? ProjectReferencesListID { get; set; }
		public ProjectFilePathList ProjectReferencesList { get; set; }

    }
}