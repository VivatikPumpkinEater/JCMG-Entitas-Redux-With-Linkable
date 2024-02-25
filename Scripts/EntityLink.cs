/*

MIT License

Copyright (c) 2020 Jeff Campbell

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/

using System;
using UnityEngine;

namespace JCMG.EntitasRedux
{
	public class EntityLink : MonoBehaviour
	{
		public IEntity Entity => _entity;

		private bool _applicationIsQuitting;

		private IEntity _entity;

		public bool Link(IEntity entity)
		{
			if (_entity != null)
			{
				// Skip if link to the same entity multiple times
				if (_entity.Id.Equals(entity.Id))
					return false;

				throw new Exception("EntityLink is already linked to " + _entity + "!");
			}

			_entity = entity;
			_entity.Retain(this);
			return true;
		}

		public void Unlink()
		{
			if (_entity == null)
			{
				throw new Exception("EntityLink is already unlinked!");
			}

			_entity.Release(this);
			_entity = null;
		}

		private void OnDestroy()
		{
			if (!_applicationIsQuitting && _entity != null)
			{
				Debug.LogWarning(
					"EntityLink got destroyed but is still linked to " +
					_entity +
					"!\n" +
					"Please call gameObject.Unlink() before it is destroyed.");
			}
		}

		private void OnApplicationQuit()
		{
			_applicationIsQuitting = true;
		}

		public override string ToString() => "EntityLink(" + gameObject.name + ")";
	}
}