﻿namespace VetSystem.Web.Infrastructure.Mapping
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using AutoMapper.QueryableExtensions;

    public static class IQueryableExtensions
    {
        public static IQueryable<TDestination> To<TDestination>(this IQueryable source, params Expression<Func<TDestination, object>>[] membersToExpand)
        {
            return source.ProjectTo(AutoMapperConfig.Configuration, membersToExpand);
        }

        public static TDestination ProjectTo<TDestination>(this IQueryable source, params Expression<Func<TDestination, object>>[] membersToExpand)
        {
            return source.ProjectTo(AutoMapperConfig.Configuration, membersToExpand).ToList()[0];
        }
    }
}
