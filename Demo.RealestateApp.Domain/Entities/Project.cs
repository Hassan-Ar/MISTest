using Demo.RealestateApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Domain.Entities
{
    public class Project : Product
    {
        public Guid Id { get; set; }
        public bool ContainsBuildings { get; set; }

        #region NavigationProperties
        public virtual List<Building>? Buildings { get; set; }
        [ForeignKey(nameof(Address))]
        public Guid AddressId { get; set; }
        public virtual Address ProductAddress { get; set; }
        public virtual List<Image>? Images { get; set; }

        #endregion

    }
}
