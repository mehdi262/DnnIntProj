

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DnnInterProj.EntityModel.Model
{
    /// <summary>
    /// The EntityBase class is defined as abstract and is based class of our domain model.
    /// This will be used for implementing Repository Type Design Pattern.
    /// </summary>
    public abstract class EntityBase

    {
        /// <summary>
        /// The "Id" field is common field to all entities 
        /// Id is an Int64 data type.
        /// This is a requierd field and the primary key of all entities
        /// this is a database generated field
        /// </summary>

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Id is required field")]
        public Int64 Id { get; protected set; }

    }
}
