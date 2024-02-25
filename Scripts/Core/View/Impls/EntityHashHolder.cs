using UnityEngine;

namespace JCMG.EntitasRedux.Core.View.Impls
{
	public class EntityHashHolder : MonoBehaviour, IEntityHashHolder
	{
		public Transform EntityTransform;

		public int Hash => EntityTransform.GetHashCode();
	}
}