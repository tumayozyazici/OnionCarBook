using MediatR;
using OnionCarBook.Application.Features.Mediator.Commands.ReviewCommands;
using OnionCarBook.Application.Interfaces;
using OnionCarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class UpdateReviewCommandHandler :IRequestHandler<UpdateReviewCommand>
    {
        private readonly IRepository<Review> _repository;

        public UpdateReviewCommandHandler(IRepository<Review> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.ReviewID);
            values.ReviewDate = request.ReviewDate;
            values.CustomerName = request.CustomerName;
            values.CustomerImage = request.CustomerImage;
            values.CarID = request.CarID;
            values.Comment = request.Comment;
            await _repository.UpdateAsync(values);
        }
    }
}
