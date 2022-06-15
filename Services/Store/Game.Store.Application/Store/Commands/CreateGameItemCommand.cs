using AutoMapper;
using FluentValidation;
using Game.Store.Application.Contracts;
using Game.Store.Domain.Entities;
using GameStore.Infrastructure.Dtos;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game.Store.Application.Store.Commands
{
    public class CreateGameItemCommand : IRequest<ActionResponse<int>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Category { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public decimal Price { get; set; }
    }

    public class CreateGameItemCommandValidator : AbstractValidator<CreateGameItemCommand>
    {
        public CreateGameItemCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{Name} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{Name} must not exceed 50 characters.");


        }
    }
    public class CreateGameItemCommandHandler : IRequestHandler<CreateGameItemCommand, ActionResponse<int>>
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateGameItemCommandHandler> _logger;

        public CreateGameItemCommandHandler(IStoreRepository storeRepository, IMapper mapper, ILogger<CreateGameItemCommandHandler> logger)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ActionResponse<int>> Handle(CreateGameItemCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<GameItem>(request);

            var result = await _storeRepository.AddAsync(entity);
            _logger.LogInformation($"Game {entity.Id} is successfully created.");

            return ActionResponse<int>.Success(entity.Id, 200);
        }
    }
}
