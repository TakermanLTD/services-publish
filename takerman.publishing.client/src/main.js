import './assets/main.css';
import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap-icons/font/bootstrap-icons.min.css";
import "bootstrap";
import router from './helpers/router';
import { createApp } from 'vue';
import App from './App.vue';

createApp(App)
    .use(router)
    .mount('#app');