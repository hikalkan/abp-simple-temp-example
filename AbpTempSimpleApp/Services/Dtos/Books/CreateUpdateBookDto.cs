using System;
using System.ComponentModel.DataAnnotations;
using AbpTempSimpleApp.Entities.Books;

namespace AbpTempSimpleApp.Services.Dtos.Books;

public class CreateUpdateBookDto
{
    [Required]
    [StringLength(128)]
    public string Name { get; set; } = string.Empty;

    [StringLength(2000)]
    [DataType(DataType.MultilineText)]
    public string Description { get; set; } = string.Empty;

    [Required]
    public BookType Type { get; set; } = BookType.Undefined;

    [Required]
    [DataType(DataType.Date)]
    public DateTime PublishDate { get; set; } = DateTime.Now;

    [Required]
    public float Price { get; set; }
}
