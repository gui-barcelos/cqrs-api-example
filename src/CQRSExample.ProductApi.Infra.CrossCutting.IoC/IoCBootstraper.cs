using AutoMapper;
using FluentValidation;
using MediatR;
using MediatR.Pipeline;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Linq;
using CQRSExample.ProductApi.Business.Interfaces;
using CQRSExample.ProductApi.Business.Mapper;
using CQRSExample.ProductApi.Business.Services;
using CQRSExample.ProductApi.Domain.CommandHandler;
using CQRSExample.ProductApi.Domain.Commands.Product;
using CQRSExample.ProductApi.Domain.Commands.ProductOption;
using CQRSExample.ProductApi.Domain.Interfaces.UnitOfWork;
using CQRSExample.ProductApi.Domain.Model;
using CQRSExample.ProductApi.Domain.Queries.Product;
using CQRSExample.ProductApi.Domain.Queries.ProductOption;
using CQRSExample.ProductApi.Domain.QueryHandler.Product;
using CQRSExample.ProductApi.Domain.Repository.Interfaces;
using CQRSExample.ProductApi.Domain.Validations;
using CQRSExample.ProductApi.Domain.Validations.Product;
using CQRSExample.ProductApi.Infra.Data.Context;
using CQRSExample.ProductApi.Infra.Data.Repository;
using CQRSExample.ProductApi.Infra.Data.UnitOfWork;

namespace CQRSExample.ProductApi.Infra.CrossCutting.IoC
{
    public static class IoCBootstraper
    {
        public static Container GetContainer()
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // AutoMapper
            var autoMapperConfiguration = AutoMapperConfiguration.GetConfiguration();

            container.RegisterSingleton<MapperConfiguration>(autoMapperConfiguration);
            container.Register<IMapper>(() => autoMapperConfiguration.CreateMapper(container.GetInstance), Lifestyle.Scoped);

            // Application
            container.Register<IProductService, ProductService>(Lifestyle.Scoped);
            container.Register<IProductOptionService, ProductOptionService>(Lifestyle.Scoped);

            // Domain - Command Handlers
            container.Register<IRequestHandler<CreateProductCommand>, ProductCommandHandler>(Lifestyle.Scoped);
            container.Register<IRequestHandler<UpdateProductCommand>, ProductCommandHandler>(Lifestyle.Scoped);
            container.Register<IRequestHandler<DeleteProductCommand>, ProductCommandHandler>(Lifestyle.Scoped);
            container.Register<IRequestHandler<CreateProductOptionCommand>, ProductOptionCommandHandler>(Lifestyle.Scoped);
            container.Register<IRequestHandler<UpdateProductOptionCommand>, ProductOptionCommandHandler>(Lifestyle.Scoped);
            container.Register<IRequestHandler<DeleteProductOptionCommand>, ProductOptionCommandHandler>(Lifestyle.Scoped);

            // Domain - Query Handlers
            container.Register<IRequestHandler<GetAllProductsQuery, IQueryable<Product>>, ProductsQueryHandler>(Lifestyle.Scoped);
            container.Register<IRequestHandler<SearchProductByNameQuery, IQueryable<Product>>, ProductsQueryHandler>(Lifestyle.Scoped);
            container.Register<IRequestHandler<GetProductByIdQuery, Product>, ProductsQueryHandler>(Lifestyle.Scoped);
            container.Register<IRequestHandler<GetAllProductOptionsQuery, IQueryable<ProductOption>>, ProductOptionQueryHandler>(Lifestyle.Scoped);
            container.Register<IRequestHandler<GetProductOptionQuery, ProductOption>, ProductOptionQueryHandler>(Lifestyle.Scoped);

            // Repository
            container.Register<ProductsContext>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<IProductRepository, ProductRepository>(Lifestyle.Scoped);
            container.Register<IProductOptionRepository, ProductOptionRepository>(Lifestyle.Scoped);

            // Bus
            container.RegisterSingleton<IMediator, Mediator>();
            container.RegisterSingleton(new SingleInstanceFactory(container.GetInstance));
            container.RegisterSingleton(new MultiInstanceFactory(container.GetAllInstances));

            container.RegisterCollection(typeof(IPipelineBehavior<,>), Enumerable.Empty<Type>());
            container.RegisterCollection(typeof(IRequestPreProcessor<>), Enumerable.Empty<Type>());
            container.RegisterCollection(typeof(IRequestPostProcessor<,>), Enumerable.Empty<Type>());

            container.RegisterCollection(typeof(IValidator<>), new[] { typeof(CreateProductCommandValidation).Assembly });
            container.RegisterDecorator(typeof(IRequestHandler<,>), typeof(ValidatorHandler<,>));
            container.RegisterDecorator(typeof(IRequestHandler<>), typeof(ValidatorHandler<>));

            return container;
        }
    }
}
