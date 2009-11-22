using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web.Hosting;
using System.Web;
using System.Web.Configuration;
using System.Reflection;
using System.Globalization;
using System.Web.UI;
using System.Web.Compilation;
using System.CodeDom.Compiler;

namespace ShomreiTorah.Billing.Export {
	static class PageBuilder {
		public static T CreateHost<T>() {
			return (T)ApplicationHost.CreateApplicationHost(typeof(T), "/", Program.AspxPath);
		}

		public static TPage CreatePage<TPage>(string virtualPath) where TPage : Page {
			if (HttpRuntime.AppDomainAppVirtualPath == null) return null;
			return BuildManager.CreateInstanceFromVirtualPath(virtualPath, typeof(TPage)) as TPage;
		}
	}
}
