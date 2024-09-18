import './assets/main.css';
import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap-icons/font/bootstrap-icons.min.css";
import "bootstrap";
import App from './App.vue';
import { createApp } from 'vue';
import { createRouter, createWebHistory } from "vue-router";
import { createAuth0, createAuthGuard } from "@auth0/auth0-vue";
import Home from "@/views/Home.vue";
import AdminPlatformLinks from "@/views/admin/PlatformLinks.vue";
import Profile from './views/Profile.vue';
import Dashboard from '@/views/Dashboard.vue';
import cookies from './helpers/cookies';
import { createI18n } from 'vue-i18n';
import en from './assets/languages/en.json';
import ProjectPlatformRecords from './views/admin/ProjectPlatformRecords.vue';
import ProjectPlatforms from './views/admin/ProjectPlatforms.vue';
import PlatformLinks from './views/admin/PlatformLinks.vue';
import PostTypes from './views/admin/PostTypes.vue';
import Platforms from './views/admin/Platforms.vue';
import Projects from './views/admin/Projects.vue';

createApp(App)
    .use(createI18n({
        locale: cookies.get('language') || 'en',
        legacy: false,
        locale: cookies.get('language') || 'en',
        fallbackLocale: 'en',
        formatFallbackMessages: true,
        messages: {
            en: en
        }
    }))
    .use(createRouter({
        history: createWebHistory(import.meta.env.BASE_URL),
        linkActiveClass: 'active',
        routes: [
            { path: '/', component: Home },
            { path: '/home', component: Home },
            { path: '/dashboard', component: Dashboard, beforeEnter: createAuthGuard(this) },
            { path: '/admin/projects', component: Projects, beforeEnter: createAuthGuard(this) },
            { path: '/admin/platforms', component: Platforms, beforeEnter: createAuthGuard(this) },
            { path: '/admin/post-types', component: PostTypes, beforeEnter: createAuthGuard(this) },
            { path: '/admin/platform-links', component: PlatformLinks, beforeEnter: createAuthGuard(this) },
            { path: '/admin/project-platforms', component: ProjectPlatforms, beforeEnter: createAuthGuard(this) },
            { path: '/admin/project-platform-records', component: ProjectPlatformRecords, beforeEnter: createAuthGuard(this) },
            { path: "/profile", component: Profile, beforeEnter: createAuthGuard(this) },
            { path: '/:pathMatch(.*)*', redirect: '/' }
        ]
    }))
    .use(createAuth0({
        domain: "takerman.eu.auth0.com",
        clientId: "K5sBFLilfvKNY2aOBYNSYoJnpgJqmvLd",
        authorizationParams: {
            redirect_uri: window.location.origin,
        }
    }))
    .mount('#app');