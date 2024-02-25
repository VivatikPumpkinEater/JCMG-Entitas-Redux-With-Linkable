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

using Genesis.Shared;

namespace JCMG.EntitasRedux.VisualDebugging.Editor
{
	internal sealed class VisualDebuggingConfig : AbstractConfigurableConfig
	{
		public string DefaultInstanceCreatorFolderPath
		{
			get => _genesisConfig.GetOrSetValue(DEFAULT_INSTANCE_CREATOR_FOLDER_PATH_KEY, DEFAULT_CREATOR_FOLDER_PATH);
			set => _genesisConfig.SetValue(DEFAULT_INSTANCE_CREATOR_FOLDER_PATH_KEY, value);
		}

		public string TypeDrawerFolderPath
		{
			get => _genesisConfig.GetOrSetValue(TYPE_DRAWER_FOLDER_PATH_KEY, DEFAULT_DRAWER_FOLDER_PATH);
			set => _genesisConfig.SetValue(TYPE_DRAWER_FOLDER_PATH_KEY, value);
		}

		private const string SYSTEM_WARNING_THRESHOLD_KEY = "EntitasRedux.VisualDebugging.SystemWarningThreshold";

		private const string DEFAULT_INSTANCE_CREATOR_FOLDER_PATH_KEY =
			"EntitasRedux.VisualDebugging.DefaultInstanceCreatorFolderPath";

		private const string TYPE_DRAWER_FOLDER_PATH_KEY = "EntitasRedux.VisualDebugging.TypeDrawerFolderPath";

		private const string DEFAULT_SYSTEM_THRESHOLD = "5";
		private const string DEFAULT_CREATOR_FOLDER_PATH = "Assets/Editor/DefaultInstanceCreator";
		private const string DEFAULT_DRAWER_FOLDER_PATH = "Assets/Editor/TypeDrawer";

		public override void Configure(IGenesisConfig genesisConfig)
		{
			base.Configure(genesisConfig);

			genesisConfig.SetIfNotPresent(DEFAULT_INSTANCE_CREATOR_FOLDER_PATH_KEY, DEFAULT_CREATOR_FOLDER_PATH);
			genesisConfig.SetIfNotPresent(TYPE_DRAWER_FOLDER_PATH_KEY, DEFAULT_DRAWER_FOLDER_PATH);
		}
	}
}
