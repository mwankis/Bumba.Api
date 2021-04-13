using System;

namespace BQMS.Api.Models
{
    public class Subcategory
    {
        public string Id { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
    }
}
