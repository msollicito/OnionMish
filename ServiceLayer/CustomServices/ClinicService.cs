
using DomainLayer.Models;
using RepositoryLayer.IRepository;
using ServiceLayer.ICustomServices;
namespace ServiceLayer.CustomServices
{
    public class ClinicService : ICustomService<Clinic>
    {
        private readonly IRepository<Clinic> _clinicRepository;
        public ClinicService(IRepository<Clinic> clinicRepository)
        {
            _clinicRepository = clinicRepository;
        }
        public void Delete(Clinic entity)
        {
            try
            {
                if (entity != null)
                {
                    _clinicRepository.Delete(entity);
                    _clinicRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Clinic Get(int Id)
        {
            try
            {
                var obj = _clinicRepository.Get(Id);
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<Clinic> GetAll()
        {
            try
            {
                var obj = _clinicRepository.GetAll();
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Insert(Clinic entity)
        {
            try
            {
                if (entity != null)
                {
                    _clinicRepository.Insert(entity);
                    _clinicRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Remove(Clinic entity)
        {
            try
            {
                if (entity != null)
                {
                    _clinicRepository.Remove(entity);
                    _clinicRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Update(Clinic entity)
        {
            try
            {
                if (entity != null)
                {
                    _clinicRepository.Update(entity);
                    _clinicRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}