using System;
using System.Linq;
using AutoMapper;
using FluentValidation;
using MediatR;
using CQRSExample.ProductApi.Infra.CrossCutting.Common;

namespace CQRSExample.ProductApi.Business.Services
{
    public abstract class ServiceBase
    {
        protected readonly IMapper _mapper;
        protected readonly IMediator _mediator;

        public ServiceBase(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public string GetErrorMessage(Exception ex)
        {
            Log.LogError("ServiceBase Error", ex);

            var err = "";
            if (ex is ValidationException)
            {
                err = string.Join(" - ", ((ValidationException)ex).Errors.Select(e => e.ErrorMessage));
            }
            else
            {
                err = ex.Message;
            }

            return err;
        }
    }
}
