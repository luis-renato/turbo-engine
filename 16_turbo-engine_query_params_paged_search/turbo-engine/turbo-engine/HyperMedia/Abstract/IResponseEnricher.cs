using Microsoft.AspNetCore.Mvc.Filters;

namespace turbo_engine.HyperMedia.Abstract
{
    public interface IResponseEnricher
    {
        bool CanEnrich(ResultExecutingContext context);

        Task Enrich(ResultExecutingContext context);
    }
}
