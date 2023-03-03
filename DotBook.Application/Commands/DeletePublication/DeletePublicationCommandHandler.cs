using NetBook.Core.Repositories;
using MediatR;

namespace NetBook.Application.Commands.DeletePublication
{
    public class DeletePublicationCommandHandler : IRequestHandler<DeletePublicationCommand, Unit>
    {
        private readonly IPublicationRepository _publicationRepository;
        public DeletePublicationCommandHandler(IPublicationRepository publicationRepository)
        {
            _publicationRepository = publicationRepository;
        }

        public async Task<Unit> Handle(DeletePublicationCommand request, CancellationToken cancellationToken)
        {
            var publication = await _publicationRepository.GetByIdAsync(request.Id);

            publication.Disabled();

            await _publicationRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
