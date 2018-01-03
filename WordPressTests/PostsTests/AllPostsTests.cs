using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordpressAutomation;
using WordpressAutomation.Workflows;

namespace WordPressTests.PostsTests
{
    [TestClass]
    public class AllPostsTests : WordpressTests
    {
        // Added posts show up in all posts
        // Can activate excerpt mode
        // Can Add new post

        // Single post selections

        // Can select a post by title
        // Can select a post by edit
        // Can select a post by QuickEdit
        // Can trash a post
        // Can view a post
        // Can filter by author
        // Can filter by category
        // Can filter by tag
        // Can goto post comments

        // Bulk actions

        // Can edit multiple posts
        // Can trash multiple posts
        // Can select all posts

        // Drop down filters

        // Can filter by month
        // Can filter by category
        // Can view puplished only
        // Can view drafts only
        // Can view trash only

        // Can search posts

        // Added posts show up on all posts
        // Can trash a post
        // can search posts

        [TestMethod]
        public void Added_Posts_Show_Up()
        {
            // Go to posts, get post count, store the post count
            ListPostsPage.GoTo(PostType.Posts);
            ListPostsPage.StoreCount();

            // Add a new post
            PostCreator.CreatePost();

            // Go to posts, get new posts count
            ListPostsPage.GoTo(PostType.Posts);
            Assert.AreEqual(ListPostsPage.PreviousPostCount + 1, ListPostsPage.CurrentPostCount, "Count of posts did not increase");

            // Check for the added post
            Assert.IsTrue(ListPostsPage.DoesPostExistWithTitle(PostCreator.PreviousTitle));

            // Trash post (clean up)

            ListPostsPage.TrashPost(PostCreator.PreviousTitle);
            Assert.AreEqual(ListPostsPage.PreviousPostCount, ListPostsPage.CurrentPostCount, "Couldn't trash post");
        }

        [TestMethod]
        public void Can_Search_Posts()
        {
            // Create a new post
            PostCreator.CreatePost();

            // Search for the post
            ListPostsPage.SearchForPost(PostCreator.PreviousTitle);

            // Check that post shows up in results
            Assert.IsTrue(ListPostsPage.DoesPostExistWithTitle(PostCreator.PreviousTitle));
        }
    }
}
