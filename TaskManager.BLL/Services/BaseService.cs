using FluentValidation;
using System;
using System.Collections.Generic;
using TaskManager.BLL.Interfaces;
using TaskManager.BLL.Validation;
using TaskManager.DLL.Interfaces;
using TaskManager.DLL.Models;

namespace TaskManager.BLL.Services
{
    public class BaseService<TEntity, REntity> : IService<TEntity> where TEntity : class where REntity : Entity
    {
        private readonly IRepository<REntity> repository;
        private readonly IMapper mapper;
        private readonly IValidator<REntity> validator;

        public BaseService(IRepository<REntity> repository, IMapper mapper, ValidatorFactory validatorFactory)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.validator = validatorFactory.GetValidator<REntity>();
        }

        public List<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}