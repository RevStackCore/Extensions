using System;
using System.Collections.Generic;
using System.Linq;

namespace RevStackCore.Extensions
{
	public static partial class Extensions
	{

		/// <summary>
		/// Exception handling for SingleOrDefault() 
		/// </summary>
		/// <typeparam name="TSource"></typeparam>
		/// <param name="src"></param>
		/// <returns></returns>
		public static TSource ToSingleOrDefault<TSource>(this IEnumerable<TSource> src)
		{
			try
			{
				return src.SingleOrDefault();
			}
			catch (Exception)
			{
				if (src != null && src.Any())
				{
					return src.FirstOrDefault();
				}
				else
				{
					return default(TSource);
				}
			}
		}

	}
}
