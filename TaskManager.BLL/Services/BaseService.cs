using FluentValidation;
using System;
using System.Collections.Generic;
using TaskManager.BLL.Interfaces;
using TaskManager.BLL.Validation;
using TaskManager.DLL.Interfaces;
using TaskManager.DLL.Models;
using TaskManager.Shared.DTOs;

namespace TaskManager.BLL.Services
{
    public class BaseService<DEntity, MEntity> : IService<DEntity> where DEntity : EntityDTO where MEntity : Entity
    {
        private readonly IRepository<MEntity> repository;
        private readonly IMapper mapper;
        private readonly IValidator<MEntity> validator;

        public BaseService(IRepository<MEntity> repository, IMapper mapper, ValidatorFactory validatorFactory)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.validator = validatorFactory.GetValidator<MEntity>();
        }

        public List<DEntity> GetAll()
        {
            var result = new List<DEntity>();
            foreach (var item in repository.GetAll())
            {
                result.Add((DEntity)mapper.MapEntity(item));
            }
            return result;
        }

        public int Create(DEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(DEntity entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public DEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, DEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}