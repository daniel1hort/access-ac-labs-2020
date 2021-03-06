﻿using System;
using System.Collections.Generic;
using System.Text;
using Domain.Domain.CreateMenuOp;
using Domain.Domain.CreateRestauratOp;
using Domain.Domain.CreateEmployeeOp;
using Domain.Models;
using Infra.Free;
using LanguageExt.ClassInstances;
using static IOExt;
using static Domain.Domain.CreateRestauratOp.CreateRestaurantResult;
using static Domain.Domain.CreateEmployeeOp.CreateEmployeeResult;
using static Domain.Models.Employee;
using static Domain.Domain.CreateOrderOp.CreateOrderResult;
using Domain.Domain.CreateOrderOp;
using static Domain.Domain.SelectRestaurantOp.SelectRestaurantResult;
using Domain.Domain.SelectRestaurantOp;
using static Domain.Domain.DeleteRestaurantOp.DeleteRestaurantResult;
using Domain.Domain.DeleteRestaurantOp;
using static Domain.Domain.CreateMenuItem.CreateMenuItemResult;
using Domain.Domain.CreateMenuItem;
using static Domain.Domain.SelectClientOp.SelectClientResult;
using Domain.Domain.SelectClientOp;
using static Domain.Domain.GetMenusOp.GetMenusResult;
using Domain.Domain.GetMenusOp;
using static Domain.Domain.AddToCartOp.AddToCartResult;
using Domain.Domain.AddToCartOp;
using static Domain.Domain.ChangeQuantityOp.ChangeQuantityResult;
using Domain.Domain.ChangeQuantityOp;
using static Domain.Domain.PlaceOrderOp.PlaceOrderResult;
using Domain.Domain.PlaceOrderOp;
using static Domain.Domain.GetOrderStatus.GetOrderStatusResult;
using Domain.Domain.GetOrderStatus;
using Domain.Domain.SetMenuAvalabilityOp;
using static Domain.Domain.SetMenuAvalabilityOp.SetMenuAvalabilityResult;
using static Domain.Domain.GetOrdersOp.GetOrdersResult;
using Domain.Domain.GetOrdersOp;
using static Domain.Domain.SetOrderStatusOp.SetOrderStatusResult;
using Domain.Domain.SetOrderStatusOp;
using static Domain.Models.Cart;
using static Domain.Domain.RequestPaymentOp.RequestPaymentResult;
using Domain.Domain.RequestPaymentOp;
using static Domain.Domain.GetPaymentStatusOp.GetPaymentStatusResult;
using Domain.Domain.GetPaymentStatusOp;
using Domain.Domain.CreateCartItemOp;
using static Domain.Domain.CreateCartItemOp.CreateCartItemResult;
using static Domain.Domain.CreateClientOp.CreateClientResult;
using Domain.Domain.CreateClientOp;
using static Domain.Domain.GetMenuItemOp.GetMenuItemResult;
using Domain.Domain.GetMenuItemOp;
using static Domain.Domain.SelectMenuOp.SelectMenuResult;
using Domain.Domain.SelectMenuOp;
using static Domain.Domain.GetCartItemOp.GetCartItemResult;
using Domain.Domain.GetCartItemOp;

namespace Domain.Domain
{
    public static class RestaurantDomain
    {
        // Restaurant
        public static IO<ICreateRestaurantResult> CreateRestaurant(string name) =>
            NewIO<CreateRestaurantCmd, ICreateRestaurantResult>(new CreateRestaurantCmd(name));

        // Menu
        public static IO<CreateMenuResult.ICreateMenuResult> CreateMenu(Restaurant restaurant, string menuName, MenuType menuType, MenuVisibilityTypes MenuVisibilityTypes, String hour = null)
            => NewIO<CreateMenuCmd, CreateMenuResult.ICreateMenuResult>(new CreateMenuCmd(restaurant, menuName, menuType, MenuVisibilityTypes, hour));

        // Employee
        public static IO<ICreateEmployeeResult> CreateEmployee(String name, int age, String address, String telephone, float salary, JobRoles role, String iban, Restaurant restaurant)
            => NewIO<CreateEmployeeCmd, ICreateEmployeeResult>(new CreateEmployeeCmd(name, age, address, telephone, salary, role, iban, restaurant));

        public static IO<ICreateOrderResult> CreateOrder(int id, int tableNumber, Cart items, String waiter, float price, Restaurant restaurant) =>
            NewIO<CreateOrderCmd, ICreateOrderResult>(new CreateOrderCmd(id, tableNumber, items, waiter, price, restaurant));

