using System;

namespace JCMG.EntitasRedux.Core.Utils
{
	public class UnsubscribeEvent : IUnsubscribeEvent
	{
		public event Action Value;

		public void Clear()
		{
			Value?.Invoke();
			Value = null;
		}
	}

	public interface IUnsubscribeEvent
	{
		event Action Value;
	}
}