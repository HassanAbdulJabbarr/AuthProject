﻿using System.Web.Mvc;

namespace AuthProject
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters( GlobalFilterCollection filters )
        {
            filters.Add( new HandleErrorAttribute() );

        }
    }
}
