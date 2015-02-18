using Nancy;
using Nancy.TinyIoc;
using Nancy.Bootstrapper;
using Nancy.Diagnostics;

public class CustomBootstrapper : DefaultNancyBootstrapper
{
	protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
	{
		// your customization goes here
		StaticConfiguration.DisableErrorTraces = false;
	}

	protected override DiagnosticsConfiguration DiagnosticsConfiguration
	{
		get { return new DiagnosticsConfiguration { Password = @"hafw3kz52"}; }
	}

}