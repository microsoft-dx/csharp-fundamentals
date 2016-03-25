namespace AdvancedGenericsInterfaces
{
    public interface IUptadeable<TModel> where TModel : Model
    {
        void Update(TModel model);
    }
}
