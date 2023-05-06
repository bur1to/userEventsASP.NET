import { createRouter, createWebHistory } from 'vue-router';
import MainPage from '@/pages/MainPage.vue';
import RegistrationPage from '@/pages/RegistrationPage';
import UsersPage from '@/pages/UsersPage';
import LoginPage from '@/pages/LoginPage';
import BlogCreatePage from '@/pages/BlogCreatePage';
import BlogPage from '@/pages/BlogPage';
import CreateEventPage from '@/pages/CreateEventPage';
import UpdateUserPage from '@/pages/UpdateUserPage';
import EditBlogPage from '@/pages/EditBlogPage';
import UserPage from '@/pages/UserPage';


const routes = [
  {
    path: '/',
    component: MainPage
  },
  {
    path: '/register',
    component: RegistrationPage
  },
  {
    path: '/users',
    component: UsersPage
  },
  {
    path: '/create_blog',
    component: BlogCreatePage
  },
  {
    path: '/login',
    component: LoginPage
  },
  {
    path: '/edit_profile',
    component: UpdateUserPage
  },
  {
    path: '/blog',
    component: BlogPage
  },
  {
    path: '/create_event',
    component: CreateEventPage
  },
  {
    path: '/profile',
    component: UserPage
  },
  {
    path: '/edit_blog',
    component: EditBlogPage
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
  linkActiveClass: 'active-link',
})

export default router;
