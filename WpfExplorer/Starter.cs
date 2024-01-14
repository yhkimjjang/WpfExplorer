using WpfExplorer.Properties;

namespace WpfExplorer;

internal class Starter
{
    [STAThread]
    public static void Main(string[] args)
    {
        _ = new App()
            .AddInversionModule<HelperModules>()
            .AddWireDataContext<WireDataContext>()
            .Run();
    }
}
