﻿using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using AutoMapper.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace GAM.Infrastructure.Utilities
{
    public static class AutoMapperHelper
    {
        static AutoMapperHelper()
        {
            Assembly.GetExecutingAssembly().GetTypes().Where(p => p.BaseType.Equals(typeof(Controller))).ToList()
                .ForEach(p =>
                {
                    Mapper.Initialize(c => p.Assembly.MapTypes(c));
                });
        }

        /// <summary>
        ///  类型映射
        /// </summary>
        public static T MapTo<T>(this object obj)
        {
            if (obj == null) return default(T);
            Mapper.Initialize(c => c.CreateMap(obj.GetType(), typeof(T)));
            return Mapper.Map<T>(obj);
        }

        /// <summary>
        /// 集合列表类型映射
        /// </summary>
        public static List<TDestination> MapToList<TDestination>(this IEnumerable source)
        {
            foreach (var first in source)
            {
                var type = first.GetType();
                Mapper.Initialize(c => c.CreateMap(type, typeof(TDestination)));
                break;
            }
            return Mapper.Map<List<TDestination>>(source);
        }

        /// <summary>
        /// 集合列表类型映射
        /// </summary>
        public static List<TDestination> MapToList<TSource, TDestination>(this IEnumerable<TSource> source)
        {
            //IEnumerable<T> 类型需要创建元素的映射
            Mapper.Initialize(c => c.CreateMap<TSource, TDestination>());
            return Mapper.Map<List<TDestination>>(source);
        }

        /// <summary>
        /// 类型映射
        /// </summary>
        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination) where TSource : class where TDestination : class
        {
            if (source == null)
                return destination;

            Mapper.Initialize(c => c.CreateMap<TSource, TDestination>());
            return Mapper.Map(source, destination);
        }
    }
}
