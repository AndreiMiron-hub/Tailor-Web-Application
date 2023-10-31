import { Navigate, useRoutes } from 'react-router-dom';
// layouts
import DashboardLayout from './layouts/dashboard';
import SimpleLayout from './layouts/simple';
//
// import BlogDashboardPage from './pages/news/BlogDashboardPage';
import UserPage from './pages/dashboard/UserPage';
import LoginPage from './pages/LoginPage';
import Page404 from './pages/Page404';
import ProductsPage from './pages/products/ProductsPage';
// import DashboardAppPage from './pages/dashboard/DashboardAppPage';
import  {BlogDashboardPage, 
  DashboardAppPage, 
  AppointmentsDashboardPage, 
  ServicesDashboardPage, 
  ProductDashboardPage,
  ProfileDashboardPage} from './pages/dashboard';
import {Home, Contact, Services, About, OurTeamPage, AppointmentPage, Galery}  from './pages';
import { Blog, ArticlePage} from './pages/news';
import { ProductPage } from './pages/products';
// ----------------------------------------------------------------------

export default function Router() {
  const routes = useRoutes([
    {
      path: '/dashboard',
      element: <DashboardLayout />,
      children: [
        { element: <Navigate to="/dashboard/user" />, index: true },
        { path: 'app', element: <DashboardAppPage /> },
        { path: 'user', element: <UserPage /> },
        { path: 'products', element: <ProductDashboardPage /> },
        { path: 'blog', element: <BlogDashboardPage /> },
        { path: 'services', element: <ServicesDashboardPage/>},
        { path: 'appointments', element: <AppointmentsDashboardPage/>},
        { path: 'profile', element: <ProfileDashboardPage/>},
      ],
    },
    {
      path: 'login',
      element: <LoginPage />,
    },
    {
      path: '*',
      children: [
        { element: <Navigate to="/404"  replace /> },
        { path: '404', element: <Page404 /> },
        { path: '*', element: <Navigate to="/404" /> },
      ],
    },
    {
      path: '',
      element: <SimpleLayout />,
      children: [
        { element: <Navigate to="/home" />, index: true },
        { path: 'home', element: <Home /> },
        { path: 'about', element: <About /> },
        { path: 'contact', element: <Contact /> },
        { path: 'services', element: <Services /> },
        { path: 'blog', element: <Blog />},
        { path: 'team', element: <OurTeamPage/>},
        { path: 'appointment', element: <AppointmentPage/> },
        { path: 'galery', element: <Galery/>},
        { path: 'products', element: <ProductsPage/>},
        { path: 'blog/:id', element: <ArticlePage/>},
        { path: 'product/:id', element: <ProductPage/>},
      ],
    },
  ]);

  return routes;
}
