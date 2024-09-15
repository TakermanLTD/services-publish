<template>
    <nav class="navbar navbar-expand-sm bg-dark navbar-dark">
        <router-link :to="isAuthenticated ? '/home' : '/login'" class="navbar-brand">PUBLISHER</router-link>
        <ul v-if="!isAuthenticated && !isLoading" class="navbar-nav">
            <li class="nav-item">
                <button id="qsLoginBtn" class="btn btn-primary btn-margin" @click.prevent="login">Login</button>
            </li>
        </ul>
        <ul v-if="isAuthenticated" class="navbar-nav">
            <li class="nav-item">
                <router-link to="/home" class="nav-link">Home</router-link>
            </li>
            <li class="nav-item">
                <router-link to="/admin/platform-links" class="nav-link">Platform Links</router-link>
            </li>
            <li class="nav-item dropdown">
                <a class="nav-link dropdown-toggle" href="#" id="profileDropDown" data-toggle="dropdown">
                    <img :src="user.picture" alt="User's profile picture" class="nav-user-profile rounded-circle" width="50" />
                </a>
                <div class="dropdown-menu dropdown-menu-right">
                    <div class="dropdown-header">{{ user.name }}</div>
                    <router-link to="/profile" class="dropdown-item dropdown-profile">
                        <font-awesome-icon class="mr-3" icon="user" />Profile
                    </router-link>
                    <a id="qsLogoutBtn" href="#" class="dropdown-item" @click.prevent="logout">
                        <font-awesome-icon class="mr-3" icon="power-off" />Log out
                    </a>
                </div>
            </li>
        </ul>
    </nav>
</template>
<script lang="js">
import { useAuth0 } from '@auth0/auth0-vue';

export default {
    data() {
        return {
            auth0: useAuth0(),
            isAuthenticated: this.auth0 ? this.auth0.isAuthenticated : false,
            isLoading: this.auth0 ? this.auth0.isLoading : false,
            user: this.auth0 ? this.auth0.user : null
        }
    },
    methods: {
        login() {
            this.auth0.loginWithRedirect();
        },
        logout() {
            this.auth0.logout({
                logoutParams: {
                    returnTo: window.location.origin
                }
            });
        }
    }
}
</script>