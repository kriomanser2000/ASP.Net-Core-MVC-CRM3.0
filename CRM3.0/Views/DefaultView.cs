using CRM3._0.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM3._0.Views
{
    public abstract class DefaultView<T> : WebViewPage<T>
    {
        private static ApplicationContext _db = new ApplicationContext();

        protected override void InitializePage()
        {
            SetViewBagDefaultProperties();
            base.InitializePage();
        }

        private void SetViewBagDefaultProperties()
        {
            ViewBag.Users = null;
            ViewBag.UserRole = Helpers.AccountHelper.GetUserRoleByUsername(ref _db, User.Identity.Name);
        }
    }
}