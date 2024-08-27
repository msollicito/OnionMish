
using DomainLayer.Models;
using RepositoryLayer.IRepository;
using ServiceLayer.ICustomServices;
namespace ServiceLayer.CustomServices
{
    public class VisitService : ICustomService<Visit>
    {
        private readonly IRepository<Visit> _visitRepository;
        public VisitService(IRepository<Visit> visitRepository)
        {
            _visitRepository = visitRepository;
        }
        public void Delete(Visit entity)
        {
            try
            {
                if (entity != null)
                {
                    _visitRepository.Delete(entity);
                    _visitRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Visit Get(int Id)
        {
            try
            {
                var obj = _visitRepository.Get(Id);
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
        public IEnumerable<Visit> GetAll()
        {
            try
            {
                var obj = _visitRepository.GetAll();
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
        public void Insert(Visit entity)
        {
            try
            {
                if (entity != null)
                {
                    _visitRepository.Insert(entity);
                    _visitRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Remove(Visit entity)
        {
            try
            {
                if (entity != null)
                {
                    _visitRepository.Remove(entity);
                    _visitRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Update(Visit entity)
        {
            try
            {
                if (entity != null)
                {
                    _visitRepository.Update(entity);
                    _visitRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}