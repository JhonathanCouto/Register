﻿using System.Linq.Expressions;

namespace Register.Domain;

public interface IQueryRepository<T> where T : class
{
    IQueryable<T> Queryable { get; }

    bool Any();

    bool Any(Expression<Func<T, bool>> where);

    Task<bool> AnyAsync();

    Task<bool> AnyAsync(Expression<Func<T, bool>> where);

    T Get(object key);

    Task<T> GetAsync(object key);

    IEnumerable<T> List();

    Task<IEnumerable<T>> ListAsync();
}
