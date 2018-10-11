using FluentValidation;
using System;
using System.Collections.Generic;
using TaskManager.BLL.Interfaces;
using TaskManager.BLL.Validation;
using TaskManager.DLL.Interfaces;
using TaskManager.DLL.Models;
using TaskManager.Shared.DTOs;
using TaskManager.Shared.Exceptions;

namespace TaskManager.BLL.Services
{
    public abstract class BaseService<DEntity, MEntity> : IService<DEntity> where DEntity : EntityDTO where MEntity : Entity
    {
        protected readonly IBaseRepository<MEntity> repository;
        protected readonly IMapper mapper;
        protected readonly IValidator<MEntity> validator;

        public BaseService(IBaseRepository<MEntity> repository, IMapper mapper, ValidatorFactory validatorFactory)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.validator = validatorFactory.GetValidator<MEntity>();
        }

        //Check if item need cast to Entity
        public List<DEntity> GetAll()
        {
            var result = new List<DEntity>();
            foreach (var item in repository.GetAll())
            {
                result.Add(mapper.MapEntity(item) as DEntity);
            }
            return result;
        }

        public DEntity GetById(int id)
        {
            return mapper.MapEntity(repository.GetById(id)) as DEntity;
        }

        public int Create(DEntity entity)
        {
            var validationResult = validator.Validate(entity);
            if (validationResult.IsValid)
                return repository.Create(mapper.MapEntity(entity) as MEntity);
            else
                throw new ValidationException(validationResult.Errors);
        }

        public void Update(int id, DEntity entity)
        {
            var validationResult = validator.Validate(entity);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            try
            {
                repository.Update(id, mapper.MapEntity(entity) as MEntity);
            }
            catch (ArgumentNullException)
            {
                throw new NotFoundException();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(DEntity entity)
        {
            repository.Delete(mapper.MapEntity(entity) as MEntity);
        }

        public void DeleteById(int id)
        {
            repository.DeleteById(id);
        }
    }
}