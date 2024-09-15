<template>
    <nav class="navbar navbar-expand-sm bg-dark navbar-dark">
        <router-link :to="this.isAuthenticated ? '/home' : '/login'" class="navbar-brand">PUBLISHER</router-link>
        <ul v-if="!this.isAuthenticated && !this.isLoading" class="navbar-nav">
            <li class="nav-item">
                <button id="qsLoginBtn" class="btn btn-primary btn-margin" @click.prevent="login">Login</button>
            </li>
        </ul>
        <ul v-if="this.isAuthenticated" class="navbar-nav">
            <li class="nav-item">
                <router-link to="/dashboard" class="nav-link">Dashboard</router-link>
            </li>
            <li class="nav-item">
            </li>
            <li class="nav-item dropdown">
                <a class="nav-link dropdown-toggle" href="#" id="navbarAdmin" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                    Admin
                </a>
                <ul class="dropdown-menu" aria-labelledby="navbarAdmin">
                    <li>
                        <router-link to="/admin/platform-links" class="dropdown-item">Platform Links</router-link>
                    </li>
                </ul>
            </li>
            <li class="nav-item dropdown">
                <a class="nav-link dropdown-toggle" href="#" id="navbarProfile" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                    <img :src="this.user.picture" alt="User's profile picture" class="nav-user-profile rounded-circle" width="50" />
                </a>
                <ul class="dropdown-menu" aria-labelledby="navbarProfile">
                    <li>
                        <div class="dropdown-header">{{ this.user.name }}</div>
                        <router-link to="/profile" class="dropdown-item">
                            <font-awesome-icon class="mr-3" icon="user" />Profile
                        </router-link>
                    </li>
                    <li>
                        <a id="qsLogoutBtn" href="#" class="dropdown-item" @click.prevent="this.logout()">
                            <font-awesome-icon class="mr-3" icon="power-off" />Log out
                        </a>
                    </li>
                </ul>
            </li>
        </ul>
    </nav>
</template>
<script lang="js">
import { useAuth0 } from '@auth0/auth0-vue';

export default {
    data() {
        let auth0 = useAuth0();
        return {
            isAuthenticated: auth0 ? auth0.isAuthenticated : false,
            isLoading: auth0 ? auth0.isLoading : false,
            user: auth0 ? auth0.user : null,
            isOpen: false
        }
    },
    methods: {
        login() {
            let auth0 = useAuth0();
            auth0.loginWithRedirect();
        },
        logout() {
            let auth0 = useAuth0();
            auth0.logout({
                logoutParams: {
                    returnTo: window.location.origin
                }
            });
        }
    }
}
</script>