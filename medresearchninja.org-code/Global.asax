<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>
<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        RegisterProducts(RouteTable.Routes);
    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
    void RegisterProducts(RouteCollection routes)
    {
        routes.Clear();

        routes.MapPageRoute("/404", "404", "~/404.aspx");
        routes.MapPageRoute("/Jobs", "career/{jurl}", "~/career-detail.aspx");
        routes.MapPageRoute("/Jobapply", "career-detail/{jdurl}", "~/apply-job.aspx");
        routes.MapPageRoute("Forum", "forum-details/{furl}", "~/forum-details.aspx");
        routes.MapPageRoute("Case", "case/{curl}", "~/case-studies-detail.aspx");
        routes.MapPageRoute("/Blogs", "blog", "~/blogs.aspx");
        routes.MapPageRoute("/BlogDetails", "blog/{burl}", "~/blog-details.aspx");
    }

</script>
