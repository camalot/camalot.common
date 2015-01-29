using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camalot.Common.Extensions {
	public static partial class CamalotCommonExtensions {
		/// <summary>
		/// Runs the task function synchronously.
		/// </summary>
		/// <param name="task">The task.</param>
		public static void RunSync(this Func<Task> task) {
			TaskHelper.RunSync(task);
		}
		/// <summary>
		/// Runs the task function synchronously.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="task">The task.</param>
		/// <returns></returns>
		public static T RunSync<T>(this Func<Task<T>> task) {
			return TaskHelper.RunSync<T>(task);
		}

		/// <summary>
		/// Runs the task synchronously.
		/// </summary>
		/// <param name="task">The task.</param>
		public static void RunSync(this Task task) {
			TaskHelper.RunSync(async () => await task);
		}
		/// <summary>
		/// Runs the task synchronously.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="task">The task.</param>
		/// <returns></returns>
		public static T RunSync<T>(this Task<T> task) {
			return TaskHelper.RunSync<T>(async () => await task);
		}
	}
}
