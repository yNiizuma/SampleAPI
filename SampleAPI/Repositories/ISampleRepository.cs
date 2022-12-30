using SampleAPI.Model;

namespace SampleAPI.Repositories
{
    public interface ISampleRepository
    {
        //Assinatura que estaremos utilizando.
        Task<IEnumerable<Sample>> Get();
        Task<Sample> Get(int SampleID);
        Task<Sample> Create(Sample Sample);
        Task<Sample> Update(Sample Sample);
        Task Delete(int SampleID);
    }
}
