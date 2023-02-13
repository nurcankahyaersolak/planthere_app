// React
import { createBrowserRouter, Outlet } from "react-router-dom";

// Components
import NavBar from './pages/navBar/navBar'

import SignIn from './pages/authentication/signIn'
import SignUp from './pages/authentication/signUp'

import Products from './pages/products/products'
import ProductDetail from './pages/products/productDetail'

import Basket from './pages/basket/basket/basket'
import BuyBasket from "./pages/basket/buyBaket/buyBasket";

import Order from './pages/order/order'

import NotFoundPage from './pages/errorPage/notFoundPage';

const NavbarWrapper = () => {
    return (
        <div>
            <NavBar />
            <Outlet />
        </div>
    )
};

const router = createBrowserRouter([
    {
        path: "/",
        element: <NavbarWrapper />,
        children: [
            {
                path: "/",
                element: <Products />,
            },
            {
                path: "/details/:id",
                element: <ProductDetail />,
            },
            {
                path: "/SignIn",
                element: <SignIn />,
            },
            {
                path: "/SignUp",
                element: <SignUp />,
            },
            {
                path: "/Basket",
                element: <Basket />,
            },
            {
                path: "/BuyBasket",
                element: <BuyBasket />,
            },
            {
                path: "/Order",
                element: <Order />,
            },
            {
                path: "*",
                element: <NotFoundPage />,
            }]
    }]);



export default router