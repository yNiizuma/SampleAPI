using Microsoft.EntityFrameworkCore;
using SampleAPI.Model;

namespace SampleAPI.Repositories
{
    public class SampleRepository : ISampleRepository
    {

        public readonly SampleContext _context;
        public SampleRepository(SampleContext context)
        {
            _context = context;
        }
        //Estaremos criando primeiramente um registro.
        async Task<Sample> ISampleRepository.Create(Sample sample)
        {
            // realizando a conexão com banco de dados
            _context.Samples.Add(sample);
            // Utilizaremos o Async porque ele permite realizar varias transações ao mesmo tempo, mais rapidamente.
            await _context.SaveChangesAsync();

            return sample;
        }

        async Task ISampleRepository.Delete(int sampleID)
        {
            var sampleToDelete = await _context.Samples.FindAsync(sampleID);
            _ = _context.Samples.Remove(sampleToDelete);
            await _context.SaveChangesAsync();

        }

        async Task<IEnumerable<Sample>> ISampleRepository.Get()
        {
            return await _context.Samples.ToListAsync();

        }

        async Task<Sample> ISampleRepository.Get(int sampleID)
        {
            return await _context.Samples.FindAsync(sampleID);
        }

        async Task<Sample> ISampleRepository.Update(Sample sample)
        {

            _context.Entry(sample).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return sample;
        }
    }
}
