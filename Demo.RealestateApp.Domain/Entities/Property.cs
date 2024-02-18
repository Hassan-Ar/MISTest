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
    public class Property : Product
    {
        [Key]
        public Guid Id { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfWindows { get; set; }
        public int NumberOfBeeds { get; set; }
        

        #region NavigationPrperties

        [ForeignKey(nameof(building))]
        public Guid? BuildingId { get; set; }
        public virtual Building? building { get; set; }

        [ForeignKey(nameof(Address))]
        public Guid AddressId { get; set; }
        public virtual Address ProductAddress { get; set; }
        public virtual List<Image>? Images { get; set; }
        #endregion
    }
}
