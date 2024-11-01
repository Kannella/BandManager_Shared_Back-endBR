﻿using BandManager.Api.Resources.Models;
using BandManager.Api.Resources.Interfaces.IRepositories;

namespace BandManager.Api.BLL.Services
{
    public class DirectDbService<E> where E : Entity
    {
        private readonly IDirectDbRepository<E> _repository;

        public DirectDbService(IDirectDbRepository<E> repository)
        {
            _repository = repository;
        }

        public void Create(E entity)
        {
            _repository.Create(entity);
        }

        public void Delete(E entity)
        {
            _repository.Delete(entity);
        }

        public List<E> GetAll()
        {
            return _repository.GetAll();
        }

        public E GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<E> GetWhere(Func<E, bool> where)
        {
            return _repository.GetWhere(where);
        }

        public void Update(E entity)
        {
            _repository.Update(entity);
        }
    }
}