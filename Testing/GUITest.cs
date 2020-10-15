using Microsoft.VisualStudio.TestTools.UnitTesting;
using GUI;
namespace GUITest
{
    [TestClass]
    public class GUITest
    {
        [TestMethod]
        public void testDrawRectangle()
        {
            Form1 form1 = new Form1();
            ShapeRectangle shapeRectangle = new ShapeRectangle();
            bool checkRec = shapeRectangle.Draw(form1, "10,10");
            Assert.IsTrue(checkRec);

        }
        [TestMethod]
        public void testDrawCircle()
        {
            Form1 form1 = new Form1();
            ShapeCircle shapeCircle = new ShapeCircle();
            bool checkRec = shapeCircle.Draw(form1, "10");
            Assert.IsTrue(checkRec);

        }
        [TestMethod]
        public void testDrawTriangle()
        {
            Form1 form1 = new Form1();
            ShapeTriangle shapeTriangle = new ShapeTriangle();
            bool checkRec = shapeTriangle.Draw(form1, "7,5,10");
            Assert.IsTrue(checkRec);

        }
    }
}
