using System;

namespace JCMG.EntitasRedux.Core.Utils
{
	public static class UnsubscribeEventExtensions
	{
		public static IDisposable AddTo(this IDisposable disposable, IUnsubscribeEvent unsubscribe)
		{
			unsubscribe.Value += disposable.Dispose;
			return disposable;
		}
	}
}