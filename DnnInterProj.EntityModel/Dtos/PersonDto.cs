using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnnInterProj.EntityModel.Model;

namespace DnnInterProj.EntityModel.Dtos
{
    public class PersonDto
    {

        /// <summary>
        /// UserName Field of type string. This the requierd field
        /// Max lenght 50 caharcter
        /// </summary>

        public string UserName { get; set; }
        /// <summary>
        /// Name Field of type string. This the requierd field
        /// Max lenght 50 caharcter
        /// </summary>

        public string Name { get; set; }

        /// <summary>
        /// Lastname Field of type string. This the requierd field
        /// Max lenght 50 caharcter
        /// </summary>

        public string LastName { get; set; }

        /// <summary>
        /// Email Field of type string. This the requierd field
        /// Max lenght 50 caharcter
        /// This should obey the email format
        /// </summary>

        public string Email { get; set; }

        public string Age { get; set; }

        /// <summary>
        /// Picture Field of type array of binary. This an optional field
        /// </summary>
        public byte[] picture { get; set; }
    }
}
