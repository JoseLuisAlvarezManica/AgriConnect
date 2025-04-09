namespace AgriConnect.Mobile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ListadoColaboradores), typeof(ListadoColaboradores));
        }
    }
}
