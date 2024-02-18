using Demo.RealestateApp.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Domain.Common
{
    public class Image : BaseEntity
    {
        public Guid Id { get; set; }
        [NotMapped]
        public IFormFile File { get; set; } 
        public string FileName { get; set; } = string.Empty;
        public string FileExtension { get; set; } = string.Empty; 
        public long? FileSizeInBytes { get; set; }
        public string FilePath { get; set; } = string.Empty;

        #region Nav
        [ForeignKey(nameof(Project))]
        public Guid? projectId { get; set; }
        public Project? project { get; set; }
        [ForeignKey(nameof(Building))]
        public Guid? BuildingId { get; set; }
        public Building? building { get; set; }
        [ForeignKey(nameof(Property))]
        public Guid? PropertyId { get; set; }
        public Property? property { get; set; }

        #endregion




    }
}
