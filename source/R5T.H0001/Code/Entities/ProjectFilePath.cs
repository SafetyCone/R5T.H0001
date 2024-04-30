using System;
using System.ComponentModel.DataAnnotations;

using R5T.T0249;


namespace R5T.H0001.Entities
{
    [EntityMarker]
    public class ProjectFilePath : IEntityMarker
    {
        [Key]
        public int ID { get; set; }

        // Will be an alternate key.
        [MaxLength(450)] // Needs to have a finite max length to be usable as a key column.
        public string Value { get; set; }
    }
}
