using System.Collections.Generic;

namespace AdvancedGenericsInterfaces
{
    public interface IRepository<TModel> where TModel : Model
    {
        void Add(TModel model);
        TModel GetById(int id);
        List<TModel> GetAll();
        void Update(TModel model);
        void Delete(int id);
    }
}
