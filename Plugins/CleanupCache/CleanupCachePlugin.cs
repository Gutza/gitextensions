using System.ComponentModel.Composition;
using CleanupCache.Properties;
using GitUIPluginInterfaces;
using ResourceManager;

namespace CleanupCache
{
    [Export(typeof(IGitPlugin))]
    public class CleanupCachePlugin : GitPluginBase, IGitPluginForRepository
    {
        public CleanupCachePlugin()
        {
            SetNameAndDescription("Clean up the cache");
            Translate();
        }

        public override bool Execute(GitUIBaseEventArgs gitUiCommands)
        {
            gitUiCommands.GitModule.RunGitCmd("rm -r --cached .");
            gitUiCommands.GitModule.RunGitCmd("add .");
            return true;
        }
    }
}
