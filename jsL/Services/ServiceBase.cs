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

        public OpContext Db
        {
            get { return db ?? (db = new OpContext()); }
        }

        public T GetById(int id)
        {
            var entity = Db.Set<T>().Single(x => x.Id == id);
            return entity;
        }

        public T GetByName(string name)
        {
            var entity = Db.Set<T>().SingleOrDefault(x => x.Name == name);
            return entity;
        }

        public IResult Add(T entity)
        {
            //Validation
            if (Db.Set<T>().Any(x => x.Name == entity.Name))
            {
                return new ErrorResult
                {
                    Reason = "Same name already exist"
                };
            }

            Db.Set<T>().Add(entity);
            Db.SaveChanges();

            return new SuccessResult { Id = entity.Id };
        }

        //public IResult Update(T entity)
        //{
        //    Db.SaveChanges();
        //    return new SuccessResult { Id = entity.Id };
        //}

        public IResult Delete(T entity)
        {
            Db.Set<T>().Remove(entity);
            Db.SaveChanges();
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