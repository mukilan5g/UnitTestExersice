using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCartNew;
using System.Collections;

namespace CartTest
{
    [TestClass]
    public class CartTest1
    {
        
        Product samsung = new Product("Samsung", 25000);
        Product Toshiba = new Product("Toshiba", 45000);
        Product Dell = new Product("Dell", 42000);
        Product HP = new Product("HP", 36000);
        ShoppingCart cart = new ShoppingCart();

        /// <summary>
        /// Returns the uppercase representation of given string
        /// </summary>
        /// <returns>Given string in uppercase</returns>
        public String ToUpper(String input)
        {
            return input.ToUpper();
        }
           
        //Call AddItems with quantity of 0 and ItemCount should remain the same
        [TestMethod]
        public void AddNullItem()
        {
            cart.AddItems(samsung, 2);
            cart.AddItems(Toshiba, 0);
            IEnumerator i = cart.GetEnumerator();
            i.MoveNext();
            Assert.AreEqual(samsung,i.Current);
            i.MoveNext();
            Assert.AreEqual(samsung, i.Current);
            Assert.IsFalse( i.MoveNext());
        }

        //Call DeleteItem with quantity of 0 and ItemCount should remain the same
        //Call DeleteItem when there are no items in the cart and ItemCount should remain at 0
        [TestMethod]
        public void DeleteNullItem()
        {
            cart.AddItems(samsung, 2);
            cart.DeleteItems(samsung, 1);
            cart.DeleteItems(samsung, 0);
            IEnumerator i = cart.GetEnumerator();
            i.MoveNext();
            Assert.AreEqual(samsung, i.Current);
            Assert.IsFalse (i.MoveNext());
            cart.DeleteItems(samsung, 1);
            Assert.IsTrue(cart.ItemCount == 0);
        }

        //Call AddItems with a negative quantity and it should raise an exception
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),"Negative values used for quantity")]
        public void AddNegativeValue()
        {
            cart.AddItems(samsung, -1);
        }

        //Call DeleteItem with a negative quantity and it should raise an exception
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Negative values used for quantity")]
        public void DeleteNegativeValue()
        {
            cart.AddItems(samsung, 3);
            cart.DeleteItems(samsung, -2);
        }

        //Call AddItems and the item count should increase, whether the item exists already or not.
        [TestMethod]
        public void ItemCount()
        {
            cart.AddItems(samsung, 2);
            cart.AddItems(Toshiba, 2);
            Assert.IsTrue(cart.ItemCount==4);        
        }

        // Call DeleteItem where the item doesn’t exist and it should raise an exception.
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "item does not exists")]
        public void NullReference()
        {
            cart.AddItems(samsung, 2);
            cart.DeleteItems(Toshiba, 2);
        }

        //Call DeleteItem where the quantity is larger than the number of those items in the cart and it should raise an exception.
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "item does not exists")]
        public void QuantityLarge()
        {
            cart.AddItems(samsung, 2);
            cart.DeleteItems(samsung, 3);
        }
    }
}
