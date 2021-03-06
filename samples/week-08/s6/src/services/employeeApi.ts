import { axiosClient } from "./axiosClient";
import { handleError } from "./apiUtils";
import { MenuItem } from "../models/menu";

export const getMenus = () => {
  return axiosClient.get("employee/restaurants/1/menus").catch(handleError);
};

export const getMenu = (menuId: string) => {
  return axiosClient
    .get(`employee/restaurants/1/menus/${menuId}`)
    .catch(handleError);
};

export const createMenuItem = (menuId: string, item: MenuItem) => {
  return axiosClient
    .post(`employee/restaurants/1/menus/${menuId}/items`, {
      name: item.name,
      price: item.price,
    })
    .catch(handleError);
};
