using Resume.DAL.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Models.Resume
{
    /// <summary>
    /// Owner Service
    /// </summary>
    public partial class OwnerService : BaseEntity
    {
        /// <summary>
        /// Gets or sets the titel
        /// </summary>
        public string Titel { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Picture
        /// </summary>
        public Picture Picture { get; set; }
    }
}
