using System;
using System.Linq;

namespace WordpressAutomation
{
    public partial class LeftNavigation
    {
        public class Pages
        {
            public class AllPages
            {
                public static void Select()
                {
                    MenuSelector.Select("menu-pages", "All Pages");
                }
            }
        }

        public class Posts
        {
            public class AddNew
            {
                public static void Select()
                {
                    MenuSelector.Select("menu-posts", "Add New");
                }
            }

            public class AllPosts
            {
                public static void Select()
                {
                    MenuSelector.Select("menu-posts", "All Posts");
                }
            }
        }
    }
}
