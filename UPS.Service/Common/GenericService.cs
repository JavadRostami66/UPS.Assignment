using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPS.Domain.Common;
using UPS.Repository.Common;
using UPS.Service.Result;

namespace UPS.Service.Common
{
    public abstract class GenericService<T, TKey> : IGenericService<T, TKey> where T : Entity<TKey>
    {
        IUnitOfWork _unitOfWork;
        IGenericRepository<T, TKey> _repository;


        protected GenericService(IUnitOfWork unitOfWork, IGenericRepository<T, TKey> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public Task<T> GetById(TKey id)
        {
            return _repository.FindAsync(r => r.Id.Equals(id));
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public ListResult<T> GetAll()
        {
            return new ListResult<T>()
            {
                DataList = _repository.GetAll()
            };
        }
        public MessageResult<T> FirstOrDefault()
        {
            return new MessageResult<T>()
            {
                Entity = _repository.FirstOrDefault()
            };
        }

        public async Task<MessageResult<int>> DeleteAsync(T entity)
        {
            if (entity == null)
            {
                return new MessageResult<int>()
                {
                    Entity = 0,
                    Message = "Entity Is Null",
                    Status = 400,
                    Success = false
                };
            }

            try
            {
                _repository.Delete(entity);
                int result = await _unitOfWork.CommitAsync();
                return new MessageResult<int>()
                {
                    Status = 1,
                    Success = true,
                    Entity = result,
                    Message = "delete action was successful"

                };
            }
            catch (Exception e)
            {
                return new MessageResult<int>()
                {
                    Status = 0,
                    Success = false,
                    Entity = 0,
                    Message = e.Message
                };
            }


        }

        public async Task<MessageResult<T>> AddAsync(T entity)
        {
            if (entity == null)
            {
                return new MessageResult<T>()
                {
                    Entity = entity,
                    Message = "Entity Is Null",
                    Status = 0,
                    Success = false
                };
            }

            try
            {
                _repository.Add(entity);

                int result = await _unitOfWork.CommitAsync();
                if (result > 0)
                    return new MessageResult<T>()
                    {
                        Status = 1,
                        Success = true,
                        Entity = entity,
                        Message = "add action was successful"

                    };
                else
                    return new MessageResult<T>()
                    {
                        Status = 0,
                        Success = false,
                        Entity = entity,
                        Message = "something went wrong in add action"

                    };
            }
            catch (Exception e)
            {
                return new MessageResult<T>()
                {
                    Status = 0,
                    Success = false,
                    Entity = entity,
                    Message = e.Message
                };
            }

        }

        public MessageResult<T> Add(T entity)
        {
            if (entity == null)
            {
                return new MessageResult<T>()
                {
                    Entity = entity,
                    Message = "Entity Is Null",
                    Status = 0,
                    Success = false
                };
            }

            try
            {
                _repository.Add(entity);
                _unitOfWork.Commit();
                return new MessageResult<T>()
                {
                    Status = 1,
                    Success = true,
                    Entity = entity,
                    Message = "add action was successful"

                };
            }
            catch (Exception e)
            {
                return new MessageResult<T>()
                {
                    Status = 0,
                    Success = false,
                    Entity = entity,
                    Message = e.Message
                };
            }
        }

        public MessageResult<T> Update(T entity)
        {
            if (entity == null)
            {
                return new MessageResult<T>()
                {
                    Entity = entity,
                    Message = "Entity Is Null",
                    Status = 0,
                    Success = false
                };
            }

            try
            {
                _repository.Update(entity);
                var result = _unitOfWork.Commit();
                return new MessageResult<T>()
                {
                    Status = 1,
                    Success = true,
                    Entity = entity,
                    Message = "update action was successful"

                };
            }
            catch (Exception e)
            {
                return new MessageResult<T>()
                {
                    Status = 0,
                    Success = false,
                    Entity = entity,
                    Message = e.Message
                };
            }
        }

        public async Task<MessageResult<T>> UpdateAsync(T entity)
        {
            if (entity == null)
            {
                return new MessageResult<T>()
                {
                    Entity = entity,
                    Message = "Entity Is Null",
                    Status = 0,
                    Success = false
                };
            }

            try
            {
                _repository.Update(entity);
                int result = await _unitOfWork.CommitAsync();

                if (result > 0)
                    return new MessageResult<T>()
                    {
                        Status = 1,
                        Success = true,
                        Entity = entity,
                        Message = "update action was successful"

                    };
                else
                    return new MessageResult<T>()
                    {
                        Status = 0,
                        Success = false,
                        Entity = entity,
                        Message = "something went wrong in add action"
                    };
            }
            catch (Exception e)
            {
                return new MessageResult<T>()
                {
                    Status = 0,
                    Success = false,
                    Entity = entity,
                    Message = e.Message
                };
            }


        }


    }
}
