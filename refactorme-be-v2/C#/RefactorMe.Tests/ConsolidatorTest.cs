using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactorMe.DontRefactor.Data.Implementation;
using System.Linq;
using RefactorMe.DontRefactor.Models;
using RefactorMe.Models;

namespace RefactorMe.Tests
{
    /// <summary>
    /// Note that this test only cover some scenario not all possible scenarios. 
    /// Note that no stub/mock has been used for this test. 
    /// This is a test to validate the functionality of Consolidate functions and Rate
    /// </summary>
    [TestClass]
    public class ConsolidatorTest
    {
        private void AssertEqual(ProductEx p1, Lawnmower p2, double rate = 1 )
        {
            Assert.AreEqual(p1.Id, p2.Id);
            Assert.AreEqual(p1.Name, p2.Name);
            Assert.AreEqual(p1.Price, p2.Price * rate );
            
            Assert.AreEqual(p1.Type, "Lawnmower"); 
        }

        private void AssertEqual(ProductEx p1, TShirt p2, double rate = 1)
        {
            Assert.AreEqual(p1.Id, p2.Id);
            Assert.AreEqual(p1.Name, p2.Name);
            Assert.AreEqual(p1.Price, p2.Price * rate );

            Assert.AreEqual(p1.Type, "T-Shirt");
        }

        private void AssertEqual(ProductEx p1, PhoneCase p2, double rate = 1)
        {
            Assert.AreEqual(p1.Id, p2.Id);
            Assert.AreEqual(p1.Name, p2.Name);
            Assert.AreEqual(p1.Price, p2.Price * rate );

            Assert.AreEqual(p1.Type, "Phone Case");
        }

        [TestMethod]
        public void TestConsolidate()
        {
            var consolidator = new ProductDataConsolidator();

            var l = new LawnmowerRepository();
            var p = new PhoneCaseRepository();
            var t = new TShirtRepository();

            var lawnmowers = l.GetAll();
            var phoneCases = p.GetAll();
            var tshirts = t.GetAll();

            consolidator.Consolidate(lawnmowers);
            consolidator.Consolidate(phoneCases);
            consolidator.Consolidate(tshirts);

            var products = consolidator.GetAll();

            var i = 0 ;

            foreach (var lawnmower in lawnmowers )
            {
                AssertEqual(products[i++], lawnmower);
            }


            foreach (var phoneCase in phoneCases )
            {
                AssertEqual(products[i++], phoneCase);
            }


            foreach (var tshirt in tshirts )
            {
                AssertEqual(products[i++], tshirt);
            }

            Assert.AreEqual(products.Count, i);
        }

        [TestMethod]
        public void TestRate()
        {
            var consolidator = new ProductDataConsolidator();

            var l = new LawnmowerRepository();
            var p = new PhoneCaseRepository();
            var t = new TShirtRepository();

            var lawnmowers = l.GetAll();
            var phoneCases = p.GetAll();
            var tshirts = t.GetAll();

            consolidator.Consolidate(lawnmowers);
            consolidator.Consolidate(phoneCases);
            consolidator.Consolidate(tshirts);

            var products = consolidator.GetAll();

            var rate = 0.67;

            consolidator.Rate = 0.67;

            var i = 0;

            foreach (var lawnmower in lawnmowers)
            {
                AssertEqual(products[i++], lawnmower, rate );
            }


            foreach (var phoneCase in phoneCases)
            {
                AssertEqual(products[i++], phoneCase, rate );
            }


            foreach (var tshirt in tshirts)
            {
                AssertEqual(products[i++], tshirt, rate );
            }

        }
    }
}
