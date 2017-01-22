using System;
using System.Collections.Generic;
using System.Reflection;

namespace RevStackCore.Extensions
{
	public static partial class Extensions
	{
		/// <summary>
		/// Uses EqualityComparer<T>.Default as an equality comparison for generics not constrained by a reference type
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public static bool Compare<TSource, TKey>(this TSource src, TKey id, TKey value)
		{
			return EqualityComparer<TKey>.Default.Equals(id, value);
		}

		/// <summary>
		/// Hases the property value.
		/// </summary>
		/// <returns><c>true</c>, if property value is not default value, <c>false</c> otherwise.</returns>
		/// <param name="src">Source.</param>
		/// <param name="property">Property.</param>
		/// <typeparam name="TSource">The 1st type parameter.</typeparam>
		/// <typeparam name="TKey">The 2nd type parameter.</typeparam>
		public static bool HasPropertyValue<TSource, TKey>(this TSource src, string property="Id")
		{
			Type type = src.GetType();
			var info = type.GetTypeInfo().GetProperty(property);
			var value = info.GetValue(src, null);
			return (!Equals(value, default(TKey)));
		}
	}

	/// <summary>
	/// Entity property validator.
	/// </summary>
	public class EntityPropertyValidator<TEntity, TKey>
	{
		/// <summary>
		/// Hases the value.
		/// </summary>
		/// <returns><c>true</c>, if value is not default value, <c>false</c> otherwise.</returns>
		/// <param name="entity">Entity.</param>
		/// <param name="property">Property.</param>
		public bool HasValue(TEntity entity, string property="Id")
		{
			Type type = entity.GetType();
			var info = type.GetTypeInfo().GetProperty(property);
			var value = info.GetValue(entity, null);
			return (!entity.Compare(value, default(TKey)));
		}
	}
}
