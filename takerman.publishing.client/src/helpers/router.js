import { createRouter, createWebHistory } from "vue-router";
import Login from '@/views/Login.vue';
import Home from "@/views/Home.vue";
import Admin from "@/views/Admin.vue";
import AdminPlatformLinks from "@/views/AdminPlatformLinks.vue";

export const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    linkActiveClass: 'active',
    routes: [
        { path: '/', component: Login },
        { path: '/home', component: Home },
        { path: '/admin', component: Admin },
        { path: '/admin/platform-links', component: AdminPlatformLinks },
        { path: '/login', component: Login },
        { path: '/:pathMatch(.*)*', redirect: '/' }
    ]
});

export default router;