using Demo.RealestateApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Domain.Entities
{
    public class Building : Product
    {
        [Key]
        public Guid Id { get; set; }
        public int NumberOfProperties { get; set; }
        public bool HasGarage { get; set; }
        public bool ContainsProperties { get; set; }



        #region NavigationProperties

        [ForeignKey(nameof(Project))]
        public Guid? ProjectId { get; set; }
        public virtual Project? project { get; set; }
        public virtual List<Property>? properties { get; set; }

        [ForeignKey(nameof(Address))]
        public Guid AddressId { get; set; }
        public virtual Address ProductAddress { get; set; }
        public virtual List<Image>? Images { get; set; }

        #endregion

    }
}