        public static IO<ISelectRestaurantResult> SelectRestaurant(String name) =>
            NewIO<SelectRestaurantCmd, ISelectRestaurantResult>(new SelectRestaurantCmd(name));

        public static IO<IDeleteRestaurantResult> DeleteRestaurant(String name) =>
            NewIO<DeleteRestaurantCmd, IDeleteRestaurantResult>(new DeleteRestaurantCmd(name));

        public static IO<ICreateMenuItemResult> CreateMenuItem(String name, float price, List<String> alergens, List<String> ingredients, String imageData, Menu menu) =>
            NewIO<CreateMenuItemCmd, ICreateMenuItemResult>(new CreateMenuItemCmd(name, price, alergens, ingredients, imageData, menu));

        public static IO<ISelectClientResult> SelectClient(String sessionID) =>
            NewIO<SelectClientCmd, ISelectClientResult>(new SelectClientCmd(sessionID));

        public static IO<IGetMenusResult> GetAllMenus(Restaurant restaurant) =>
            NewIO<GetMenusCmd, IGetMenusResult>(new GetMenusCmd(restaurant));

        public static IO<IAddToCartResult> AddToCart(String sessionId, List<CartItem> items) =>
            NewIO<AddToCartCmd, IAddToCartResult>(new AddToCartCmd(sessionId, items));

        public static IO<IChangeQuantityResult> ChangeQuantity(String sessionID, CartItem item, uint quantity) =>
            NewIO<ChangeQuantityCmd, IChangeQuantityResult>(new ChangeQuantityCmd(sessionID, item, quantity));

        public static IO<IPlaceOrderResult> PlaceOrder(Restaurant restaurant, Client client, float tip = 0) =>
            NewIO<PlaceOrderCmd, IPlaceOrderResult>(new PlaceOrderCmd(restaurant, client, tip));

        public static IO<IGetOrderStatusResult> GetOrderStatus(String sessionId) =>
            NewIO<GetOrderStatusCmd, IGetOrderStatusResult>(new GetOrderStatusCmd(sessionId));

        public static IO<ISetMenuAvalabilityResult> SetMenuAvalability(Restaurant restaurant, Menu menu, MenuVisibilityTypes type, String hour) =>
            NewIO<SetMenuAvalabilityCmd, ISetMenuAvalabilityResult>(new SetMenuAvalabilityCmd(restaurant, menu, type, hour));

        public static IO<IGetOrdersResult> GetAllOrders(Restaurant restaurant) =>
            NewIO<GetOrdersCmd, IGetOrdersResult>(new GetOrdersCmd(restaurant));

        public static IO<ISetOrderStatusResult> SetOrderStatus(Cart cart, CartStatus status) =>
            NewIO<SetOrderStatusCmd, ISetOrderStatusResult>(new SetOrderStatusCmd(cart, status));

        public static IO<IRequestPaymentResult> RequestPayment(String sessionID) =>
            NewIO<RequestPaymentCmd, IRequestPaymentResult>(new RequestPaymentCmd(sessionID));

        public static IO<IGetPaymentStatusResult> CheckPaymentStatus(String sessionID) =>
            NewIO<GetPaymentStatusCmd, IGetPaymentStatusResult>(new GetPaymentStatusCmd(sessionID));

        public static IO<ICreateCartItemResult> CreateCartItem(String sessionID, MenuItem menuItem, uint quantity) =>
            NewIO<CreateCartItemCmd, ICreateCartItemResult>(new CreateCartItemCmd(sessionID, menuItem, quantity));

        public static IO<ICreateClientResult> CreateClient(String name, String username, String password, String email) =>
            NewIO<CreateClientCmd, ICreateClientResult>(new CreateClientCmd(name, username, password, email));

        public static IO<IGetMenuItemResult> GetMenuItem(Restaurant restaurant, Menu menu, String menuItem) =>
            NewIO<GetMenuItemCmd, IGetMenuItemResult>(new GetMenuItemCmd(restaurant, menu, menuItem));

        public static IO<ISelectMenuResult> SelectMenu(Restaurant restaurant, String menuName) =>
            NewIO<SelectMenuCmd, ISelectMenuResult>(new SelectMenuCmd(restaurant, menuName));

        public static IO<IGetCartItemResult> GetCartItem(String sessionID, MenuItem menuItem) =>
            NewIO<GetCartItemCmd, IGetCartItemResult>(new GetCartItemCmd(sessionID, menuItem));
    }
}