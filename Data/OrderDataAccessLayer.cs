﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp1.Data;

namespace BlazorApp1.Data
{
    public class OrderDataAccessLayer
    {
        OrderContext db = new OrderContext();

        //To Get all Orders details   
        public DbSet<Order> GetAllOrders()
        {
            try
            {
                return db.Orders;
            }
            catch
            {
                throw;
            }
        }

       // To Add new Order record
        public void AddOrder(Order Order)
        {
            try
            {
                db.Orders.Add(Order);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particular Order    
        public void UpdateOrder(Order Order)
        {
            // 
            var empId = db.Set<Order>()
                .Local
                .FirstOrDefault(entry => entry.EmployeeID.Equals(Order.EmployeeID));

            // check if local is not null 
            if (empId != null)
            {
                // detach
                db.Entry(empId).State = EntityState.Detached;
            }

            try
            {
                db.Entry(Order).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        //Get the details of a particular Order    
        public Order GetOrderData(int id)
        {
            try
            {
                Order Order = db.Orders.Find(id);
                return Order;
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular Order    
        public void DeleteOrder(Order data)
        {
            try
            {
                db.Orders.Remove(db.Orders.Where(or => or.EmployeeID == data.EmployeeID).FirstOrDefault());
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
