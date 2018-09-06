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
            Icon = Resources.IconCleanupCache;
        }

        public override bool Execute(GitUIEventArgs args)
        {
            args.GitModule.RunGitCmd("rm -r --cached .");
            args.GitModule.RunGitCmd("add .");
            return true;
        }
    }
}
