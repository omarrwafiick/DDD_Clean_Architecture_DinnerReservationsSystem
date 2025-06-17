using ApplicationLayer.Common.Interfaces.Repositories; 
using DomainLayer.DinnerAggregate;
using DomainLayer.DinnerAggregate.ValueObjects;
using FluentResults;
using MediatR;

namespace ApplicationLayer.Services.Dinners.Commands
{
    public class StartDinnerCommandHandler : IRequestHandler<StartDinnerCommand, Result<Dinner>>
    { 
        private readonly IGetRepository<Dinner, DinnerId> _dinnerRepository;
        private readonly IUpdateRepository<Dinner> _updateDinnerRepository;
        public StartDinnerCommandHandler( 
            IGetRepository<Dinner, DinnerId> dinnerRepository,
            IUpdateRepository<Dinner> updateDinnerRepository)
        { 
            _dinnerRepository = dinnerRepository;
            _updateDinnerRepository = updateDinnerRepository;
        } 
        public async Task<Result<Dinner>> Handle(StartDinnerCommand request, CancellationToken cancellationToken)
        {  
            var dinner = await _dinnerRepository.GetAsync(DinnerId.Create(Guid.Parse(request.DinnerId)), x => x.HostId.Value == Guid.Parse(request.HostId));  
            dinner.StartDinner(request.StartAt);
            await _updateDinnerRepository.UpdateAsync(dinner);
            return dinner;
        }
    }
}
