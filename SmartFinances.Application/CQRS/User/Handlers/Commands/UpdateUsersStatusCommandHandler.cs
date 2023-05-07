using AutoMapper;
using MediatR;
using SmartFinances.Application.CQRS.User.Requests.Commands;
using SmartFinances.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.CQRS.User.Handlers.Commands
{
    public class UpdateUsersStatusCommandHandler : IRequestHandler<UpdateUsersStatusCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateUsersStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(UpdateUsersStatusCommand request, CancellationToken cancellationToken)
        {
            var applicationUser = await _unitOfWork.Users.GetByIdAsync(request.UsersStatusDto.Id);

            if (applicationUser != null)
            {
                applicationUser = _mapper.Map(request.UsersStatusDto, applicationUser);

                _unitOfWork.Users.Update(applicationUser);
                await _unitOfWork.SaveAsync();
            }

            return;
        }
    }
}
