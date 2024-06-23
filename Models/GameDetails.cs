using System.ComponentModel.DataAnnotations;

namespace GameStore.FrontEnd.Models;


public class GameDetails
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Please enter name")]
    [StringLength(50)]
    public required string Name { get; set; }

    [Required]
    public string? GenreId { get; set; }

    public string GenreName { get; set; }

    [Range(1, 100)]
    public decimal Price { get; set; }

    public DateOnly ReleaseDate { get; set; }
}
