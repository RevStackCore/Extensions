using System;
using System.Collections.Generic;
using System.Linq;

namespace RevStackCore.Extensions
{
	public static partial class Extensions
	{
		/// <summary>
		/// Tos the paged list.
		/// </summary>
		/// <returns>The paged list.</returns>
		/// <param name="source">Source.</param>
		/// <param name="page">Page.</param>
		/// <param name="pageSize">Page size.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static IEnumerable<T> ToPagedList<T>(this IEnumerable<T> source, int page, int pageSize)
		{
			int skip = (page - 1) * pageSize;
			return source.AsEnumerable()
				.Skip(skip).Take(pageSize)
				.ToList();
		}
	}
}
