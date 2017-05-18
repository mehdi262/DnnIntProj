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
    /// The basic class of the person.
    /// this class drived form EntityBase class
    /// <see cref="EntityBase"/>
    /// </summary>
    public class PersonBase : EntityBase
    {
        /// <summary>
        /// Username Field of type string. This the requierd field
        /// Max lenght 50 caharcter
        /// </summary>
        [Required(ErrorMessage = "UserName is Required")]
        [Display(Name = "User Name")]
        [StringLength(50)]
        //[Remote("UserAlreadyExistsAsync", "Account", ErrorMessage = "User with this Email already exists")]

        public string UserName { get; set; }
    }
}
