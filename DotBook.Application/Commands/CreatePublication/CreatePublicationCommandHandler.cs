using NetBook.Core.Entities;
using NetBook.Core.Repositories;
using MediatR;

namespace NetBook.Application.Commands.CreatePublication
{
    public class CreatePublicationCommandHandler : IRequestHandler<CreatePublicationCommand, int>
    {
        private readonly IPublicationRepository _publicationRepository;
        public CreatePublicationCommandHandler(IPublicationRepository publicationRepository)
        {
            _publicationRepository = publicationRepository;
        }

        public async Task<int> Handle(CreatePublicationCommand request, CancellationToken cancellationToken)
        {
            var publication = new Publication(request.Content, request.IdUser);

            await _publicationRepository.AddAsync(publication);

            await _publicationRepository.SaveChangesAsync();

            return publication.Id;
        }
    }
}
