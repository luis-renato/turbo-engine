using turbo_engine.Data.VO;
using turbo_engine.Model;

namespace turbo_engine.Business
{
    public interface IPersonBusiness
    { 
        PersonVO Create(PersonVO person);
        PersonVO FindByID(long id);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO person);
        PersonVO Disable(long id);
        void Delete(long id);
    }
}
