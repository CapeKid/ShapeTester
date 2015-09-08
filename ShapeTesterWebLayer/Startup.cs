using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShapeTesterWebLayer.Startup))]
namespace ShapeTesterWebLayer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
