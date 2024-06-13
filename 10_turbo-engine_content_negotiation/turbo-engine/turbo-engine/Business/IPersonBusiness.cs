using turbo_engine.Data.VO;

namespace turbo_engine.Business
{
    public interface IPersonBusiness
    { 
        PersonVO Create(PersonVO person);
        PersonVO FindByID(long id);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO person);
        void Delete(long id);
    }
}
