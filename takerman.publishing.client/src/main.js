import './assets/main.css';
import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap-icons/font/bootstrap-icons.min.css";
import "bootstrap";
import App from './App.vue';
import authConfig from "../auth_config.json";
import { createApp } from 'vue';
import { createRouter, createWebHistory } from "vue-router";
import { createAuth0, createAuthGuard } from "@auth0/auth0-vue";
import Home from "@/views/Home.vue";
import AdminPlatformLinks from "@/views/AdminPlatformLinks.vue";
import Profile from './views/Profile.vue';
import Dashboard from '@/views/Dashboard.vue';
import { library } from "@fortawesome/fontawesome-svg-core";
import { faLink, faUser, faPowerOff } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import hljs from 'highlight.js/lib/core';
import json from 'highlight.js/lib/languages/json';
import hljsVuePlugin from "@highlightjs/vue-plugin";
import "highlight.js/styles/github.css";

hljs.registerLanguage('json', json);

let app = createApp(App);

library.add(faLink, faUser, faPowerOff);

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    linkActiveClass: 'active',
    routes: [
        { path: '/', component: Home },
        { path: '/login', component: Home },
        { path: '/dashboard', component: Dashboard, beforeEnter: createAuthGuard(app) },
        { path: '/admin/platform-links', component: AdminPlatformLinks, beforeEnter: createAuthGuard(app) },
        { path: "/profile", component: Profile, beforeEnter: createAuthGuard(app) },
        { path: '/:pathMatch(.*)*', redirect: '/' }
    ]
});

app.use(router)
    .use(hljsVuePlugin)
    .use(createAuth0({
        domain: authConfig.domain,
        clientId: authConfig.clientId,
        authorizationParams: {
            redirect_uri: window.location.origin,
        }
    }))
    .component("font-awesome-icon", FontAwesomeIcon)
    .mount('#app');