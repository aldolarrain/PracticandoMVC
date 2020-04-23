using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticandoMVC.Controllers;

namespace PracticandoMVC.Tests
{
    [TestClass]
    public class UnitTest1
    {
        public class UnitTestFriend
        {
            [TestMethod]
            public void TestMethodGetFriends()
            {
                //arrange
                FriendsController friendcontroller = new FriendsController();
                //act
                var friends = friendcontroller.GetFriends();
                //assert
                Assert.IsNotNull(friends);


            }
        }
    }
}
