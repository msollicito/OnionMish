
using DomainLayer.Models;
using RepositoryLayer.IRepository;
using ServiceLayer.ICustomServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ServiceLayer.CustomServices
{
    public class PatientService : ICustomService<Patient>
    {
        private readonly IRepository<Patient> _patientRepository;
        public PatientService(IRepository<Patient> patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public void Delete(Patient entity)
        {
            try
            {
                if (entity != null)
                {
                    _patientRepository.Delete(entity);
                    _patientRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Patient Get(int Id)
        {
            try
            {
                var obj = _patientRepository.Get(Id);
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
        public IEnumerable<Patient> GetAll()
        {
            try
            {
                var obj = _patientRepository.GetAll();
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
        public void Insert(Patient entity)
        {
            try
            {
                if (entity != null)
                {
                    _patientRepository.Insert(entity);
                    _patientRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Remove(Patient entity)
        {
            try
            {
                if (entity != null)
                {
                    _patientRepository.Remove(entity);
                    _patientRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Update(Patient entity)
        {
            try
            {
                if (entity != null)
                {
                    _patientRepository.Update(entity);
                    _patientRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}