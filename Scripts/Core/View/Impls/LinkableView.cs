using JCMG.EntitasRedux.Core.Utils;
using UnityEngine;

namespace JCMG.EntitasRedux.Core.View.Impls
{
	public abstract class LinkableView<TEntity> : LinkableView
		where TEntity : class, IEntity
	{
		protected sealed override void Subscribe(IEntity entity, IUnsubscribeEvent unsubscribe)
			=> Subscribe(entity as TEntity, unsubscribe);

		protected virtual void Subscribe(TEntity entity, IUnsubscribeEvent unsubscribe)
		{
		}
	}

	[RequireComponent(typeof(EntityLink))]
	public abstract partial class LinkableView : MonoBehaviour, ILinkable
	{
		private readonly UnsubscribeEvent _unsubscribeEvent = new();

		[SerializeField] private EntityLink entityLink;

		private bool _destroyed;

		public int Hash => transform.GetHashCode();

		public void Link(IEntity entity)
		{
			if (!entityLink.Link(entity))
				return;

			entity.OnBeforeDestroyEntity += OnDestroyEntity;
			Subscribe(entity, _unsubscribeEvent);
		}

		public void Unlink()
		{
			var entity = entityLink.Entity;
			if (entity == null)
				return;

			OnDestroyEntity(entity);
		}

		private void OnDestroyEntity(IEntity entity)
		{
			entityLink.Unlink();

			if (entity.IsEnabled)
			{
				entity.OnBeforeDestroyEntity -= OnDestroyEntity;
				Unsubscribe();
			}

			if (!_destroyed)
				OnClear();
		}

		protected abstract void Subscribe(IEntity entity, IUnsubscribeEvent unsubscribe);

		private void Unsubscribe()
		{
			_unsubscribeEvent.Clear();
			OnUnsubscribe();
		}

		protected virtual void OnUnsubscribe()
		{
		}

		protected virtual void OnClear()
		{
		}

		private void OnDestroy()
		{
			_destroyed = true;
			var entity = entityLink.Entity;
			if (entity != null)
				OnDestroyEntity(entity);

			OnDestroyed();
		}

		protected virtual void OnDestroyed()
		{
		}
	}
}