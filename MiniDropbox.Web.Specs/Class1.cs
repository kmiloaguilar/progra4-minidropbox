using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Machine.Specifications;
using Machine.Specifications.Mvc;
using MiniDropbox.Web.Controllers;

namespace MiniDropbox.Web.Specs
{
    public class when_a_guest_user_visit_for_first_time_the_website
    {
        private Establish context = () =>
            {
                _accountController = new AccountController();
            };

        private Because of = () => {
                                       _result = _accountController.LogIn();
        };

        private It should_display_the_login_page = () =>
            {
                _result.ShouldBeAView();
            };

        private static AccountController _accountController;
        private static ActionResult _result;
    }
}
