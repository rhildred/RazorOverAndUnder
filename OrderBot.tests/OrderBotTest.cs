using System;
using System.IO;
using Xunit;
using OrderBot;

namespace OrderBot.tests
{
    public class OrderBotTest
    {
        [Fact]
        public void Test1()
        {

        }

        [Fact]
        public void TestWelcome()
        {
            Session oSession = new Session("12345");
            String sInput = oSession.OnMessage("hello")[0];
            Assert.True(sInput.Contains("Welcome"));
        }

        [Fact]
        public void TestShawarama()
        {
            Session oSession = new Session("12345");
            String sInput = oSession.OnMessage("hello")[0];
            Assert.True(sInput.ToLower().Contains("sangeetha"));
        }

        [Fact]
        public void TestSize()
        {
            Session oSession = new Session("12345");
            String sInput = oSession.OnMessage("hello")[1];
            Assert.True(sInput.ToLower().Contains("size"));
        }

        [Fact]
        public void TestMini()
        {
            Session oSession = new Session("12345");
            oSession.OnMessage("hello");
            String sInput = oSession.OnMessage("mini")[0];
            Assert.True(sInput.ToLower().Contains("mini"));
        }

        [Fact]
        public void TestCurry1()
        {
            Session oSession = new Session("12345");
            oSession.OnMessage("hello");
            String sInput = oSession.OnMessage("mini")[0];
            Assert.True(sInput.ToLower().Contains("mini"));
            Assert.True(sInput.ToLower().Contains("option 1 curry"));
        }

        [Fact]
        public void TestCurry2()
        {
            Session oSession = new Session("12345");
            oSession.OnMessage("hello");
            oSession.OnMessage("mini");
            String sInput = oSession.OnMessage("sambar")[0];

            Assert.True(sInput.ToLower().Contains("mini"));
            Assert.True(sInput.ToLower().Contains("option 2 curry"));
            Assert.True(sInput.ToLower().Contains("sambar"));
        }

        [Fact]
        public void TestVeggy1()
        {
            Session oSession = new Session("12345");
            oSession.OnMessage("hello");
            oSession.OnMessage("mini");
            oSession.OnMessage("sambar");
            String sInput = oSession.OnMessage("rasam")[0];

            Assert.True(sInput.ToLower().Contains("mini"));
            Assert.True(sInput.ToLower().Contains("option 1 veggy"));
            Assert.True(sInput.ToLower().Contains("rasam"));
        }

        [Fact]
        public void TestVeggy2()
        {
            Session oSession = new Session("12345");
            oSession.OnMessage("hello");
            oSession.OnMessage("mini");
            oSession.OnMessage("sambar");
            oSession.OnMessage("rasam");
            String sInput = oSession.OnMessage("carrot")[0];

            Assert.True(sInput.ToLower().Contains("mini"));
            Assert.True(sInput.ToLower().Contains("option 2 veggy"));
            Assert.True(sInput.ToLower().Contains("carrot"));
        }

        [Fact]
        public void TestDessert()
        {
            Session oSession = new Session("12345");
            oSession.OnMessage("hello");
            oSession.OnMessage("mini");
            oSession.OnMessage("sambar");
            oSession.OnMessage("rasam");
            oSession.OnMessage("carrot");
            String sInput = oSession.OnMessage("beans")[0];

            Assert.True(sInput.ToLower().Contains("mini"));
            Assert.True(sInput.ToLower().Contains("dessert"));
            Assert.True(sInput.ToLower().Contains("beans"));
        }

        [Fact]
        public void TestConfirmationYes()
        {
            Session oSession = new Session("12345");
            oSession.OnMessage("hello");
            oSession.OnMessage("mini");
            oSession.OnMessage("sambar");
            oSession.OnMessage("rasam");
            oSession.OnMessage("carrot");
            oSession.OnMessage("bean");
            oSession.OnMessage("gulab");
            String sInput = oSession.OnMessage("yes")[0];

            Assert.True(sInput.ToLower().Contains("mini"));
            Assert.True(sInput.ToLower().Contains("bean"));
            Assert.True(sInput.ToLower().Contains("gulab"));
            Assert.True(sInput.ToLower().Contains("name"));
        }

        [Fact]
        public void TestConfirmationNo()
        {
            Session oSession = new Session("12345");
            oSession.OnMessage("hello");
            oSession.OnMessage("mini");
            oSession.OnMessage("sambar");
            oSession.OnMessage("rasam");
            oSession.OnMessage("carrot");
            oSession.OnMessage("bean");
            oSession.OnMessage("gulab");
            String sInput = oSession.OnMessage("no")[0];

            Assert.True(sInput.ToLower().Contains("canceled"));
        }

        [Fact]
        public void TestName()
        {
            Session oSession = new Session("12345");
            oSession.OnMessage("hello");
            oSession.OnMessage("mini");
            oSession.OnMessage("sambar");
            oSession.OnMessage("rasam");
            oSession.OnMessage("carrot");
            oSession.OnMessage("bean");
            oSession.OnMessage("gulab");
            oSession.OnMessage("yes");
            String sInput = oSession.OnMessage("madu")[0];

            Assert.True(sInput.ToLower().Contains("madu"));
        }

        [Fact]
        public void TestPhone()
        {
            Session oSession = new Session("12345");
            oSession.OnMessage("hello");
            oSession.OnMessage("mini");
            oSession.OnMessage("sambar");
            oSession.OnMessage("rasam");
            oSession.OnMessage("carrot");
            oSession.OnMessage("bean");
            oSession.OnMessage("gulab");
            oSession.OnMessage("yes");
            oSession.OnMessage("madu");
            String sInput = oSession.OnMessage("226")[0];

            Assert.True(sInput.ToLower().Contains("226"));
        }

        [Fact]
        public void TestPayment()
        {
            Session oSession = new Session("12345");
            oSession.OnMessage("hello");
            oSession.OnMessage("mini");
            oSession.OnMessage("sambar");
            oSession.OnMessage("rasam");
            oSession.OnMessage("carrot");
            oSession.OnMessage("bean");
            oSession.OnMessage("gulab");
            oSession.OnMessage("yes");
            oSession.OnMessage("madu");
            oSession.OnMessage("226");
            String sInput = oSession.OnMessage("visa")[0];

            Assert.True(sInput.ToLower().Contains("confirmed"));
        }
    }
}
