using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        private FarmContext db = new FarmContext();
        public int fid;
        public int uid;
        public int UserOrFarmer;
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UserLogin()
        {
            return View();
        }
        public ActionResult UserSignUp()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult FarmerSignUp()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FarmerSignUp([Bind(Include = "FarmerId,FarmersName,FarmersMobileNumber,FarmsAddress,FarmersEmail,FPassword,FConfirmPassword")] FarmerDetails farmerDetails)
        {
            bool EmailInDBOrNot = db.FarmerDetails.Any(u => u.FarmersEmail ==farmerDetails.FarmersEmail);
            if (EmailInDBOrNot == true)
            {
                ModelState.AddModelError("EmailInDB", "Given Email has already been registered");
            }
            if (ModelState.IsValid)
            {

                
                db.FarmerDetails.Add(farmerDetails);
                db.SaveChanges();
                return RedirectToAction("FarmerLogin");
            }

            return View(farmerDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserSignUp([Bind(Include = "UserId,UserName,MobileNumber,Address,Email,Password,ConfirmPassword")] UserDetails userDetails)
        {
            bool EmailInDBOrNot = db.UserDetails.Any(u => u.Email == userDetails.Email);
            if(EmailInDBOrNot==true)
            {
                ModelState.AddModelError("EmailInDB", "Given Email has already been registered");
            }
            if (ModelState.IsValid)
            {
                db.UserDetails.Add(userDetails);
                db.SaveChanges();
                return RedirectToAction("UserLogin");
            }

            return View(userDetails);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserLogin(UserLogin user)
        {
            if (ModelState.IsValid)
            {
                bool IsValidUser = db.UserDetails
               .Any(u => u.Email == user.UserEmail && user
               .UserPassword == u.Password);
                var users = from u in db.UserDetails
                            where u.Email == user.UserEmail
                            select u;
                var loggedInUser = users.FirstOrDefault();
                
                



                if (IsValidUser)
                {
                    UserOrFarmer = 1;
                    FormsAuthentication.SetAuthCookie(user.UserEmail, false);
                    return RedirectToAction("UserCategorySelection","Home");
                }
                else
                {
                    ModelState.AddModelError("", "invalid Username or Password");

                }
            }
            return View();
        }



        public ActionResult FarmerLogin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FarmerLogin(FarmerLogin farmer)
        {
            if (ModelState.IsValid)
            {
                bool IsValidUser = db.FarmerDetails
               .Any(u => u.FarmersEmail == farmer.FarmersLoginEmail && farmer
               .FarmersLoginPassword == u.FPassword);
                var farmers = from u in db.FarmerDetails
                            where u.FarmersEmail == farmer.FarmersLoginEmail
                            select u;
                var loggedInUser = farmers.FirstOrDefault();
                try
                {
                    
                    fid = loggedInUser.FarmerId;
                }
                catch (NullReferenceException ex)

                {

                    Console.WriteLine("No Record Found");

                    Console.Write(ex.Message);



                }
                if (IsValidUser)
                {
                    UserOrFarmer = 2;
                    FormsAuthentication.SetAuthCookie(farmer.FarmersLoginEmail, false);
                    return RedirectToAction("ProductDetailsIndex", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "invalid Username or Password");

                }
            }
            return View();
        }






        public ActionResult ProductDetailsEntry()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProductDetailsEntry([Bind(Include = "ProductId,ProductCategory,ItemName,QuantityInStock,RatePerKg,DateOfHarvest,PFarmerId,FreshRating")] ProductDetails productDetails)
        {


            productDetails.PFarmerEmail = User.Identity.Name;
            productDetails.FreshRating = CalculateFreshRating(productDetails.DateOfHarvest);
            if (ModelState.IsValid)
            {
                db.ProductDetails.Add(productDetails);
                db.SaveChanges();
                return RedirectToAction("ProductDetailsIndex");
            }

            return View(productDetails);
        }
        public float CalculateFreshRating(DateTime DateOfHarvest)
        {
            float freshRating=5.0F;
            float subtactionValue;
            DateTime today = DateTime.Today;
            int differenceInDates = (today - DateOfHarvest).Days;
            subtactionValue = differenceInDates * 0.1F;
            freshRating = freshRating - subtactionValue;
            return freshRating;
        }
        public ActionResult ProductDetailsIndex()
        {
            return View(db.ProductDetails.ToList());
        }
        public ActionResult ProductToBeEdited(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDetails productDetails = db.ProductDetails.Find(id);
            if (productDetails == null)
            {
                return HttpNotFound();
            }
            return View(productDetails);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProductToBeEdited([Bind(Include = "ProductId,ProductCategory,ItemName,QuantityInStock,RatePerKg,DateOfHarvest,PFarmerId,FreshRating")] ProductDetails productDetails)
        {
            productDetails.PFarmerEmail = User.Identity.Name;

            productDetails.FreshRating = CalculateFreshRating(productDetails.DateOfHarvest);
            if (ModelState.IsValid)
            {
                db.Entry(productDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ProductDetailsIndex");
            }
            return View(productDetails);
        }
        public ActionResult ProductToBeDeleted(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDetails productDetails = db.ProductDetails.Find(id);
            if (productDetails == null)
            {
                return HttpNotFound();
            }
            return View(productDetails);
        }

        // POST: ProductDetails/Delete/5
        [HttpPost, ActionName("ProductToBeDeleted")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductDetails productDetails = db.ProductDetails.Find(id);
            db.ProductDetails.Remove(productDetails);
            db.SaveChanges();
            return RedirectToAction("ProductDetailsIndex");
        }
        public ActionResult UserCategorySelection()
        {
            return View();
        }
        
        
        

        public ActionResult AvailableVegetables()
        {
            Category Vegetable = Category.Vegetables;

            var CategoryChoosen = db.ProductDetails.Where
                                (s => s.ProductCategory == Vegetable).Select
                                (s => new ProductDetailsDTO
                                {
                                    ProductId = s.ProductId,
                                    ProductCategory = s.ProductCategory,
                                    ItemName = s.ItemName,
                                    QuantityInStock = s.QuantityInStock,
                                    RatePerKg = s.RatePerKg,
                                    DateOfHarvest = s.DateOfHarvest,
                                    FreshRating = s.FreshRating,
                                    PFarmerEmail = s.PFarmerEmail
                                });
            try
            {
                List<ProductDetailsDTO> CategoryChoosenList = CategoryChoosen.ToList();
                return View(CategoryChoosenList);
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine("Error");
                Console.WriteLine(ex.Message);
            }
            return View();

        }
        public ActionResult AvailableFruits()
        {
            Category Fruits = Category.Fruits;

            var CategoryChoosen = db.ProductDetails.Where
                                (s => s.ProductCategory == Fruits).Select
                                (s => new ProductDetailsDTO
                                {
                                    ProductId = s.ProductId,
                                    ProductCategory = s.ProductCategory,
                                    ItemName = s.ItemName,
                                    QuantityInStock = s.QuantityInStock,
                                    RatePerKg = s.RatePerKg,
                                    DateOfHarvest = s.DateOfHarvest,
                                    FreshRating = s.FreshRating,
                                    PFarmerEmail = s.PFarmerEmail
                                });
            try
            {
                List<ProductDetailsDTO> CategoryChoosenList = CategoryChoosen.ToList();
                return View(CategoryChoosenList);
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine("Error");
                Console.WriteLine(ex.Message);
            }
            return View();

        }
        public ActionResult AvailableHerbs()
        {
            Category Herbs = Category.Herbs;

            var CategoryChoosen = db.ProductDetails.Where
                                (s => s.ProductCategory == Herbs).Select
                                (s => new ProductDetailsDTO
                                {
                                    ProductId = s.ProductId,
                                    ProductCategory = s.ProductCategory,
                                    ItemName = s.ItemName,
                                    QuantityInStock = s.QuantityInStock,
                                    RatePerKg = s.RatePerKg,
                                    DateOfHarvest = s.DateOfHarvest,
                                    FreshRating = s.FreshRating,
                                    PFarmerEmail = s.PFarmerEmail
                                });
            try
            {
                List<ProductDetailsDTO> CategoryChoosenList = CategoryChoosen.ToList();
                return View(CategoryChoosenList);
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine("Error");
                Console.WriteLine(ex.Message);
            }
            return View();

        }
        public ActionResult AvailableGrains()
        {
            Category Grains = Category.Grains;

            var CategoryChoosen = db.ProductDetails.Where
                                (s => s.ProductCategory == Grains).Select
                                (s => new ProductDetailsDTO
                                {
                                    ProductId = s.ProductId,
                                    ProductCategory = s.ProductCategory,
                                    ItemName = s.ItemName,
                                    QuantityInStock = s.QuantityInStock,
                                    RatePerKg = s.RatePerKg,
                                    DateOfHarvest = s.DateOfHarvest,
                                    FreshRating = s.FreshRating,
                                    PFarmerEmail = s.PFarmerEmail
                                });
            try
            {
                List<ProductDetailsDTO> CategoryChoosenList = CategoryChoosen.ToList();
                return View(CategoryChoosenList);
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine("Error");
                Console.WriteLine(ex.Message);
            }
            return View();

        }
        public ActionResult AvailableGreens()
        {
            Category Greens = Category.Greens;

            var CategoryChoosen = db.ProductDetails.Where
                                (s => s.ProductCategory == Greens).Select
                                (s => new ProductDetailsDTO
                                {
                                    ProductId = s.ProductId,
                                    ProductCategory = s.ProductCategory,
                                    ItemName = s.ItemName,
                                    QuantityInStock = s.QuantityInStock,
                                    RatePerKg = s.RatePerKg,
                                    DateOfHarvest = s.DateOfHarvest,
                                    FreshRating = s.FreshRating,
                                    PFarmerEmail = s.PFarmerEmail
                                });
            try
            {
                List<ProductDetailsDTO> CategoryChoosenList = CategoryChoosen.ToList();
                return View(CategoryChoosenList);
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine("Error");
                Console.WriteLine(ex.Message);
            }
            return View();

        }
        public ActionResult AvailableHoney()
        {
            Category Honey = Category.Honey;

            var CategoryChoosen = db.ProductDetails.Where
                                (s => s.ProductCategory == Honey).Select
                                (s => new ProductDetailsDTO
                                {
                                    ProductId = s.ProductId,
                                    ProductCategory = s.ProductCategory,
                                    ItemName = s.ItemName,
                                    QuantityInStock = s.QuantityInStock,
                                    RatePerKg = s.RatePerKg,
                                    DateOfHarvest = s.DateOfHarvest,
                                    FreshRating = s.FreshRating,
                                    PFarmerEmail = s.PFarmerEmail
                                });
            try
            {
                List<ProductDetailsDTO> CategoryChoosenList = CategoryChoosen.ToList();
                return View(CategoryChoosenList);
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine("Error");
                Console.WriteLine(ex.Message);
            }
            return View();

        }

        public ActionResult UserQuantitySelection(int id)
        {
            

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserQuantitySelectionModel user = new UserQuantitySelectionModel();
            user.CartId = id;
            
            UserCart userCart = db.UserCarts.Find(id);
            ProductDetails productDetails = db.ProductDetails.Find(userCart.ProductId);
            user.Quantity = userCart.Quantity;
            if (userCart == null)
            {
                return HttpNotFound();
            }
            if (productDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuantityInStock = productDetails.QuantityInStock;

            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserQuantitySelection(UserQuantitySelectionModel userQuantitySelectionModel)
        {
            int cartid=userQuantitySelectionModel.CartId;
            UserCart userCart = db.UserCarts.Find(userQuantitySelectionModel.CartId);
            userCart.Quantity = userQuantitySelectionModel.Quantity;
            ProductDetails productDetails = db.ProductDetails.Find(userCart.ProductId);
            if(productDetails==null)
            {
                return HttpNotFound();
            }
            
            ViewBag.QuantityInStock = productDetails.QuantityInStock;

            if (userCart.Quantity>productDetails.QuantityInStock)
            {
                ModelState.AddModelError("Quantity", "Quantity entered is greater than Quantity in stock");
            }
            userCart.Amount = userCart.RatePerKg * userCart.Quantity;
            try
            {
                if (ModelState.IsValid)
                {
                    
                    db.SaveChanges();
                    return RedirectToAction("UserCartIndexAfter");
                }
            }
            catch(DbUpdateConcurrencyException ex)
            {
                Console.WriteLine("Error:{0}", ex.Message);
            }
            
            return View(userQuantitySelectionModel);
        }
        public ActionResult UserCartIndexAfter()
        {
            return View(db.UserCarts.ToList());
        }

        public ActionResult UserCartIndex(int? id)
        {
            var userDetails = db.UserDetails.Where(x=>x.Email == User.Identity.Name).First();
            ProductDetails productDetails = db.ProductDetails.Find(id);
            if (productDetails == null)
            {
                return HttpNotFound();
            }
            bool ItemAlreadyInCartOrNot = db.UserCarts.Any
                (u => u.ProductId == productDetails.ProductId);
            UserCart usercart = new UserCart
            {
                UserId=userDetails.UserId,
                ProductId = productDetails.ProductId,
                ItemName = productDetails.ItemName,
                Quantity = 1,
                RatePerKg = productDetails.RatePerKg,
                Amount = productDetails.RatePerKg,
                FarmerEmail = productDetails.PFarmerEmail
            };
            if (ModelState.IsValid && ItemAlreadyInCartOrNot==false)
            {
                db.UserCarts.Add(usercart);
                db.SaveChanges();

            }
           
            
            
            return View(db.UserCarts.ToList());
        }
        
        public ActionResult BillDetails()
        {
            return View(db.UserCarts.ToList());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BillAmount()
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("PaymentMethod");
            }
            return View();
        }
        public ActionResult PaymentMethod()
        {
            PaymentValidationModel paymentValidationModel = new PaymentValidationModel();
            return View(paymentValidationModel) ;
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PaymentMethod(PaymentValidationModel paymentValidationModel)
        {
            if(paymentValidationModel==null)
            {
                return HttpNotFound();
            }
            
            if (paymentValidationModel.Cvv.Length!=3)
            {
                ModelState.AddModelError("CvvValidation", "Incorrect Cvv");
            }
            
            if(paymentValidationModel.CardNumber.Length!=16)
            {
                ModelState.AddModelError("CardNumberValidation", "Incorrect Card Number");
            }
            if (ModelState.IsValid)
            {
                return RedirectToAction("CheckOut");
            }
            return View(paymentValidationModel);
        }
        public ActionResult CheckOut()
        {
            var userDetails = db.UserDetails.Where(x => x.Email == User.Identity.Name).First();
            int userid = userDetails.UserId;
            string connectionString = @"Data Source=DESKTOP-SFCJDDQ;Initial Catalog=FreshFarmDB;Integrated Security=True;";  //"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database2.mdf;Integrated Security=True";
                 
            List<UserCart> UserCartList = (from u in db.UserCarts
                                           where
                                            u.UserId == userid
                                           select u).ToList();
            int quantityInStock;
            int productId;
            foreach(var item in UserCartList)
            {
                ProductDetails pd = db.ProductDetails.Find(item.ProductId);
                pd.QuantityInStock = pd.QuantityInStock - item.Quantity;
                quantityInStock = pd.QuantityInStock;
                productId = pd.ProductId;
                string sqlText = @"UPDATE ProductDetails
                                SET quantityInStock = @QuantityInStock
                                WHERE productId = @ProductId";
                
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(sqlText, connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@QuantityInStock", quantityInStock);
                        command.Parameters.AddWithValue("@ProductId", productId);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }                    
                }

            }
            string commandText = @"Delete from UserCart where userid=@UserId";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(commandText, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@UserId",userid);
                    
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View();
        }
        public ActionResult EditUserDetails()
        {
            var userDetails = db.UserDetails.Where(x => x.Email == User.Identity.Name).First();
            UserDetails ud = db.UserDetails.Find(userDetails.UserId);
            if(ud==null)
            {
                return HttpNotFound();
            }
            return View(ud);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUserDetails([Bind(Include = "UserId,UserName,MobileNumber,Address,Email,Password,ConfirmPassword")] UserDetails userDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("UserCategorySelection");
            }
            return View(userDetails);
        }
        public ActionResult EditFarmerDetails()
        {
            var farmerDetails = db.FarmerDetails.Where(x => x.FarmersEmail == User.Identity.Name).First();
            FarmerDetails fd = db.FarmerDetails.Find(farmerDetails.FarmerId);
            if (fd == null)
            {
                return HttpNotFound();
            }
            return View(fd);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditFarmerDetails([Bind(Include = "FarmerId,FarmersName,FarmersMobileNumber,FarmsAddress,FarmersEmail,FPassword,FConfirmPassword")] FarmerDetails farmerDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(farmerDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ProductDetailsIndex");
            }
            return View(farmerDetails);
        }








    }
}
