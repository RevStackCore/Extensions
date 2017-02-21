using System;
using System.Threading.Tasks;
using System.Reflection;

namespace RevStackCore.Extensions
{
	public static partial class Extensions
	{
		/// <summary>
		/// Copies the properties from.
		/// </summary>
		/// <returns>The properties from.</returns>
		/// <param name="target">Target.</param>
		/// <param name="source">Source.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static T CopyPropertiesFrom<T>(this T target, object source)
		{
			return copyPropertiesFrom(target, source);
		}

		/// <summary>
		/// Copies the properties from.
		/// </summary>
		/// <returns>The properties from.</returns>
		/// <param name="target">Target.</param>
		/// <param name="source">Source.</param>
		/// <param name="nullifyDefaultSelectValue">If set to <c>true</c> nullify default select value.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static T CopyPropertiesFrom<T>(this T target, object source, bool nullifyDefaultSelectValue)
		{
			if (nullifyDefaultSelectValue)
			{
				return copyPropertiesFromNullifySelect(target, source);
			}
			return copyPropertiesFrom(target, source);
		}

		/// <summary>
		/// Copies the properties from async.
		/// </summary>
		/// <returns>The properties from async.</returns>
		/// <param name="target">Target.</param>
		/// <param name="source">Source.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static Task<T> CopyPropertiesFromAsync<T>(this T target, object source)
		{
			return Task.FromResult(copyPropertiesFrom(target, source));
		}

		/// <summary>
		/// Copies the properties from async.
		/// </summary>
		/// <returns>The properties from async.</returns>
		/// <param name="target">Target.</param>
		/// <param name="source">Source.</param>
		/// <param name="nullifyDefaultSelectValue">If set to <c>true</c> nullify default select value.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static Task<T> CopyPropertiesFromAsync<T>(this T target, object source, bool nullifyDefaultSelectValue)
		{
			return Task.FromResult(CopyPropertiesFrom(target, source, nullifyDefaultSelectValue));
		}


		/// <summary>
		/// Copies the properties from.
		/// </summary>
		/// <returns>The properties from.</returns>
		/// <param name="target">Target.</param>
		/// <param name="source">Source.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		private static T copyPropertiesFrom<T>(T target, object source)
		{
			var targetType = target.GetType();
			var sourceType = source.GetType();

			var sourceProps = sourceType.GetTypeInfo().GetProperties();
			foreach (var propInfo in sourceProps)
			{
				//Get the matching property from the target
				var toProp =
					(targetType == sourceType) ? propInfo : targetType.GetTypeInfo().GetProperty(propInfo.Name);

				//If it exists and it's writeable
				if (toProp != null && toProp.CanWrite)
				{
					//Copy non null value from the source to the target
					var value = propInfo.GetValue(source, null);
					if (value != null && value.ToString() != "")
					{
						toProp.SetValue(target, value, null);
					}
				}
			}
			return target;
		}

		/// <summary>
		/// Copies the properties from nullify select.
		/// </summary>
		/// <returns>The properties from nullify select.</returns>
		/// <param name="target">Target.</param>
		/// <param name="source">Source.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		private static T copyPropertiesFromNullifySelect<T>(T target, object source)
		{
			var targetType = target.GetType();
			var sourceType = source.GetType();

			var sourceProps = sourceType.GetTypeInfo().GetProperties();

			foreach (var propInfo in sourceProps)
			{
				//Get the matching property from the target
				var toProp =
					(targetType == sourceType) ? propInfo : targetType.GetTypeInfo().GetProperty(propInfo.Name);

				//If it exists and it's writeable
				if (toProp != null && toProp.CanWrite)
				{
					//Copy the value from the source to the target
					var value = propInfo.GetValue(source, null);
					if (value != null && value.ToString().ToLower() == "select")
					{
						value = null;
					}
					toProp.SetValue(target, value, null);
				}
			}
			return target;
		}
	}
}
