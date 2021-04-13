using System;
using System.ComponentModel.DataAnnotations;

namespace BQMS.Api.Models
{
    public class Request
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        [Required]
        public Guid SubcategoryId { get; set; }

        public string ReferenceNumber { get; set; }
    }
}
