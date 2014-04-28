using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace SampleTraders
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        public static class StaticMovieCatalog
        {
            private static List<Product> _Movies;
            public static List<Product> Movies
            {
                get
                {
                    if (_Movies == null)
                    {
                        _Movies = new List<Product>()
                            {
                                new Product(){ Id = 1, Vendor = "Vendor 1",  Name = "Blue Cheese", Qty = 19 },
                                new Product(){ Id = 2, Vendor = "Vendor 1",  Name = "Red Wine", Qty = 21 },
                                new Product(){ Id = 3, Vendor = "Vendor 1",  Name = "White Wine", Qty = 10 },
                                new Product(){ Id = 4, Vendor = "Vendor 2",  Name = "Parmesan Cheese 200gr", Qty = 30 },
                                new Product(){ Id = 5, Vendor = "Vendor 2",  Name = "Knives set", Qty = 5 }
                            };
                    }
                    return _Movies;
                }
            }



            public static List<Product> GetAll()
            {
                return Movies;
            }

            public static List<Product> GetByVendor(string genre)
            {
                return Movies.Where(x => x.Vendor.Contains(genre)).ToList();
            }

            public static Product GetById(int id)
            {
                return Movies.SingleOrDefault(x => x.Id == id);
            }

            public static void Save(Product movie)
            {
                movie.Id = Movies.Max(x => x.Id) + 1;
                Movies.Add(movie);
            }

            public static void Update(Product movie)
            {
                var movieToUpdate = GetById(movie.Id);
                if (movieToUpdate != null)
                {
                    int pos = Movies.IndexOf(movieToUpdate);
                    Movies.Insert(pos, movie);
                    Movies.Remove(movieToUpdate);
                }
            }

            public static void DeleteById(int id)
            {
                var movieToDelete = GetById(id);
                if (movieToDelete != null)
                {
                    Movies.Remove(movieToDelete);
                }
            }
        }
    }
}