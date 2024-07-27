using Resume.DAL.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Models.Resume
{
    /// <summary>
    /// Job Detail
    /// </summary>
    public partial class JobDetail : BaseEntity
    {
        /// <summary>
        /// Gets or sets the jobtitel
        /// </summary>
        public string JobTitel { get; set; }

        /// <summary>
        /// Gets or sets the about me
        /// </summary>
        public string AboutMe { get; set; }

        /// <summary>
        /// Gets or sets the owner name
        /// </summary>
        public string OwnerName { get; set; }
    }
}
