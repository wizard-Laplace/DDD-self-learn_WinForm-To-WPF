using System;
using DDD.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DDDTest.Tests
{
    [TestClass]
    public class TemperatureTest
    {
        [TestMethod]
        public void 小数点以下2桁でまるめて表示できる()
        {
            var t = new Temperature(12.3f);
            Assert.AreEqual(12.3f, t.Value);
            Assert.AreEqual("12.30", t.DisplayValue);
            Assert.AreEqual("12.30℃", t.DisplayValueWithUnit);
            Assert.AreEqual("12.30 ℃", t.DisplayValueWithUnitSpace);
        }

        /// <summary>
        /// 温度Equalsメソッドはt1とt2は参照型(インスタンス)なので
        /// メモリ上の別アドレスを参照している為、=で比較するとtrueは返ってこない。
        /// 同じ戻り値だとしても比較できない。
        /// </summary>
        [TestMethod]
        public void 温度Equals()
        {
            var t1 = new Temperature(12.3f);
            var t2 = new Temperature(12.3f);

            Assert.AreEqual(true, t1.Equals(t2));
        }

        [TestMethod]
        public void 温度EqualsEquals()
        {
            var t1 = new Temperature(12.3f);
            var t2 = new Temperature(12.3f);

            Assert.AreEqual(true, t1 == t2);
        }

        /// <summary>
        /// 値型Equalsメソッドは値を比較しているため、単純にtrueとなる。
        /// </summary>
        [TestMethod]
        public void 値型Equals()
        {
            float t1 = 12.3f;
            float t2 = 12.3f;

            Assert.AreEqual(true, t1 == t2);
        }
    }
}
