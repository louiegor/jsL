using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using jsL.Context;
using jsL.Models;

namespace jsL.Services
{
    public abstract class ServiceBase<T> where T : class, IBaseEntity
    {
        private OpContext db;
        
        public ServiceBase(OpContext context)
        {
            db = context;
        }

        public T GetById(int id)
        {
            var entity = db.Set<T>().Single(x => x.Id == id);
            return entity;
        }

        public T GetByName(string name)
        {
            var entity = db.Set<T>().SingleOrDefault(x => x.Name == name);
            return entity;
        }

        public IResult Add(T entity)
        {
            //Validation
            if (db.Set<T>().Any(x => x.Name == entity.Name))
            {
                return new ErrorResult
                {
                    Reason = "Same name already exist"
                };
            }

            db.Set<T>().Add(entity);
            db.SaveChanges();

            return new SuccessResult { Id = entity.Id };
        }

        public IResult Delete(T entity)
        {
            db.Set<T>().Remove(entity);
            db.SaveChanges();
            return new SuccessResult();
        }

    }

    public interface IResult
    {
        bool IsSuccessful { get; }
    }

    public class ErrorResult : IResult
    {
        public bool IsSuccessful { get { return false; } }
        public string Reason { get; set; }
    }

    public class SuccessResult : IResult
    {
        public bool IsSuccessful { get { return true; } }
        public int Id { get; set; }
    }

    public class SuccessResult<T> : IResult
    {
        public bool IsSuccessful { get { return true; } }
        public T Data { get; set; }
    }
}