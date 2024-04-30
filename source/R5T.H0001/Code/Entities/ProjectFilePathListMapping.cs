using System;
using System.ComponentModel.DataAnnotations;

using R5T.T0249;


namespace R5T.H0001.Entities
{
    [EntityMarker]
    public class ProjectFilePathListMapping : IEntityMarker
    {
        [Key]
        public int ID { get; set; }

        public int? ProjectFilePathListID { get; set; }
        public ProjectFilePathList ProjectFilePathList { get; set; }

        public int? ProjectFilePathID { get; set; }
        public ProjectFilePath ProjectFilePath { get; set; }
    }
}
