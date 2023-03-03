using NetBook.Core.Repositories;
using MediatR;

namespace NetBook.Application.Commands.UpdatePublication
{
    public class UpdatePublicationCommandHandler : IRequestHandler<UpdatePublicationCommand, Unit>
    {
        private readonly IPublicationRepository _publicationRepository;
        public UpdatePublicationCommandHandler(IPublicationRepository publicationRepository)
        {
            _publicationRepository = publicationRepository;
        }

        public async Task<Unit> Handle(UpdatePublicationCommand request, CancellationToken cancellationToken)
        {
            var publication = await _publicationRepository.GetByIdAsync(request.Id);

            publication.Update(request.Content);

            await _publicationRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
