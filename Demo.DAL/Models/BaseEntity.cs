using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Models
{
   public class BaseEntity
    {

        public int Id { get; set; }  // Pk

        public int CreatedBy { get; set; } // contain userId created this Data

        public DateTime? CreatedOn { get; set; } // Time of Created

        public int LastModifiedBy { get; set; }// contain userId Modified this Data

        public DateTime? LastModifiedOn { get; set; }//  contain Time Modified this Data[Automatic calaculated]

        public bool IsDeleted { get; set; } = false; // soft deleted
    }
}
