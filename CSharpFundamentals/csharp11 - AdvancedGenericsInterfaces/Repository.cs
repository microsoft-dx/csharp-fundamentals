using System.Collections.Generic;
using System.Linq;

namespace AdvancedGenericsInterfaces
{
    public class Repository<TModel> : IRepository<TModel> where TModel : Model, IUptadeable<TModel>
    {
        private List<TModel> Entities { get; set; }

        public void Add(TModel model)
        {
            Entities.Add(model);
        }

        public void Delete(int id)
        {
            var modelToDelete = Entities.FirstOrDefault(m => m.Id == id);

            if (modelToDelete != null)
                Entities.Remove(modelToDelete);
        }

        public TModel GetById(int id)
        {
            return Entities.FirstOrDefault(m => m.Id == id);
        }

        public List<TModel> GetAll()
        {
            return Entities;
        }

        public void Update(TModel model)
        {
            var modelToUpdate = Entities.FirstOrDefault(m => m.Id == model.Id);

            if (modelToUpdate != null)
                modelToUpdate.Update(model);
        }

        public Repository()
        {
            Entities = new List<TModel>();
        }
    }
}
