using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using R5T.T0249;


namespace R5T.H0001.Entities
{
    [EntityMarker]
    public class ProjectFilePathList : IEntityMarker
    {
        [Key]
        public int ID { get; set; }

        public ICollection<ProjectFilePathListMapping> Mappings { get; set; }
    }
}
