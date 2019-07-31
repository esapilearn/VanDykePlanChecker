using Microsoft.VisualStudio.TestTools.UnitTesting;
using VanDykePlanChecker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESAPIX.Facade.API;
using ESAPIX.Constraints;

namespace VanDykePlanChecker.ViewModels.Tests
{
    [TestClass()]
    public class CTDateConstraintTests
    {
        [TestMethod()]
        public void ConstrainPassesTest()
        {
            var im = new Image();
            im.CreationDateTime = DateTime.Now.AddDays(-59);

            var expected = ResultType.PASSED;
            var actual = new CTDateConstraint().Constrain(im).ResultType;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ContrainFailsTest()
        {
            var im = new Image();
            im.CreationDateTime = DateTime.Now.AddDays(-61);

            var expected = ResultType.ACTION_LEVEL_3;
            var actual = new CTDateConstraint().Constrain(im).ResultType;

            Assert.AreEqual(expected, actual);
        }
    }
}