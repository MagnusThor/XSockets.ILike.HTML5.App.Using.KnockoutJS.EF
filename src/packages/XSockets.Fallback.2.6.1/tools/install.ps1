param($installPath, $toolsPath, $package, $project)
#install.ps1 v: 2.0
$defaultProject = Get-Project

if($defaultProject.Type -ne "C#"){
	Write-Host "Sorry, XSockets is only available for C#"
	return
}
if(($defaultProject.Object.References | Where-Object {$_.Name -eq "System.Web.Mvc"}) -eq $null){  
    Write-Host 'Sorry, Can only install XSockets.Fallback in ASP.NET MVC projects' -ForegroundColor DarkRed   
    return
}

###################################
#Add fallback if MVC
###################################
if(((Get-Project $defaultProject.Name).Object.References | Where-Object {$_.Name -eq "System.Web.Mvc"}) -ne $null){ 

    $mvc4 = Get-ProjectItem "App_Start\RouteConfig.cs"
    if($mvc4 -eq $null){
        ############################################################################
        #Add Fallback controller to MvcApplication class and method RegisterRoutes #
        ############################################################################
        Add-CodeToMethod $defaultProject.Name '\' 'Global.asax.cs' 'MvcApplication' 'RegisterRoutes' 'routes.MapRoute("Fallback","{controller}/{action}",new {controller = "Fallback", action = "Init"},new[] {"XSockets.Longpolling"});'
    }
    else{
        ###################################################################
        #Add Fallback controller to RouteConfig class and method Register #
        ###################################################################
        Add-CodeToMethod $defaultProject.Name '\App_Start\' 'RouteConfig.cs' 'RouteConfig' 'RegisterRoutes' 'routes.MapRoute("Fallback","{controller}/{action}",new {controller = "Fallback", action = "Init"},new[] {"XSockets.Longpolling"});'
    }
}