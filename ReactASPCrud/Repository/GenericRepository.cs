using Microsoft.EntityFrameworkCore;
using ReactASPCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReactASPCrud.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : User
    {
        //DemoTask database context
        private readonly DemoTaskContext context;

        public GenericRepository(DemoTaskContext demoTaskContext) => this.context = demoTaskContext;

        public IEnumerable<T> GetAll() => this.context.Set<T>().AsEnumerable();

        public T GetById(int id) => this.context.Set<T>().SingleOrDefault(s => s.Id == id);

        public T Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity is null");
            }

            this.context.Set<T>().Add(entity);
            this.Save();

            return null;
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity is null");
            }

            this.Save();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity is null");
            }

            this.context.Set<T>().Remove(entity);
            this.Save();
        }

        public void Save() => this.context.SaveChanges();

    }
}