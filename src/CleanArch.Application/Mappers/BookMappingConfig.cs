using CleanArch.Application.Features.Book.Common;
using CleanArch.Domain.Book;

namespace CleanArch.Application.Mappers;

public class BookMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // Book => BookDto
        config.NewConfig<Book, BookDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Isbn, src => src.Isbn.Value)
            .Map(dest => dest.PublisherYear, src => src.PublishYear.Value);
    }
}