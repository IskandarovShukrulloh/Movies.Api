using System.ComponentModel.DataAnnotations;

namespace Movies.Api.DTOs;

public class CreateGenreDto
{
    [Required]
    [StringLength(50)]
    public required string Name { get; set; }
}
