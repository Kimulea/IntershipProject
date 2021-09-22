using System.ComponentModel.DataAnnotations;

namespace Bloomcoding.Common.Models.Pagination
{
    public class FiltersOptions
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "page number start with 1")]
        public int PageNumber { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "out of range page size")]
        public int PageSize { get; set; }

    }
}
