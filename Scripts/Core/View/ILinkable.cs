namespace JCMG.EntitasRedux.Core.View
{
	public interface ILinkable : IEntityHashHolder
	{
		void Link(IEntity entity);

		void Unlink();
	}
}
