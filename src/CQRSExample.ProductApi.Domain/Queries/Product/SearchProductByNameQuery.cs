using System.Linq;
using MediatR;

namespace CQRSExample.ProductApi.Domain.Queries.Product
{
    public class SearchProductByNameQuery : IRequest<IQueryable<Model.Product>>
    {
        public SearchProductByNameQuery(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
