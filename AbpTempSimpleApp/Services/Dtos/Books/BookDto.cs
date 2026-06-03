using System;
using Volo.Abp.Application.Dtos;
using AbpTempSimpleApp.Entities.Books;

namespace AbpTempSimpleApp.Services.Dtos.Books;

public class BookDto : AuditedEntityDto<Guid>
{
    public string Name { get; set; }

    public string Description { get; set; } = string.Empty;

    public BookType Type { get; set; }

    public DateTime PublishDate { get; set; }

    public float Price { get; set; }
}
