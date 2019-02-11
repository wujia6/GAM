using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace GAM.Infrastructure.Utilities
{
    /// <summary>
    /// AutoMapper帮助类
    /// </summary>
    public static class AutoMapperHelper
    {
        /// <summary>
        ///  单个对象映射
        /// </summary>
        public static T MapTo<T>(this object obj)
        {
            if (obj == null) return default(T);
            Mapper.Map(obj.GetType(), typeof(T));
            return Mapper.Map<T>(obj);
        }

        /// <summary>
        /// 集合列表类型映射
        /// </summary>
        public static List<TDestination> MapToList<TSource, TDestination>(this IEnumerable<TSource> source)
        {
            Mapper.Map<TSource, TDestination>();
            return Mapper.Map<List<TDestination>>(source);
        }
    }
    
}
