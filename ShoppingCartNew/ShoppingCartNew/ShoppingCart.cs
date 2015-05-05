using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartNew
{
    public class Product
    {
        private string ProductName;
        private int ProductPrice;
        
        public Product(string P_Name,int P_Price)
        {
            ProductName = P_Name;
            ProductPrice = P_Price;
        }
    }
    public class ShoppingCart : IEnumerable
    {
        List<Product> cart = new List<Product>();
        int itemCount;
        public int ItemCount
        {
            get
            {
                foreach (var i in cart)
                {
                    this.itemCount++;
                }
                return this.itemCount;

            }
        }
        public void AddItems(Product _Product,int Quantity)
        {
            if (Quantity != 0 && _Product != null)
            {
                try
                {
                    if (Quantity > 0)
                    {
                        while (Quantity != 0)
                        {
                            cart.Add(_Product);
                            Quantity--;
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException();
                    }
                }
                catch (InvalidOperationException e)
                {
                    throw e;
                }

            }
            

        }
        public void DeleteItems(Product _Product, int Quantity)
        {
             while (Quantity != 0)
             {
                try
                {
                    if (Quantity > 0)
                    {

                        if (cart.Exists(element => element == _Product))
                        {
                            cart.Remove(_Product);
                            Quantity--;
                        }
                        else
                        {
                            throw new NullReferenceException();
                        }
                        
                    }
                    else
                    {
                        throw new InvalidOperationException();
                    }
                }
                catch (InvalidOperationException e)
                {
                    throw e;
                }
                catch(NullReferenceException e)
                {
                    throw new NullReferenceException();
                }
            }
        }
        
       
        public IEnumerator GetEnumerator()
        {
            return cart.GetEnumerator();
        }
    }
   
}
