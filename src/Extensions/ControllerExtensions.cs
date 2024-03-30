using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
namespace mscs.Extensions;

public static class ControllerExtensions {
  public static string
  GetControllerName(this ControllerContext controllerContext) {
    return (controllerContext.ActionDescriptor as ControllerActionDescriptor)
        ?.ControllerName;
  }
}
