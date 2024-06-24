using turbo_engine.Model;

namespace turbo_engine.Repository
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person Disable(long id);
    }
}
