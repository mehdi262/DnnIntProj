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
    /// This the Person model Object which is inherite form PersonBase
    /// <seealso cref="PersonBase"/>
    /// </summary>
    [Table("Persons")]
    public class Person : PersonBase
    {
        /// <summary>
        /// Name Field of type string. This the requierd field
        /// Max lenght 50 caharcter
        /// </summary>
        [Required(ErrorMessage = "First Name is Required")]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Lastname Field of type string. This the requierd field
        /// Max lenght 50 caharcter
        /// </summary>
        [Required(ErrorMessage = "Last Name is Required")]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }

        /// <summary>
        /// Email Field of type string. This the requierd field
        /// Max lenght 50 caharcter
        /// This should obey the email format
        /// </summary>
        [Required(ErrorMessage = "Email is Required")]
        [Display(Name = "Email")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Display(Name = "The Person Age")]
        [Column(TypeName = "int")]
        public int Age { get; set; }

        /// <summary>
        /// JoinedDate Field of type DateTime. This the requierd field
        /// This field should be set while new object's creation process only
        /// </summary>
        [Display(Name = "Joined")]
        [Required]
        public DateTime JoinedDate { get; set; }

        /// <summary>
        /// Picture Field of type array of binary. This an optional field
        /// </summary>
        public byte[] picture { get; set; }
    }
}
